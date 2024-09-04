using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class InConditionTimeCheck : Conditional
{
    public float limitTime;
    public SharedFloat startTime;
 
    public override TaskStatus OnUpdate()
    {
        if(startTime.Value + limitTime < Time.time)
            return TaskStatus.Success;
        
        return TaskStatus.Failure;
    }
}
