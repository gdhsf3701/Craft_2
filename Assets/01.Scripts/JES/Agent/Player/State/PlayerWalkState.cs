public class PlayerWalkState : PlayerGroundState
{
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Exit()
    {
        _player.MovementCompo.StopImmediately(false);
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_player.PlayerInput.Movement.magnitude <=0)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
        if (_player.isRun)
        {
            _stateMachine.ChangeState(PlayerEnum.Run);
        }
    }
}