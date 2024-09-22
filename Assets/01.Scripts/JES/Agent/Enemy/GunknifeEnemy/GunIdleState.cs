using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        if ((_enemy as GunKnifeEnemy).SpotPlayer)
        {
            _stateMachine.ChangeState(EnemyEnum.SpotPlayer);
        }
        Collider2D player = _enemy.GetPlayerInRange();
        if (player == null)
        {
            return;
        }
        else if(player != null)
        {
            _enemy.targerTrm = player.transform;
        }
        
        if (_enemy.targerTrm != null)
        {
            Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
            float dis = dir.magnitude;

            if (_enemy.attackRadius - 8 > dis)
            {
                if (_enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
                {
                    _stateMachine.ChangeState(EnemyEnum.Attack1);
                    return;
                }
                return;
            }

            if (_enemy.attackRadius - 5 > dis)
            {
                _stateMachine.ChangeState(EnemyEnum.Chase);
                return;
            }
            if (_enemy.attackRadius > dis)
            {
                if (_enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
                {
                    _stateMachine.ChangeState(EnemyEnum.Fire);
                    return;
                }
                return;
            }
            _stateMachine.ChangeState(EnemyEnum.Chase);
        }
    }
}
