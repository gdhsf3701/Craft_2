using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GageGameUI : MonoBehaviour
{
    private Tween _tween;
    private Image _barImage;
    private  bool Fail = false;
    [SerializeField]Stage3EnemyManager[] _enemyManagers;
    GameObject nowEnemy;
    bool done = false;

    private void Awake()
    {
        _barImage=transform.Find("Bar").GetComponent<Image>();
    }
    private void OnEnable()
    {
        if (done && !Fail)
        {
            _tween = _barImage.DOFillAmount(1, 1f).OnComplete(() => FailSeq()).SetUpdate(true);
            Time.timeScale = 0;
        }
        else if (Fail)
        {
            gameObject.SetActive(false);
        }
        done = true;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)&&!Fail) {
            _tween.Kill();
            if(_barImage.fillAmount>=0.594f&& _barImage.fillAmount <= 0.736f)
                ClearSeq();
            else
                FailSeq();
        }
    }   
    public void ChangeNowEnemy(GameObject game)
    {
        nowEnemy = game;
    }
    private void ClearSeq()
    {
        //성공했을때 함수
        Destroy(nowEnemy);
        _barImage.fillAmount = 0;
        gameObject.SetActive(false);
        //_barImage의 초기화
        print("성공");
    }

    private void FailSeq()
    {
        Fail = false;
        foreach(var enemy in _enemyManagers)
        {
            if (enemy.AllDeadCheck())
            {
                break;
            }
        }
        //실패했을때 함수
        gameObject.SetActive(false);
        print("실패");
    }
}
