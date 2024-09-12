public class PlayerWalkState : PlayerMoveState
{
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_player.isRun)
        {
            _stateMachine.ChangeState(PlayerEnum.Run);
        }
    }
}