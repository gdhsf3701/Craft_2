using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Chat : MonoBehaviour
{
    public void StopType()
    {
        ChatSystem.Instance.StopTyp();
    }

    public void Defence_5()
    {
        ChatSystem.Instance.TypCoStart("���ڿ�", "�̹���.. ���ߴٰ� �����ߴµ�..",0.2f);
        
    }



}
