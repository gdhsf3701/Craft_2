using BehaviorDesigner.Runtime.Tasks.Unity.UnityTransform;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class ChangeEnemyState : MonoBehaviour
{
    [SerializeField]GunKnifeEnemy[] childScr;
    [SerializeField]Stage3_Door Door;

    private void Awake()
    {
        childScr = GetComponentsInChildren<GunKnifeEnemy>();
    }
    public void Update()
    {
        if (childScr != null)
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
