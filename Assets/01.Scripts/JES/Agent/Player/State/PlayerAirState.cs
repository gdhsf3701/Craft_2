using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerDefaultState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _player.MovementCompo.isGround.OnValueChanged += HandleGroundChange;
    }
    
    private void HandleGroundChange(bool prev, bool next)
    {
        if(next)
        {
            _stateMachine.ChangeState(PlayerEnum.Idle);
        }
    }
    
    public override void Exit()
    {
        _player.MovementCompo.isGround.OnValueChanged -= HandleGroundChange;
        base.Exit();
    }
}
