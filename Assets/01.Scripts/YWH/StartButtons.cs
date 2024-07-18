using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtons : MonoBehaviour
{

    [SerializeField] private GameObject ga;

    private void Start()
    {
        FadeManager.instance.FadeOut(1f);  
    }


    public void StartButtonClick()
    {
        StartCoroutine(Waitasec());

    }

    IEnumerator Waitasec()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName.Stage0);
    }

    IEnumerator Waitasec2()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(2);
        FadeManager.instance.FadeOut(1);
        ga.SetActive(true);
    }

    public void LeaveButtonClick()
    {
        print("ss");
        Application.Quit();
    }
    public void ContinueButtonClick()
    {
        Debug.Log("��");
        StartCoroutine(Waitasec2());
    }
}
