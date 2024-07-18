using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : PlayerAttackState
{
    public PlayerAttack3State(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0.3f;
        SkillCoolUI.Instance.NormalAttackSprite(0);
    }

    public override void Exit()
    {
        Time.timeScale = 1f;
        base.Exit();
        SkillCoolUI.Instance.ComboImageSetUp();
        _player.lastAttackTime -= 0.7f;
    }
}
