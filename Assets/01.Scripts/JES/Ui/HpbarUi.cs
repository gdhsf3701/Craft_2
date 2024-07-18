using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HpbarUi : MonoBehaviour
{
    [SerializeField]
    private Sprite onCandle, offCandle;

    private Stack<Image> onCandleList = new Stack<Image>();
    private Stack<Image> offCandleList = new Stack<Image>();
    
    private void Awake()
    {
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            onCandleList.Push(image);
        }
    }

    private void Start()
    {
        for (int i = 4; i > SaveManager.Instance.saveData.playerHp; i--)
        {
            HitEvent();
        } 
    }

    public void HitEvent()
    {
        Image candle = onCandleList.Pop();
        candle.sprite = offCandle;
        offCandleList.Push(candle);
    }

    public void HealingEvent()
    {
        Image candle = offCandleList.Pop();
        candle.sprite = onCandle;
        onCandleList.Push(candle);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            HealingEvent();
        }
    }
}
