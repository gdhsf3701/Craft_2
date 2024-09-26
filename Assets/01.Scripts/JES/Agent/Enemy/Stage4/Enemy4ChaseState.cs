using UnityEngine;

public class Enemy4ChaseState : EnemyState
{
    public Enemy4ChaseState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    
    public override void UpdateState()
    {
        base.UpdateState();

        Vector2 dir = (_enemy.targerTrm.position - _enemy.transform.position);
        float dis = dir.magnitude;
        if (dis <= _enemy.attackRadius)
        {
            if(_enemy.lastAttackTime+_enemy.attackCooldown<Time.time){}
                _stateMachine.ChangeState(EnemyEnum.Attack1);
        }
        _enemy.MovementCompo.SetMoveMent(Mathf.Sign(dir.x));
    }
}