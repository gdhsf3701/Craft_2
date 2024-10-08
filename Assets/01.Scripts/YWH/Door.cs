using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private RawImage _fadeImage;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _cutScene;
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
             
                StartCoroutine(Delay());

            }
        }
    }

    IEnumerator Delay()
    {

        yield return new WaitForSeconds(1);
        _playerTrm.position = _target.position;
        yield return new WaitForSeconds(1);
        _fadeImage.DOFade(0, 1.5f);
        
        if (_cutScene != null)
        {
            _cutScene.SetActive(true);
            _playerTrm.GetComponent<Plr_move>().enabled = false;
        }
        _isPlayer = false;

    }

    public void Stage0Change()
    {
        StartCoroutine(SceneChanger());
    }

    IEnumerator SceneChanger()
    {
        FadeManager.instance.FadeIn(1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName.Stage1);
    }
}
