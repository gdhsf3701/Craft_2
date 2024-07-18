using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    StageTimeLimit timeLimit;
    private void Start()
    {
        timeLimit = FindAnyObjectByType<StageTimeLimit>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeLimit.done = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        timeLimit.done = false;
    }
}
