using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    private Label text1;
    private Label text2;
    private Label credit;
    private bool isClicked = false;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        text1 = root.Q<Label>("Text1");
        text2 = root.Q<Label>("Text2");
        credit = root.Q<Label>("Credit");

        Invoke("StartText", 0.5f);
    }

    void StartText()
    {
        text1.RemoveFromClassList("Hide");
        text1.AddToClassList("Show");

        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(2f);

        text1.RemoveFromClassList("Show");
        text1.AddToClassList("Hide");

        yield return new WaitForSeconds(1f);
        text2.RemoveFromClassList("Hide2");
        text2.AddToClassList("Show2");

        yield return new WaitForSeconds(2f);

        text2.RemoveFromClassList("Show2");
        text2.AddToClassList("Hide2");

        yield return new WaitForSeconds(1f);
        StartCoroutine(CreditRoll());
    }

    IEnumerator CreditRoll()
    {
        credit.style.display = DisplayStyle.Flex;

        float elapsedTime = 0f;
        float totalDuration = 10f;
        Vector3 startPosition = credit.transform.position + new Vector3(0, 500, 0); 
        Vector3 targetPosition = startPosition + new Vector3(0, -2000, 0); 

        while (elapsedTime < totalDuration)
        {
            credit.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / totalDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            isClicked = false;
            SceneManager.LoadScene("StartScene");
        }
    }
}
