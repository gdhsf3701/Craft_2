using UnityEngine;

public class KnifeSpotPlayerState : EnemyState
{
    public KnifeSpotPlayerState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();

        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        if (dis > _enemy.attackRadius - 5)
        {
            _stateMachine.ChangeState(EnemyEnum.SpotPlayer);
            return;
        }
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));
        if (_enemy.attackRadius - 8 > dis && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            _stateMachine.ChangeState(EnemyEnum.Attack1);
        }
    }
}