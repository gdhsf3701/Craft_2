using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Enemy : Enemy, Ipoolable
{
    [SerializeField] private string _poolName = "Stage4Enemy";
    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;
    
    public EnemyStateMachine stateMachine;

    private Action deadEvent;
    protected override void Awake()
    {
        base.Awake();
        
        stateMachine = new EnemyStateMachine();
    
        stateMachine.AddState(EnemyEnum.Chase,new Enemy4ChaseState(this,stateMachine,"Chase"));
        stateMachine.AddState(EnemyEnum.Attack1,new GunAttackState(this,stateMachine,"Attack"));
        stateMachine.AddState(EnemyEnum.Dead,new GunDeadState(this,stateMachine,"Dead"));
        stateMachine.Initalize(EnemyEnum.Chase,this);
    }

    public void Inialize(Transform targetTrm, Action action)
    {
        targerTrm = targetTrm;
        deadEvent = action;
    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
        
        if (targerTrm != null && IsDead == false)
        {
            HandleSpriteFlip(targerTrm.position);
        }
    }

    public override void SetDeadState()
    {
        deadEvent?.Invoke();
        stateMachine.ChangeState(EnemyEnum.Dead);
    }
    public override void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }
    public void ResetItem()
    {
        CanStateChangeable = true; // 상태를 변경 할 수 있는지, 아닌지
        IsDead = false; // 죽었는지 아닌지
        targerTrm = null; // 타겟 트랜스폼 초기화
        HealthCompo.ResetHealth(); // 체력 초기화
        stateMachine.ChangeState(EnemyEnum.Chase); // idle 상태로 바꾸기
        gameObject.layer = _enemyLayer; // 레이어 에너미 레이어로 바꾸기
    }
}
