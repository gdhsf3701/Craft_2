using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private RawImage fade;
    private bool _isPlayer = false;
    private Transform _playerTrm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        _isPlayer = true;
        _playerTrm = collision.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        _isPlayer = false;
    }

    private void Update()
    {
        if (_isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                fade.DOFade(1, 1.5f);
                _isPlayer = false;
                _playerTrm.DOMove( new Vector3(86.3f, 2.5f, 0),1).SetDelay(1);
                fade.DOFade(0, 1f).SetDelay(2);
                
                
            }
        }
    }




}
