using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Stage1 : MonoBehaviour
{

    [SerializeField] private CanvasGroup keyUI;
    

    void Start()
    {
       
        StartCoroutine(MasterSay());
    }

    IEnumerator MasterSay()
    {
       
    
        ChatSystem.Instance.TypCoStart("���ڿ�", "��.. �̷��ǰ�?", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        FadeManager.instance.FadeOut(1);
        PlayerManager.Instance.Player.PlayerInput._controls.Disable();
        yield return new WaitForSeconds(2);
        ChatSystem.Instance.StopTyp();

        yield return new WaitForSeconds(3);

        ChatSystem.Instance.TypCoStart("���´�", "�ῡ�� ������?", 0.2f);
        yield return new WaitUntil(() =>ChatSystem.Instance.endText==true);
        yield return new WaitForSeconds(0.5f);
        ChatSystem.Instance.TypCoStart("���´�", "�׷� �������� �Ʒ��� �������ڲٳ�.", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        yield return new WaitForSeconds(0.5f);
        ChatSystem.Instance.StopTyp();
        yield return new WaitForSeconds(3);
        keyUI.gameObject.SetActive(true);
        PlayerManager.Instance.Player.PlayerInput._controls.Enable();
        keyUI.DOFade(1, 1);
        yield return new WaitUntil(() => PlayerManager.Instance.Player.PlayerInput.Movement.magnitude>0);

        keyUI.DOFade(0, 1).SetDelay(0.5f);


    }
}
