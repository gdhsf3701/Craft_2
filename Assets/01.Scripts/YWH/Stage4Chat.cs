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
        ChatSystem.Instance.TypCoStart("금자월", "이번엔.. 잘했다고 생각했는데..",0.2f);
        
    }



}
