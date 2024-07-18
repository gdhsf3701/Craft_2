using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class JumpKeyWait : MonoBehaviour
{
    [SerializeField] GameObject scarecrow;
    [SerializeField] private CanvasGroup keyUI;
    [SerializeField] private InputReader InputReader;
    bool istouched;
    private bool _isAttack=false;


    private void Start()
    {
        InputReader.OnAttackKeyEvent += HandleAttackKeyEvent;
    }

    private void HandleAttackKeyEvent()
    {
        _isAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!istouched)
        {
         StartCoroutine(Musul());
                istouched = true;
        }
       

    }

    IEnumerator Musul()
    {
        InputReader._controls.Disable();
        ChatSystem.Instance.TypCoStart("���´�", "���� �ͼ����� �� ���� ���̴�..", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        ChatSystem.Instance.TypCoStart("���´�", "������ �����̴�!", 0.2f);
        scarecrow.SetActive(true);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        keyUI.gameObject.SetActive(true);
        InputReader._controls.Enable();
        keyUI.DOFade(1, 1);
        yield return new WaitUntil(() => _isAttack==true);

        keyUI.DOFade(0, 1).SetDelay(0.5f);


    }
}
