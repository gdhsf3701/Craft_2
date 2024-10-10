using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Agent
{

    public UnityEvent FinalDeadEvent;
    public PlayerStateMachine stateMachine;

    [Header("Normal Attack")] 
    [SerializeField] private int _damage;

    [SerializeField] private float _knockPower;

    public bool isRun = false;
    
    public List<PlayerDamageSO> damageDataList;
    public UnityEvent JumpEvent;
    public PlayerDamageSO damageData;
    [field: SerializeField] public InputReader PlayerInput { get; private set; }
    public float attackCoolDown;

    [SerializeField]
    private PlayerDamageSO _skill1;
    [SerializeField]
    private PlayerDamageSO _skill2;

    public SoundSO _fallSound;
    
    public int comboCount= 0;
    private int _skillCount=0;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine(); 
        
        stateMachine.AddState(PlayerEnum.Idle,new PlayerIdleState(this,stateMachine,"Idle"));
        stateMachine.AddState(PlayerEnum.Walk,new PlayerWalkState(this,stateMachine,"Walk"));
        stateMachine.AddState(PlayerEnum.Run,new PlayerRunState(this,stateMachine,"Run"));
        stateMachine.AddState(PlayerEnum.Jump,new PlayerJumpState(this,stateMachine,"Jump"));
        stateMachine.AddState(PlayerEnum.Fall,new PlayerFallState(this,stateMachine,"Fall"));
        stateMachine.AddState(PlayerEnum.Attack1,new PlayerAttack1State(this,stateMachine,"Attack1"));
        stateMachine.AddState(PlayerEnum.Attack2,new PlayerAttack2State(this,stateMachine,"Attack2"));
        stateMachine.AddState(PlayerEnum.Attack3,new PlayerAttack3State(this,stateMachine,"Attack3"));
        stateMachine.AddState(PlayerEnum.Hit,new PlayerHitState(this,stateMachine,"Hit"));
        stateMachine.AddState(PlayerEnum.Wire,new PlayerWireState(this,stateMachine,"Wire"));
        stateMachine.AddState(PlayerEnum.Kick,new PlayerSkillState(this,stateMachine,"Kick"));
        stateMachine.AddState(PlayerEnum.Knife,new PlayerSkillState(this,stateMachine,"Knife"));
        stateMachine.AddState(PlayerEnum.Dead,new PlayerDeadState(this,stateMachine,"Dead"));
        stateMachine.Initialize(PlayerEnum.Fall, this);
        
        
        PlayerInput.OnJumpKeyEvent += HandleJumpKeyEvent;
        PlayerInput.OnKickKeyEvent += HandleKickKeyEvent;
        PlayerInput.OnKnifeKeyEvent += HandleKnifeKeyEvent;
        PlayerInput.OnRunKeyHoldEvent += HandleRunKeyEvnet;
        PlayerInput.OnRunKeyReleasedEvent += HandleCancleRunEvent;
    }

    private void Start()
    {
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();
    }

    private void HandleCancleRunEvent()
    {
        MovementCompo.moveSpeed = 7f;
        isRun = false;
    }

    private void HandleRunKeyEvnet()
    {
        MovementCompo.moveSpeed = 10f;
        isRun = true;
    }

    private void HandleKnifeKeyEvent()
    {
        if (SkillManager.Instance.GetSkill<KnifeSkill>().AttemptUseSkill())
        {
            damageData = _skill1;
            Attack();
            _skillCount = 1;
            stateMachine.ChangeState(PlayerEnum.Knife);
        }
    }

    private void HandleKickKeyEvent()
    {
        if (SkillManager.Instance.GetSkill<KickSkill>().AttemptUseSkill())
        {
            damageData = _skill2;
            Attack();
            _skillCount = 2;
            stateMachine.ChangeState(PlayerEnum.Kick);
        }
    }
    
    
    private void OnDestroy()
    {
        PlayerInput.OnJumpKeyEvent -= HandleJumpKeyEvent;
        PlayerInput.OnKickKeyEvent -= HandleKickKeyEvent;
        PlayerInput.OnKnifeKeyEvent -= HandleKnifeKeyEvent;
        PlayerInput.OnRunKeyHoldEvent -= HandleRunKeyEvnet;
        PlayerInput.OnRunKeyReleasedEvent -= HandleCancleRunEvent;
    }

    public void AttackSetting()
    {
        damageData = damageDataList[comboCount];
        
        attackCoolDown = 0;
        
        Attack();

        CastDamage();
        
        comboCount++;
    }

    private void Attack()
    {
        DamageCasterCompo.transform.localPosition = damageData.damagePos;
        DamageCasterCompo.damageRadius = damageData.damageRadius;

        _damage = damageData.damage;
        _knockPower = damageData.knockPower;
    }

    public void CastDamage()
    {
        bool suc = DamageCasterCompo.CastDamage(_damage, _knockPower);
        
        SoundSO sound = damageData.AttackSound(suc);
        
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        soundPlayer.PlaySound(sound);
        _skillCount = 0;
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
        PlayerInput.OnAttackKeyEvent = null;
    }
    
    public void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationEndTrigger();
    }

    public void SetWalkSound(SoundSO right, SoundSO left)
    {
        transform.Find("Visual").GetComponent<PlayerAnimationEndTrigger>().SetWalkSound(right, left);
    }
}
