using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.StopImmediately(false);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_player.PlayerInput.Movement.magnitude > 0)
        {
            _stateMachine.ChangeState(PlayerEnum.Run);
        }
    }
}
