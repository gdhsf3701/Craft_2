using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SturnAction : Action
{
    public float strunTime;
    public SharedEnemy _boss;
    private float EnterTime;

    public override void OnStart()
    {
        EnterTime = 0;
        _boss.Value.GetCompo<BossAnimator>().SturnAnimStart();
    }

    public override TaskStatus OnUpdate()
    {
        EnterTime += Time.deltaTime;
        if(EnterTime >= strunTime)
            return TaskStatus.Success;
        return TaskStatus.Running;
    }
}
