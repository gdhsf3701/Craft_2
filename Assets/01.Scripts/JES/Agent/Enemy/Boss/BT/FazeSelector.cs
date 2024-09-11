using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class FazeSelector : Conditional
{
    public int fazeNum;
    
    public SharedInt currentFazeNum;

    public override TaskStatus OnUpdate()
    {
        if (currentFazeNum.Value == fazeNum)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}
