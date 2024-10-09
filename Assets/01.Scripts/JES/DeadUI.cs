using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadUI : MonoSingleton<DeadUI>
{
    public void OnDeadUI()
    {
        transform.DOScale(1, 1f);
    }

    public void RestartBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitBtnClick()
    {
        SceneManager.LoadScene(SceneName.Start);
    }
}
