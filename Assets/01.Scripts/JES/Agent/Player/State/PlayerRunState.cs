using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerMoveState
{
    public PlayerRunState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }


    public override void UpdateState()
    {
        base.UpdateState();
        if (!_player.isRun)
        {
            _stateMachine.ChangeState(PlayerEnum.Walk);
        }
    }
}
