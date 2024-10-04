using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ReloadAction : Action
{
    public SharedGun gun;
    
    public int gunIndex;
    public SharedEnemy boss;
    
    private float enterTime;
    public float reloadTime;

    public override void OnStart()
    {
        enterTime = Time.time;
        gun.Value.Reload();
        boss.Value.GetCompo<BossAnimator>().ReloadAnimation(gunIndex);
    }

    public override TaskStatus OnUpdate()
    {
        if (Time.time > enterTime + reloadTime)
            return TaskStatus.Success;
        
        return TaskStatus.Running;
    }
}
