using UnityEngine;

public class Boss1Attack2State : EnemyState
{
    public Boss1Attack2State(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        
        ((Boss1)_enemy).VFXCompo.ToggleAfterImage(true);
        _enemy.MovementCompo.StopImmediately(false);
            _enemy.FireBullet();
    }

    public override void Exit()
    {
        ((Boss1)_enemy).VFXCompo.ToggleAfterImage(false);
        _enemy.lastAttackTime = Time.time;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
            _stateMachine.ChangeState(EnemyEnum.Chase);
    }
}