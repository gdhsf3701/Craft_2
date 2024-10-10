using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3Suck : MonoBehaviour
{
    public void Suck()
    {
        SceneManager.LoadScene(SceneName.Stage4);
    }
}
