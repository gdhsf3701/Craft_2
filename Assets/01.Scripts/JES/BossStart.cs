using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class BossStart : MonoSingleton<BossStart>
{
    [SerializeField] private Animator animator;
    [SerializeField] private BehaviorTree behaviorTree;

    public void OnBoss()
    {
        animator.enabled = true;
        behaviorTree.enabled = true;
    }
    public void OffBoss()
    {
        animator.enabled = false;
        behaviorTree.enabled = false;
    }
}
