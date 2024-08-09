using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{
    public EnemyStateMachine stateMachine;
    public int faseNum=1;

    [Header("Fase2 Setting")]
    [SerializeField] private int _coolTime; 
    protected override void Awake()
    {
        base.Awake();
        
        stateMachine.AddState(EnemyEnum.Chase,new Boss1ChaseState(this,stateMachine,"Chasae"));
        stateMachine.AddState(EnemyEnum.Attack1, new Boss1Attack1State(this,stateMachine,"Attack1"));
    }

    private void Start()
    {
        targerTrm = PlayerManager.Instance.PlayerTrm;
    }

    public void FaseNumSet()
    {
        if(faseNum>1) return;
        
        if (HealthCompo.CurrentHealth <= 600)
        {
            faseNum = 2;
            attackCooldown = _coolTime;
            
        }
    }
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
