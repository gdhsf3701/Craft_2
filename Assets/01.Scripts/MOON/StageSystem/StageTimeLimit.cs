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
        while (nowTime <= timeLimit)
        {
            yield return new WaitForSeconds(1);
            if (!done)
            {
                NowTime += 1;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        //게임오버 스크립트
    }
}
