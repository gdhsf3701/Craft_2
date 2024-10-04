using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ChatSystem : MonoSingleton<ChatSystem>
{
    [SerializeField] private TextMeshProUGUI chatName;
    [SerializeField] private TextMeshProUGUI desc;

    [SerializeField] private CanvasGroup canvasGroup;

    public bool endText;
    public bool isTexting;

    private void Update()
    {
        if (endText == false && Input.GetKeyDown(KeyCode.Space))
        {
            endText = true;
        }
        
    }

    public void TypCoStart(string name, string text, float rate)
    {
       
        endText = false;
        StartCoroutine(Typing(text, rate));
        chatName.text = name;
        canvasGroup.DOFade(1, 1);
    }

    public void StopTyp()
    {
        canvasGroup.DOFade(0, 1);
      
    }


    private IEnumerator Typing(string text, float rate)
    {

        for (int i = 0; i <= text.Length; i++)
        {
            desc.text = text.Substring(0, i);
            
            yield return new WaitForSecondsRealtime(rate);

            if (endText == true)
            {
                i = text.Length;
                desc.text = text;                   
            }
        }
        yield return new WaitForSeconds(1.5f);
       
        endText = true;
      
    }
}
