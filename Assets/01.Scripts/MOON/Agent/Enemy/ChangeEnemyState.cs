using BehaviorDesigner.Runtime.Tasks.Unity.UnityTransform;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeEnemyState : MonoBehaviour
{
    GunKnifeEnemy[] childScr;
    Stage3_Door Door;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            childScr[i] = transform.GetChild(i).GetComponent<GunKnifeEnemy>();
        }
    }
    public void Update()
    {
        if(childScr != null)
        {
            if (Door.done)
            {
                ChangeState();
            }
        }
        else
        {
            if(Door.done)
            {
                StartCoroutine(Door.WaitFade());
            }
        }
    }
    private void ChangeState()
    {
        for (int i = 0; i < childScr.Length; i++)
        {
            childScr[i].SetFindPlayerAll();
        }
    }
}
