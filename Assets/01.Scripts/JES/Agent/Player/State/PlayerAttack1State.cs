using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1State : PlayerAttackState
{
    public PlayerAttack1State(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }
    public override void Exit()
    {
        base.Exit();
        SkillCoolUI.Instance.NormalAttackSprite(1);
    }
}
