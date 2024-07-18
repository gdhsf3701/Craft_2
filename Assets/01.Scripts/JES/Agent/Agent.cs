using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    #region Component section
    public AgentMovement MovementCompo { get; protected set; }
    public Animator AnimatorCompo { get; protected set; }
    public Health HealthCompo { get; private set; }
    public DamageCaster DamageCasterCompo { get; protected set; }
    #endregion

    public bool IsDead { get; protected set; }

    protected float _timeInAir;
    
    public event Action OnFlipEvent;

    public bool CanStateChangeable { get; protected set; } = true;

    
    [HideInInspector] public float lastAttackTime;
    

    protected virtual void Awake()
    {
        MovementCompo = GetComponent<AgentMovement>();
        MovementCompo.Initialize(this);
        
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();

        HealthCompo = GetComponent<Health>();
        HealthCompo.Initalize(this);
        
        DamageCasterCompo = transform.Find("DamageCaster").GetComponent<DamageCaster>();

    }

    
    public abstract void SetDeadState();

    #region Flip Character
    public bool IsFacingRight()
    {
        return Mathf.Approximately(transform.eulerAngles.y, 0);
    }

    public void HandleSpriteFlip(Vector3 targetPosition)
    {
        bool isRight = IsFacingRight();
        if (targetPosition.x < transform.position.x && isRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
            OnFlipEvent?.Invoke();
        }
        else if (targetPosition.x > transform.position.x && !isRight)
        {
            transform.eulerAngles = Vector3.zero;
            OnFlipEvent?.Invoke();
        }
    }
    #endregion
}
