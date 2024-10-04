using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FailScene : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    
    public void OnDead()
    {
        StartCoroutine(StartCutScene());
    }

    IEnumerator StartCutScene()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(2);
        FadeManager.instance.FadeOut(1);

        director.Play();


    }

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            PlayerManager.Instance.Player.PlayerInput._controls.LeftPlayer.Enable();
            Debug.Log("Enable");

        }

    }
    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
    public void Chat()
    {
        ChatSystem.Instance.TypCoStart("금자월", "너희 같은 거에 죽을 바엔..!", 0.1f);
    }    
    public void ChatClose()
    {
        ChatSystem.Instance.StopTyp();
        StartCoroutine(SceneChange());

    }
    IEnumerator SceneChange()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
}
