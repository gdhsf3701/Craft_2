using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour, IBossComponent
{
    private Boss _enemy;
    private BossMovement _movement;
    
    public event Action<int> AttackStartEvent;
    public void Initialize(Boss enemy)
    {
        _enemy = enemy;
        _movement = _enemy.GetCompo<BossMovement>();
    }

    public void SlashAttack()
    {
        AttackStartEvent?.Invoke(0);
        _movement.SetVelocity(Vector2.zero);
    }

    public void DashAttack()
    {
        AttackStartEvent?.Invoke(1);
        _movement.SetVelocity(Vector2.zero);
    }
}
