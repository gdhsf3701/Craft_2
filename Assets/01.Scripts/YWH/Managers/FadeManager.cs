using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class FadeManager : MonoBehaviour
{
    public static FadeManager instance = null;
    [SerializeField] private RawImage fade;


    private void Awake()
    {
        if (null == instance)
        {

            instance = this;

        }
        else
        { 
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        fade = GetComponent<RawImage>();
    }

    public void FadeIn(float time)
    {
        fade.DOFade(1, time);
    }
    public void FadeOut(float time)
    {
        fade.DOFade(0, time);
    }

   


}
