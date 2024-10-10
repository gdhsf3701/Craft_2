using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ChatSystem : MonoSingleton<ChatSystem>
{
    [SerializeField] private TextMeshProUGUI chatName;
    [SerializeField] private TextMeshProUGUI desc;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CanvasGroup zawalMini;
    [SerializeField] private CanvasGroup enemyMini;
    [SerializeField] private CanvasGroup enemy2Mini;
    [SerializeField] private Image icon;
    [SerializeField] private List<Sprite> sprites;

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
        switch (name)
        {

            case "±ÝÀÚ¿ù":
                icon.sprite = sprites[0];

                break;
            case "½º½Â´Ô":
                icon.sprite = sprites[1];

                break;
            case "¸í¼ºÈ²ÈÄ":
                icon.sprite = sprites[2];

                break;

        }



        endText = false;
        
        StartCoroutine(Typing(text, rate,desc));
        chatName.text = name;
        canvasGroup.DOFade(1, 1);
    }

 

    public void StopTyp()
    {
        canvasGroup.DOFade(0, 1);
      
    }
    public void BubbleStop(CanvasGroup c1, CanvasGroup c2)
    {

        c1.DOFade(0, 1);
        c2.DOFade(0, 1);
    }    
    public void Boss1(CanvasGroup canvasGroup, string name, string text, float rate)
    {
        TMP_Text targetText = canvasGroup.GetComponentInChildren<TMP_Text>();

        if (targetText == null)
        {
            Debug.LogError("dd");
            return;
        }

        endText = false;

        canvasGroup.DOFade(1, 0.2f).OnComplete(() =>
        {
            StartCoroutine(Typing(text, rate, targetText));
        });

        StartCoroutine(waitforEnemy(targetText, canvasGroup));
    }

    IEnumerator waitforEnemy(TMP_Text text, CanvasGroup canvasGroup)
    {
        yield return new WaitUntil(() => endText == true);

        yield return new WaitForSeconds(1);
        canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
        {
            text.text = "";
        });
    }

    private IEnumerator Typing(string text, float rate, TMP_Text descText)
    {
        for (int i = 0; i <= text.Length; i++)
        {
            descText.text = text.Substring(0, i);
            yield return new WaitForSecondsRealtime(rate);

            if (endText == true)
            {
                descText.text = text;
                break;
            }
        }

        yield return new WaitForSeconds(1.5f);
        endText = true;
    }

}
