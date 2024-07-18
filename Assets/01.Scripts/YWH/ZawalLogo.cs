using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZawalLogo : MonoBehaviour
{

    private Animator animator;
    private readonly int bloodHash = Animator.StringToHash("Blood");


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OneAniENd()
    {
        animator.SetBool(bloodHash,true);   
    }
   

    
   


}
