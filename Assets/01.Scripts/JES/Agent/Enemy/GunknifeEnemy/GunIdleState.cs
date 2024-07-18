using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunIdleState : EnemyState
{
    public GunIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.StopImmediately(false);
    }
    public override void UpdateState()
    {
        base.UpdateState();

        Collider2D player = _enemy.GetPlayerInRange();
        if (player != null)
        {
            _enemy.targerTrm = player.transform;
            _stateMachine.ChangeState(EnemyEnum.Chase);
        }
    }
}
