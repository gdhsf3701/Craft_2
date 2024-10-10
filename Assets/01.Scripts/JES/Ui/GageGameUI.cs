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
    [SerializeField]Stage3EnemyManager _enemyManager;
    [SerializeField] GameObject _timeline;
    [SerializeField] GameObject Enermy_Group;
    [SerializeField]GameObject killedEnemy;
    bool done = false;

    private void Awake()
    {
        _barImage=transform.Find("Bar").GetComponent<Image>();
    }
    private void OnEnable()
    {
        _barImage.fillAmount = 0;
        if (done && !Fail)
        {
            _tween = _barImage.DOFillAmount(1, 1.5f).SetEase(Ease.Linear).OnComplete(() => FailSeq()).SetUpdate(true);
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
            if(_barImage.fillAmount>= 0.587f&& _barImage.fillAmount <= 0.736f)
                ClearSeq();
            else
                FailSeq();
        }
    }   
    private void ClearSeq()
    {
        _timeline.SetActive(true);
        Enermy_Group.SetActive(false);
        _barImage.fillAmount = 0;
        Time.timeScale = 1;
        gameObject.SetActive(false);
        //_barImage�� �ʱ�ȭ
        print("����");

        
    }
    public void DestroyEnemy()
    {
        Destroy(killedEnemy);
    }


    private void FailSeq()
    {
        Fail = false;
        _enemyManager.AllDeadCheck();
        Time.timeScale = 1;
        gameObject.SetActive(false);
        print("����");
    }
}
