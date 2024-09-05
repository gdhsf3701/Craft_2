using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public enum AttackType
{
    Normal = 0, Skill = 1,LGunAtk=2,RGunAtk=3,GunSkill=4
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
        switch (atkType)
        {
            case AttackType.Normal:
                _atkCompo.NormalAttack();
                break;
            case AttackType.Skill:
                _atkCompo.SkillAttack();
                break;
            case AttackType.LGunAtk:
                _atkCompo.LeftGunAttack();
                break;
            case AttackType.RGunAtk:
                _atkCompo.RightGunAttack();
                break;
            case AttackType.GunSkill:
                _atkCompo.GunSkillAttack();
                break;
        }
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
