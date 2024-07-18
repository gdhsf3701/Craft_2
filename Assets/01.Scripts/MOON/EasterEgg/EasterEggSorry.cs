using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasterEggSorry : MonoBehaviour
{
    static public int deathCount = 0;
    static int lastStage;
    private void Awake()
    {
        int nowScene = int.Parse(SceneManager.GetActiveScene().name[5].ToString());
        if (nowScene != lastStage)
        {
            deathCount = 0;
        }
    }
    private void Update()
    {
        if (deathCount == 50)
        {

        }
    }
}
