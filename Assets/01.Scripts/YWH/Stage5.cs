using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : MonoBehaviour
{
    public CanvasGroup zawal;
    public CanvasGroup boss;

    public void Ment2()
    {
        ChatSystem.Instance.Boss1(boss,"보스", "니가 요즘 유명한 그 계집인가?",0.1f);
    }
    public void Ment3()
    {
        ChatSystem.Instance.Boss1(boss, "보스", "아무리 나대도 너같은 계집은 복종하게 될거다", 0.1f);
    }
    public void Ment4()
    {
        ChatSystem.Instance.Boss1(zawal, "금자월", " 그만 입닥치시지", 0.1f);
    }
    public void Ment5()
    {
        ChatSystem.Instance.Boss1(boss, "보스", "저 계집이..!!", 0.1f);
    }
    public void Ment6()
    {
        ChatSystem.Instance.Boss1(boss, "보스", "..! 아직 하나 남아있었나..!", 0.1f);
    }
    public void Ment7()
    {
        ChatSystem.Instance.Boss1(zawal, "금자월", "이걸로 정말 끝이 난거야..?", 0.1f);
    }
    public void Ment8()
    {
        ChatSystem.Instance.Boss1(zawal, "금자월", "해야할 일이.. .있는데…", 0.1f);
    }



}
