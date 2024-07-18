using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMove : MonoBehaviour
{
    bool noOpen = true;

    float closeBorderLeftX = -110;
    float closeBorderRightX = 114;
    
    float openBorderLeftX = -820;
    float openBorderRightX = 829;

    [SerializeField]
    private GameObject SettingPanel;

    [SerializeField]
    private RectTransform SettingBorderLeft,SettingBorderRight, SettingBack;

    
    private void Awake()
    {
        SettingPanel.SetActive(false);
        SettingBack.localScale = new Vector3(1,8,0);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOffSetting();
        }
    }

    public void OnOffSetting()
    {
        DOTween.KillAll();
        if (noOpen)
        {
            SettingOpen();
            noOpen = false;
        }
        else if (!noOpen)
        {
            SettingClose();
            noOpen = true;
        }
    }
    private void Start()
    {
        
    }
    private void SettingOpen()
    {
        Sequence seq = DOTween.Sequence().SetUpdate(true);
        Time.timeScale = 0;

        seq.Append(transform.DOLocalMoveY(-970, 1.5f)).SetEase(Ease.OutSine);
        seq.AppendInterval(1f);

        seq.Append(transform.DOLocalMoveY(-950, 0.15f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.175f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-950, 0.2f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.225f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-950, 0.25f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.275f)).SetEase(Ease.OutExpo);

        seq.AppendCallback(()=> SettingPanel.SetActive(true));
        seq.Join(SettingBorderLeft.DOAnchorPosX(openBorderLeftX, 0.75f));
        seq.Join(SettingBorderRight.DOAnchorPosX(openBorderRightX, 0.75f));
        seq.Join(SettingBack.DOScaleX(15, 0.75f));
    }
    private void SettingClose()
    {
        Sequence seq = DOTween.Sequence();

        Time.timeScale = 1;

        seq.Append(SettingBorderLeft.DOAnchorPosX(closeBorderLeftX, 0.75f));
        seq.Join(SettingBorderRight.DOAnchorPosX(closeBorderRightX, 0.75f));
        seq.Join(SettingBack.DOScaleX(1, 0.75f));

        seq.AppendCallback(() => SettingPanel.SetActive(false));
        seq.Append(transform.DOLocalMoveY(162, 1.5f)).SetEase(Ease.OutSine);

    }
}
