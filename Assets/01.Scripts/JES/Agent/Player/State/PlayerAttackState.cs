using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        SkillCoolUI.Instance.ComboImageSetUp();
    }



    public override void Exit()
    {
        SkillCoolUI.Instance.ComboCooldown();
        _player.PlayerInput._controls.Enable();
        _player.lastAttackTime = Time.time;
        base.Exit();
    }
}
