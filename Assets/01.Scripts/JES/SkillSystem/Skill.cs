using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public delegate void CooldownInfoEvent(float current, float total);
public abstract class Skill : MonoBehaviour
{
    public bool skillEnabled = false;
    [SerializeField] protected float _coolDown;
    protected float _cooldownTimer;
    protected Player _player;

    public bool IsCooldown => _cooldownTimer > 0f;
    public event CooldownInfoEvent OnCooldownEvent;

    public virtual void Initialize(Player player)
    {
        _player = player;
    }

    protected void Update()
    {
        if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;

            if (_cooldownTimer <= 0)
            {
                _cooldownTimer = 0;
            }
            OnCooldownEvent?.Invoke(_cooldownTimer,_coolDown);
        }
    }

    public virtual bool AttemptUseSkill()
    {
        if (_cooldownTimer <= 0 && skillEnabled)
        {
            _cooldownTimer = _coolDown;
            UseSkill();
            return true;
        }
        Debug.Log("Skill cooldown or locked");
        return false;
    }

    protected virtual void UseSkill()
    {
        
    }
}
