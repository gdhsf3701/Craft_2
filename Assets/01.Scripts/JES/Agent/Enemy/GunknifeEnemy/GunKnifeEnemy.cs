using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyEnum
{
    Idle,
    Chase,
    Fire,
    KnifeChase,
    Attack1,
    Attack2,
    Dead,
    Skill1,
    Skill2,
    Reload1,
    Reload2,
    Attack21,
    SpotPlayer,
    KnifeSpot,
    Hit
}
public class GunKnifeEnemy : Enemy, Ipoolable
{
    public EnemyStateMachine stateMachine;
    [SerializeField] private string _poolName = "GunKnifeEnemy";

    public Action<GunKnifeEnemy> OnDeathEvent;
    public string PoolName => _poolName;

    public GameObject ObjectPrefab => gameObject;

    public bool SpotPlayer = false;
    public bool Is3Stage = false;
    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();

        stateMachine.AddState(EnemyEnum.Idle,new GunIdleState(this, stateMachine, "Idle"));
        stateMachine.AddState(EnemyEnum.Chase,new GunChaseState(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyEnum.Fire,new GunFireState(this, stateMachine, "Fire"));
        stateMachine.AddState(EnemyEnum.Dead,new GunDeadState(this, stateMachine, "Dead"));
        stateMachine.AddState(EnemyEnum.Attack1,new GunAttackState(this, stateMachine, "Attack"));
        stateMachine.AddState(EnemyEnum.SpotPlayer,new GunSpotPlayerState(this, stateMachine, "Chase"));
        stateMachine.AddState(EnemyEnum.KnifeSpot,new KnifeSpotPlayerState(this, stateMachine, "KnifeChase"));

        stateMachine.Initalize(EnemyEnum.Idle,this);
    }

    public void SetSpotPlayer(Player player)
    {
        targerTrm =player.transform;
        SpotPlayer = true;
    }

    public override Collider2D GetPlayerInRange()
    {
        if (!Is3Stage)
        {
            return base.GetPlayerInRange();
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, detectRadius, contactFilter.layerMask);
        if(hit.collider != null&&_stage3Bool)
            _manager.SpotEvent();
        // 충돌한 콜라이더가 있으면 리턴, 없으면 null 리턴
        return hit.collider != null ? hit.collider : null;  
    }

    private Stage3EnemyManager _manager;
    private bool _stage3Bool;

    public void Initalize(Stage3EnemyManager manager)
    {
        _stage3Bool = true;
        _manager = manager;
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
    
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!Is3Stage)  // 원이 그려지는 조건
        {
            // 조건에 맞을 때 원을 그림
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, attackRadius - 5);
        
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRadius - 8);

            // 추가로 그려지는 원을 없애려면 이 코드를 제거하거나, 조건을 추가
        }
        else
        {
            // Raycast를 그리는 부분
            Gizmos.color = Color.red;

            Vector2 rayOrigin = transform.position;
            Vector2 rayDirection = transform.right;
            float rayLength = detectRadius;

            // Gizmo로 Ray를 그리기
            Gizmos.DrawLine(rayOrigin, rayOrigin + rayDirection * rayLength);
        }
    }
    #endif
}
