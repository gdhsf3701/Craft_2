using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackState : EnemyState
{
    public GunAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _enemy.MovementCompo.StopImmediately(false);
    }

    public override void Exit()
    {
        _enemy.lastAttackTime = Time.time;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
            _stateMachine.ChangeState(EnemyEnum.KnifeChase);

    }
}
