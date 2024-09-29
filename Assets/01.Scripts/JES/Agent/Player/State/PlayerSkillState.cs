public class PlayerSkillState : PlayerState
{
    public PlayerSkillState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();
        _player.MovementCompo.StopImmediately(false);
        if(_endTriggerCalled)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput._controls.Disable();
        _player.MovementCompo.StopImmediately(false);
    }
    
    public override void Exit()
    {
        _player.PlayerInput._controls.Enable();
        base.Exit();
    }
    
}