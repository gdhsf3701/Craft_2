using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetTimer : Action
{
    public SharedFloat targetTime;

    public override void OnStart()
    {
        targetTime.Value = Time.time;
    }
}
