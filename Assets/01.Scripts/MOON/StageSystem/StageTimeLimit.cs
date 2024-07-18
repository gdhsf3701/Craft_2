using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageTimeLimit : MonoBehaviour
{
    [SerializeField]int timeLimit;
    int nowTime = 0;
    public bool nowCheck = true;

    public bool done = false;

    public Action<int> OnNowTimeChanged;
    public int Time 
    { 
        get
        {
            return timeLimit;
        }
        private set 
        { 
        } 
    }
    public int NowTime
    {
        get => nowTime;
        private set
        {
            if (nowTime != value)
            {
                nowTime = value;
                OnNowTimeChanged?.Invoke(nowTime);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(TimeCheck());
    }

    IEnumerator TimeCheck()
    {
        while (nowTime <= timeLimit&& nowCheck)
        {
            yield return new WaitForSeconds(1);
            if (!done)
            {
                NowTime += 1;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
