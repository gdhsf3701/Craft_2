using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSI_Hcarriage : MonoBehaviour
{
    
    [SerializeField]private Vector2 Goal;
    [SerializeField] private float Speed;
    [SerializeField] private int MaxHP;
    private Animator _animator;
    private Slider _slider;
    private bool DIe;
    private Health Hp;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _animator = GetComponent<Animator>();
        Hp = GetComponent<Health>();
    }

    private void Start()
    {
        _slider.maxValue = 300;
        _slider.value = 300;
    }

    private void Update()
    {
        _slider.value = 300;
        if (!DIe)
        {
            transform.position = Vector3.MoveTowards(transform.position, Goal, Speed * Time.deltaTime);
        }
    

        if (Vector2.Distance(transform.position, Goal) < 0.4f)
        {
            Die();
        }
    }

    public void Die()
    {
        if (!DIe)
        {
            DIe = !DIe;
            print("죽음");
            _animator.SetTrigger("Die");
        }
        
    }
    
}
