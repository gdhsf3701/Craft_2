using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine.Playables;

public class Stage5Door : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private RawImage _fadeImage;
    [SerializeField] private Transform _target;
    [SerializeField] private PlayableDirector timelineOne;

    [SerializeField] private CanvasGroup _boss1;
    [SerializeField] private CanvasGroup _boss2;
    [SerializeField] private CanvasGroup _player;
    private bool _isPlayer = false;
    private Transform _playerTrm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _text.gameObject.SetActive(true);
        _isPlayer = true;
        _playerTrm = collision.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _text.gameObject.SetActive(false);
        _isPlayer = false;
    }

    private void Update()
    {
        if (_isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _fadeImage.DOFade(1, 1.5f);
                _isPlayer = false;
                StartCoroutine(Delay());

            }
        }
    }

    IEnumerator Delay()
    {

        yield return new WaitForSeconds(1.5f);
        _playerTrm.position = _target.position;
       
        _fadeImage.DOFade(0, 1.5f);
      
        ChatSystem.Instance.Boss1(_player, "금자월", "이제서야.. 도착했어.", 0.5f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        yield return new WaitForSeconds(2);
        ChatSystem.Instance.Boss1(_boss1, "보스1", "니가 요즘 유명한 그 계집인가?", 0.2f);

    }
}