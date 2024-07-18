using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void UpdateState()
    {
        base.UpdateState();

        if (_player.MovementCompo.rbCompo.velocity.y < 0)
        {
            _stateMachine.ChangeState(PlayerEnum.Fall);
        }
    }
}
