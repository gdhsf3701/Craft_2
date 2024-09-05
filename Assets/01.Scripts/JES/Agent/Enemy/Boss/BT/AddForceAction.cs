using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class AddForceAction : Action
{
    public SharedEnemy _boss;
    public float force;

    public override void OnStart()
    {
        _boss.Value.GetCompo<BossMovement>().MoveAddForce(transform.right,force);
    }
}
