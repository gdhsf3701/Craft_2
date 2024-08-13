using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Boss
{
    public float SpreadAngle=15f;
    
    
    private Stack<SawedOff> guns = new Stack<SawedOff>();
    private SawedOff currentGun = null;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();            
        
        stateMachine.AddState(EnemyEnum.Chase,new Boss1ChaseState(this,stateMachine,"Chase"));
        stateMachine.AddState(EnemyEnum.Attack1, new Boss1Attack1State(this,stateMachine,"Attack1"));
        stateMachine.AddState(EnemyEnum.Attack2, new Boss1Attack2State(this,stateMachine,"Attack2"));
        
        stateMachine.Initalize(EnemyEnum.Chase,this);

        for (int i = 0; i < 2; i++)
        {
            guns.Push(new SawedOff());
        }
        currentGun = guns.Pop();
    }

    public override void FireBullet()
    {
        
    }
}
