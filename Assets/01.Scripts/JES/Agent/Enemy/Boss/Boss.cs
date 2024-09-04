using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public EnemyStateMachine stateMachine;
    public int faseNum=1;
    public int fase2Hp;
    public SpriteRenderer spriteRen;
    public EnemyVFX VFXCompo;
    
        
    [Header("Fase2 Setting")]
    [SerializeField] private int _coolTime; 
    private void Start()
    {
        targerTrm = PlayerManager.Instance.PlayerTrm;
    }

    protected override void Awake()
    {
        base.Awake();

        spriteRen = transform.Find("Visual").GetComponent<SpriteRenderer>();
        VFXCompo = transform.Find("EnemyVFX").GetComponent<EnemyVFX>();
        VFXCompo.Initalize(this);
    }

    public void FaseNumSet()
    {
        if(faseNum>1) return;
        
        if (HealthCompo.CurrentHealth <= fase2Hp)
        {
            faseNum = 2;
            attackCooldown = _coolTime;
        }
    }
    public virtual void Update()
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
