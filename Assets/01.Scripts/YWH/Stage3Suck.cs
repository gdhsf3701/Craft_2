using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3Suck : MonoBehaviour
{
    public void Suck()
    {
        SaveManager.Instance.SetStageNumber(4,SceneName.Stage4);
        SceneManager.LoadScene(SceneName.Stage4);
    }
}
