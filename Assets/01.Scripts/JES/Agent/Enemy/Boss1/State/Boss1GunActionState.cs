public class Boss1GunActionState : EnemyState
{
    public Boss1GunActionState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
        
        if(_endTriggerCalled)
            _stateMachine.ChangeState(EnemyEnum.Chase);
    }
}
