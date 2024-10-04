public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
    }
}