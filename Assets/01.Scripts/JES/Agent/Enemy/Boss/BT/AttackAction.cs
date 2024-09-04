using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public enum AttackType
{
    Normal = 0, Skill = 1
} 
public class AttackAction : Action
{
    public SharedEnemy enemy;
    public AttackType atkType;
    public SharedBool animTrigger;

    private BossAttack _atkCompo;
    public override void OnAwake()
    {
        _atkCompo = enemy.Value.GetCompo<BossAttack>();
    }

    public override void OnStart()
    {
        if(atkType==AttackType.Normal)
            _atkCompo.SlashAttack();
        else if(atkType==AttackType.Skill)
            _atkCompo.DashAttack();
        
        animTrigger.Value = false;
    }

    public override TaskStatus OnUpdate()
    {
        if(animTrigger.Value)
            return TaskStatus.Success;
        else
            return TaskStatus.Running;
    }
}
