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
        _timeline.Play();

    }

    void OnEnable()
    {
        _timeline.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (_timeline == aDirector)
        {

            SceneManager.LoadScene("StartScene");

        }

    }
    void OnDisable()
    {
        _timeline.stopped -= OnPlayableDirectorStopped;
    }

    public void SignalRecieve()
    {
        ChatSystem.Instance.TypCoStart("금자월", "이걸로 전부 끝이군.", 0.2f);

    }

}
