using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plr_move : MonoBehaviour
{
    private Rigidbody2D rb2d;
    float moveSpeed = 5f;
    SpriteRenderer sr;

    Animator animator;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        sr.flipX = moveHorizontal < 0;

        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.velocity = movement * moveSpeed;
        
        if (animator != null)
        {
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }
}