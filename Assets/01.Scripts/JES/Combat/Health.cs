using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityEvent OnHitEvent;
    public UnityEvent OnDeadEvent;

    [SerializeField] private int _maxHealth = 150;

    private int _currentHealth;
    private Agent _owner;
    

    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
    }

    public void Initalize(Agent owner)
    {
        _owner = owner;
    }

    private void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount, Vector2 normal, Vector2 point, float knockbackPower)
    {
        _currentHealth -= amount;
        if(_currentHealth <= 0)
        {
            OnDeadEvent?.Invoke();
            return;
        }
        OnHitEvent?.Invoke();

        if(knockbackPower > 0&&_owner!=null)
            _owner.MovementCompo.GetKnockback(normal * -1, knockbackPower);
    }

    public void NoEventHit(int damage)
    {
        _currentHealth -= damage;
        
        if(_currentHealth <= 0)
        {
            OnDeadEvent?.Invoke();
        }
    }
}
