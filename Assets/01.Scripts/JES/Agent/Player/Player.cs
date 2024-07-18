using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Player : Agent
{
    
    public PlayerStateMachine stateMachine;

    [Header("Normal Attack")] 
    [SerializeField] private int _damage;

    [SerializeField] private float _knockPower;
    
    
    public List<PlayerDamageSO> damageDataList;
    public UnityEvent JumpEvent;
    public PlayerDamageSO damageData;
    [field: SerializeField] public InputReader PlayerInput { get; private set; }
    public float attackCoolDown;


    public int comboCount= 0;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine(); 
        
        stateMachine.AddState(PlayerEnum.Idle,new PlayerIdleState(this,stateMachine,"Idle"));
        stateMachine.AddState(PlayerEnum.Run,new PlayerRunState(this,stateMachine,"Run"));
        stateMachine.AddState(PlayerEnum.Jump,new PlayerJumpState(this,stateMachine,"Jump"));
        stateMachine.AddState(PlayerEnum.Fall,new PlayerFallState(this,stateMachine,"Fall"));
        stateMachine.AddState(PlayerEnum.Attack1,new PlayerAttack1State(this,stateMachine,"Attack1"));
        stateMachine.AddState(PlayerEnum.Attack2,new PlayerAttack2State(this,stateMachine,"Attack2"));
        stateMachine.AddState(PlayerEnum.Attack3,new PlayerAttack3State(this,stateMachine,"Attack3"));
        stateMachine.AddState(PlayerEnum.Hit,new PlayerHitState(this,stateMachine,"Hit"));
        stateMachine.AddState(PlayerEnum.Wire,new PlayerWireState(this,stateMachine,"Wire"));
        
        stateMachine.Initialize(PlayerEnum.Idle, this);
        
        PlayerInput.OnJumpKeyEvent += HandleJumpKeyEvent;
    }

    private void OnDestroy()
    {
        PlayerInput.OnJumpKeyEvent -= HandleJumpKeyEvent;
    }

    public void Attack()
    {
        damageData = damageDataList[comboCount];
        
        attackCoolDown = 0;
        
        DamageCasterCompo.transform.localPosition = damageData.damagePos;
        DamageCasterCompo.damageRadius = damageData.damageRadius;

        _damage = damageData.damage;
        _knockPower = damageData.knockPower;
        DamageCasterCompo.CastDamage(_damage, _knockPower);
        
        comboCount++;
    }
    private void HandleJumpKeyEvent()
    {
        if (MovementCompo.isGround.Value)
            JumpProcess();
    }

    public void HitStateChange()
    {
        stateMachine.ChangeState(PlayerEnum.Hit);
    }
    
    private void Update()
    {
        stateMachine.CurrentState.UpdateState();
        
        float x = PlayerInput.Movement.x;
        SpriteFlip(x);
        MovementCompo.SetMoveMent(x);

        if (Input.GetKeyDown(KeyCode.P))
        {
            HealthCompo.TakeDamage(1,Vector2.zero, Vector2.zero, 1);
        }
    }

    public void SpriteFlip(float x)
    {
        bool isRight = IsFacingRight();
        if (x < 0 && isRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
        else if (x> 0 && !isRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
    
    public void JumpProcess()
    {
        JumpEvent?.Invoke();
        MovementCompo.Jump();
    }

    public override void SetDeadState()
    {
        stateMachine.ChangeState(PlayerEnum.Dead);
    }
    
    public void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }
}
