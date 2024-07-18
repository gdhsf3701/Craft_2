using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageGameUI : MonoBehaviour
{
    private Tween _tween;
    private Image _barImage;

    private void Awake()
    {
        _barImage=transform.Find("Bar").GetComponent<Image>();
    }

    private void Start()
    {
        _tween = _barImage.DOFillAmount(1, 1f).OnComplete(() => FailSeq());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            _tween.Kill();
            if(_barImage.fillAmount>=0.594f&& _barImage.fillAmount <= 0.736f)
                ClearSeq();
            else
                FailSeq();
        }
    }
    private void ClearSeq()
    {
        //실패했을때 함수
        print("성공");
    }

    private void FailSeq()
    {
        //실패했을때 함수
        print("실패");
    }
}
