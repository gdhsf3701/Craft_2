using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckReload : Conditional
{
    public SharedGun gun;

    public override TaskStatus OnUpdate()//장전해야되면 성공 아니면 실패
    {
        if(gun.Value.ReloadCheck())
            return TaskStatus.Success;
        
        return TaskStatus.Failure;
    }
}
