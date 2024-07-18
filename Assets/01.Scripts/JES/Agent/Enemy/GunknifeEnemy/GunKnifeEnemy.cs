using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyEnum
{
    Idle,
    Chase,
    Fire,
    KnifeChase,
    Attack,
    Dead
}
public class GunKnifeEnemy : Enemy, Ipoolable
{
    public EnemyStateMachine stateMachine;
    [SerializeField] private string _poolName = "GunKnifeEnemy";

    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    
    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();

        stateMachine.AddState(EnemyEnum.Idle,new GunIdleState(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyEnum.Chase,new GunChaseState(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyEnum.Fire,new GunFireState(this, stateMachine, "Fire"));
        stateMachine.AddState(EnemyEnum.Dead,new GunDeadState(this, stateMachine, "Dead"));
        stateMachine.AddState(EnemyEnum.KnifeChase,new GunKnifeChaseState(this, stateMachine, "KnifeChase"));
        stateMachine.AddState(EnemyEnum.Attack,new GunAttackState(this, stateMachine, "Attack"));

        stateMachine.Initalize(EnemyEnum.Idle,this);

    }

    private void Update()
    {
        stateMachine.CurrentState.UpdateState(); // 현재 상태의 업데이트 우선 실행

        if (targerTrm != null && IsDead == false)
        {
            HandleSpriteFlip(targerTrm.position);
        }
    }
    public override void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }

    public override void SetDeadState()
    {
        stateMachine.ChangeState(EnemyEnum.Dead);
    }

    public void ResetItem() //죽은 후 다시 소환될때
    {
        CanStateChangeable = true; // 상태를 변경 할 수 있는지, 아닌지
        IsDead = false; // 죽었는지 아닌지
        targerTrm = null; // 타겟 트랜스폼 초기화
        HealthCompo.ResetHealth(); // 체력 초기화
        stateMachine.ChangeState(EnemyEnum.Idle); // idle 상태로 바꾸기
        gameObject.layer = _enemyLayer; // 레이어 에너미 레이어로 바꾸기
    }
}
