using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately();
        _player.gameObject.layer = LayerMask.NameToLayer("DeadBody");
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_endTriggerCalled)
        {
            _player.FinalDeadEvent?.Invoke();
        }
    }
}