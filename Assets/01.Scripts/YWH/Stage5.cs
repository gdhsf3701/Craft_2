using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : MonoBehaviour
{
    public CanvasGroup zawal;
    public CanvasGroup boss;

    public void Ment2()
    {
        ChatSystem.Instance.Boss1(boss,"����", "�ϰ� ���� ������ �� �����ΰ�?",0.1f);
    }
    public void Ment3()
    {
        ChatSystem.Instance.Boss1(boss, "����", "�ƹ��� ���뵵 �ʰ��� ������ �����ϰ� �ɰŴ�", 0.1f);
    }
    public void Ment4()
    {
        ChatSystem.Instance.Boss1(zawal, "���ڿ�", " �׸� �Դ�ġ����", 0.1f);
    }
    public void Ment5()
    {
        ChatSystem.Instance.Boss1(boss, "����", "�� ������..!!", 0.1f);
    }
    public void Ment6()
    {
        ChatSystem.Instance.Boss1(boss, "����", "..! ���� �ϳ� �����־���..!", 0.1f);
    }
    public void Ment7()
    {
        ChatSystem.Instance.Boss1(zawal, "���ڿ�", "�̰ɷ� ���� ���� ���ž�..?", 0.1f);
    }
    public void Ment8()
    {
        ChatSystem.Instance.Boss1(zawal, "���ڿ�", "�ؾ��� ����.. .�ִµ���", 0.1f);
    }



}
