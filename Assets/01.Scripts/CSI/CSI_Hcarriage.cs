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
    [field:SerializeField]public int NowHP { get; set; }
    private Slider _slider;
    private bool DIe;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _slider.maxValue = MaxHP;
        NowHP = MaxHP;
        _slider.value = MaxHP;
    }

    private void Update()
    {
        _slider.value = NowHP;
        if (!DIe)
        {
            transform.position = Vector3.MoveTowards(transform.position, Goal, Speed * Time.deltaTime);
        }
        if (NowHP <= 0)
        {
            print("HP0");
            Die();            

        }

        if (Vector2.Distance(transform.position, Goal) < 0.4f)
        {
            print("도착");
            Die();
        }
    }

    private void Die()
    {
        if (!DIe)
        {
            DIe = !DIe;
            print("죽음");
            _animator.SetTrigger("Die");
        }
        
    }
    
}
