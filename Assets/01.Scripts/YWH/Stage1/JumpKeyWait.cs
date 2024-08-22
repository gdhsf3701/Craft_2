using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class JumpKeyWait : MonoBehaviour
{
    [SerializeField] GameObject scarecrow;
    [SerializeField] private CanvasGroup keyUI;
    [SerializeField] private InputReader InputReader;
    [SerializeField] private PlayableDirector playableDirector;
    bool istouched;
    private bool _isAttack = false;
    private bool _isDead = false;

   

    private void Start()
    {
        InputReader.OnAttackKeyEvent += HandleAttackKeyEvent;
    }

    public void niulgull9()
    {
        _isDead = true;
        Destroy(scarecrow);
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
        ChatSystem.Instance.StopTyp();
        ChatSystem.Instance.TypCoStart("���´�", "������ �����̴�!", 0.2f);
        scarecrow.SetActive(true);
        
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        ChatSystem.Instance.StopTyp();
        keyUI.gameObject.SetActive(true);
       
        keyUI.DOFade(1, 1);
        InputReader._controls.Enable();
        yield return new WaitUntil(() => _isAttack == true);

        keyUI.DOFade(0, 1).SetDelay(0.5f);

        yield return new WaitUntil(() => _isDead == true);  

        ChatSystem.Instance.TypCoStart("���´�", "���� ����� ������ �� �� ���� ���̴�", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        ChatSystem.Instance.StopTyp();

        ChatSystem.Instance.TypCoStart("���´�", "���� ����ͺ��Ŷ�!!", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        ChatSystem.Instance.StopTyp();
        playableDirector.Play();

    }
}
