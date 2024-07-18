using UnityEngine;

public class GunChaseState : EnemyState
{
    public GunChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        if (dis > _enemy.detectRadius + 2)
        {
            _stateMachine.ChangeState(EnemyEnum.Idle);
            return;
        }
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));
        if(_enemy.attackRadius - 5 > dis)
        {
            _stateMachine.ChangeState(EnemyEnum.KnifeChase);
        }
        if (_enemy.attackRadius > dis && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            _stateMachine.ChangeState(EnemyEnum.Fire);
        }
    }
}
