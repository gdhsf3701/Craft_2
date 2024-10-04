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
    [SerializeField] private CanvasGroup zawalMini;
    [SerializeField] private CanvasGroup enemyMini;
    [SerializeField] private CanvasGroup enemy2Mini;

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
        StartCoroutine(Typing(text, rate,desc));
        chatName.text = name;
        canvasGroup.DOFade(1, 1);
    }

    public void StopTyp()
    {
        canvasGroup.DOFade(0, 1);
      
    }

    public void Boss1(CanvasGroup canvasGroup,string name, string text, float rate)
    {
        TMP_Text targettext = enemyMini.transform.GetComponentInChildren<TMP_Text>();

        canvasGroup.DOFade(1, 0.2f).OnComplete(() =>
        {
            StartCoroutine(Typing(text, rate,targettext));
            StartCoroutine(waitforEnemy(targettext, canvasGroup));
        });

       

    }

    IEnumerator waitforEnemy(TMP_Text text,CanvasGroup canvasGroup)
    {
        yield return new WaitUntil(() => endText == true);
        yield return new WaitForSeconds(1);
        canvasGroup.DOFade(0, 0.2f);
   
        text.text = "";
    }




    private IEnumerator Typing(string text, float rate, TMP_Text descText)
    {

        for (int i = 0; i <= text.Length; i++)
        {
            descText.text = text.Substring(0, i);
            
            yield return new WaitForSecondsRealtime(rate);

            if (endText == true)
            {
                i = text.Length;
                descText.text = text;                   
            }
        }
        yield return new WaitForSeconds(1.5f);
       
        endText = true;
      
    }
}
