
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class CSI_Death_Sc : MonoBehaviour
{
    public GameObject Text,rePlay_Bt,Quit_Bt;
    private Image TextI,rePlay_BtI,Quit_BtI; 
    private Image Images;
    private void Awake()
    {
        //TextI = Text.GetComponent<Image>();
        rePlay_BtI = rePlay_Bt.GetComponent<Image>();
        Quit_BtI = Quit_Bt.GetComponent<Image>();
        Images = GetComponent<Image>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayerDie();
        }
    }

    public void PlayerDie()
    {
        Images.DOFade(1, 1);
        Text.transform.DOLocalMoveY(0 + 0, 1, false).SetEase(Ease.Unset);
        Invoke("UpBt",0.7f);
    }

    private void UpBt()
    {
        rePlay_Bt.transform.DOLocalMoveY(-1300 + 540, 1, false).SetEase(Ease.Unset);
        Quit_Bt.transform.DOLocalMoveY(-1300 + 540, 1, false).SetEase(Ease.Unset);
    }
    public void ReStartBt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("나가는 씬 이름");
    }
}
