using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAllCheckState : EnemyState
{
    public EnemyAllCheckState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.StopImmediately(false);
        _enemy.detectRadius = 75;
        
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
