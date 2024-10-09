using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stage3Failed : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene(SceneName.Stage3);
    }

    public void GameClear()
    {
        SceneManager.LoadScene(SceneName.Stage4);
    }
}
