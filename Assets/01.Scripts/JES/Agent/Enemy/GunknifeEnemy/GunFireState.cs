using UnityEngine;

public class GunFireState : EnemyState
{

    float timer = 0;
    public GunFireState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.MovementCompo.StopImmediately(false);
        timer = 0;
        _enemy.FireBullet();
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
        {
            timer += Time.deltaTime;
            if (timer > 0.3f)
            {
                _stateMachine.ChangeState(EnemyEnum.Chase);
            }
        }
    }
}
