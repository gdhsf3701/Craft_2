using UnityEngine;

public class GunSpotPlayerState : EnemyState
{
    public GunSpotPlayerState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    
    public override void UpdateState()
    {
        base.UpdateState();

        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));
        if(_enemy.attackRadius - 5 > dis)
        {
            _stateMachine.ChangeState(EnemyEnum.Chase);
        }
        if (_enemy.attackRadius > dis && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            _stateMachine.ChangeState(EnemyEnum.Fire);
        }
    }
}