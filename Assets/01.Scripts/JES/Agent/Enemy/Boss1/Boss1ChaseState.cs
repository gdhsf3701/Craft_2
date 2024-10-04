using UnityEngine;

public class Boss1ChaseState : EnemyState
{
    public Boss1ChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        
        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));
        if (_enemy.attackRadius > dis && _enemy.lastAttackTime + _enemy.attackCooldown < Time.time)
        {
            if (((Boss1)_enemy).faseNum==1)
            {
                _stateMachine.ChangeState(EnemyEnum.Attack1);
            }
            else
            {
                _stateMachine.ChangeState(EnemyEnum.Attack2);
            }
        }
    }
}