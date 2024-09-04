using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Boss
{
    public float SpreadAngle=15f;

    public List<Boss1DataSO> gundatas;
    public Boss1DataSO gunData;
    
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();            
        
        stateMachine.AddState(EnemyEnum.Chase,new Boss1ChaseState(this,stateMachine,"Chase"));
        stateMachine.AddState(EnemyEnum.Attack1, new Boss1Attack1State(this,stateMachine,"Attack1"));
        stateMachine.AddState(EnemyEnum.Skill1, new Boss1Skill1State(this,stateMachine,"Skill1"));
        stateMachine.AddState(EnemyEnum.Attack2, new Boss1GunAttack1State(this,stateMachine,"Attack2"));
        stateMachine.AddState(EnemyEnum.Attack21, new Boss1GunAttack2State(this,stateMachine,"Attack21"));
        stateMachine.AddState(EnemyEnum.Reload1, new Boss1Reload1State(this,stateMachine,"Reload1"));
        stateMachine.AddState(EnemyEnum.Reload2, new Boss1Reload2State(this,stateMachine,"Reload2"));
        
        stateMachine.Initalize(EnemyEnum.Chase,this);

        gunData = gundatas[0];
    }

    public override void FireBullet()
    {
        gunData.gun.ShootGun(muzzleTrm);
        gunData = gundatas[gunData.nextGunIndex];
        muzzleTrm.position = gunData.muzzlePos;
    }
}
