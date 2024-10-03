using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private RawImage _fadeImage;
    [SerializeField] private Transform _target;
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

        yield return new WaitForSeconds(1);
        _playerTrm.position = _target.position;
        yield return new WaitForSeconds(1);
        _fadeImage.DOFade(0, 1.5f);
    }
}
