using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BossMovement : MonoBehaviour, IBossComponent
{
    public event Action<Vector2> VelocityChangeEvnet;
    
    private Boss _enemy;
    private Rigidbody2D _rbCompo;

    private Vector2 _velocity;
    public void Initialize(Boss enemy)
    {
        _enemy = enemy;
        _rbCompo = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 velocity)
    {
        _velocity = new Vector2(velocity.x,_rbCompo.velocity.y);
        VelocityChangeEvnet?.Invoke(_velocity);

        FlipCheck();
    }

    private void FlipCheck()
    {
        bool isFlipToLeft = _velocity.x > 0&& _enemy.IsFacingRight==false;
        bool isFlipToRight = _velocity.x<0 && _enemy.IsFacingRight;
        
        if(isFlipToRight||isFlipToLeft)
            _enemy.Flip();
    }

    private void FixedUpdate()
    {
        _rbCompo.velocity = _velocity;
    }
}
