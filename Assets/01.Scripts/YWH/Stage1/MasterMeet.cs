using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using DG.Tweening;

public class MasterMeet : MonoBehaviour
{


    [SerializeField] private PlayableDirector playableDirector;
    private Collider2D collider2d;
    [SerializeField] private CanvasGroup keyUI;

    private void Start()
    {
        collider2d = GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MeetHim();
    }

    public void MeetHim()
    {
        PlayerManager.Instance.Player.PlayerInput._controls.Disable();
        playableDirector.Play();
        collider2d.enabled = false;
        

    }


    void OnEnable()
    {
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (playableDirector == aDirector)
        {
        PlayerManager.Instance.Player.PlayerInput._controls.Enable();
            StartCoroutine(Jump());

        }
           
    }
    IEnumerator Jump()
    {
        ChatSystem.Instance.TypCoStart("스승님", "다음은 이걸 뛰어넘을 수 있겠느냐?", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        ChatSystem.Instance.StopTyp();
        keyUI.DOFade(1, 1);
        yield return new WaitUntil(() => PlayerManager.Instance.Player.MovementCompo.rbCompo.velocity.y>0);

        keyUI.DOFade(0, 1).SetDelay(0.5f);

    }

    void OnDisable()
    {
        playableDirector.stopped -= OnPlayableDirectorStopped;
    }
}

