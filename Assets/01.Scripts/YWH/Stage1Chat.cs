using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Chat : MonoBehaviour
{
    public void Chat()
    {
        ChatSystem.Instance.TypCoStart("금자월", "!… 어머니.. 아버지… ", 0.1f);

    }
   
}
