using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{
    public EnemyStateMachine stateMachine;


    private void Update()
    {
        stateMachine.CurrentState.UpdateState(); // 현재 상태의 업데이트 우선 실행

        if (targerTrm != null && IsDead == false)
        {
            HandleSpriteFlip(targerTrm.position);
        }
    }
    

    public override void SetDeadState()
    {
        stateMachine.ChangeState(EnemyEnum.Dead);
    }

    public override void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }
}
