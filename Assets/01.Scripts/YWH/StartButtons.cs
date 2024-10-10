using System.Collections;
using EasySave.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtons : MonoBehaviour
{
    [SerializeField] private GameObject ga;
    private bool _isNotFull = false;
    private void Start()
    {
        FadeManager.instance.FadeOut(1f);  
    }
    public void StartButtonClick()
    {
        StartCoroutine(StartCoroutine());
    }

    IEnumerator StartCoroutine()
    {
        string dataPath = "";
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(1);
        for (int i = 1; i < 6; i++)
        {
            if (!EasyToJson.IsExistJson("SaveData" + i))
            {
                dataPath += "SaveData" + i;
                _isNotFull = true;
                break;
            }
        }
        if (_isNotFull)
        {
            SaveManager.Instance.SetDataPath(dataPath,new SaveData());
            SceneManager.LoadScene(SceneName.Stage0);
        }
        else if(!_isNotFull)
        {
            SceneManager.LoadScene(SceneName.Delete);
        }
    }

    IEnumerator ContinueCo()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneName.Select);
    }

    public void LeaveButtonClick()
    {
        Application.Quit();
    }
    public void ContinueButtonClick()
    {
        StartCoroutine(ContinueCo());
    }
}
