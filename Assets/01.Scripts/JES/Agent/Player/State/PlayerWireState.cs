using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWireState : PlayerState
{
    public PlayerWireState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput._controls.Disable();
        _player.MovementCompo.StopImmediately(true);
        _player.MovementCompo.rbCompo.bodyType = RigidbodyType2D.Kinematic;
    }

    public override void Exit()
    {
        _player.MovementCompo.rbCompo.bodyType = RigidbodyType2D.Dynamic;
        _player.PlayerInput._controls.Enable();
        Zipline.isMove = false;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (!Zipline.isMove)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }
}
