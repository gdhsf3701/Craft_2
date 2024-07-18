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
    public int NowHP { get; set; }
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
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
        transform.position = Vector3.MoveTowards(transform.position, Goal, Speed * Time.deltaTime);
        if (NowHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print("죽음");

    }
    
}
