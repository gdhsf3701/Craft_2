using Cinemachine;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    [SerializeField]GameObject LineEnd;
    //[SerializeField] private TextMeshProUGUI text;
    // text는 상호작용 안 텍스트 (월드스페이스 캔버스)
    private bool _isPlayer = false;
    public static bool isMove= false;

    Player _player;
    float saveSpeed = 0;
    float saveJump = 0;

    [SerializeField] float Speed=10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //text.gameObject.SetActive(true);
        _player = collision.GetComponent<Player>();
        _isPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //text.gameObject.SetActive(false);
        _isPlayer = false;
    }
    private void Update()
    {
        if (_isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.F)&&!isMove)
            {
                isMove = true;
                _player.stateMachine.ChangeState(PlayerEnum.Wire);
            }
        }
        if (isMove)
        {
            _player.transform.position += (LineEnd.transform.position- _player.transform.position).normalized * Speed * Time.deltaTime;
            if(Mathf.Abs(Vector3.Distance(_player.transform.position, LineEnd.transform.position)) < 0.1f)
            {
                isMove = false;
            }
        }
    }
}
