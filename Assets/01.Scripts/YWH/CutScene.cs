using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class CutScene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _timeline;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        _timeline.Play();

    }


    public void SignalRecieve()
    {
        ChatSystem.Instance.TypCoStart("금자월", " 이걸로 전부 끝이군.", 0.2f);

    }

    public void SceneChanger()
    {
        SaveManager.Instance.SetStageNumber(3,SceneName.Stage3);
        SceneManager.LoadScene(SceneName.Stage3);
    }

}
