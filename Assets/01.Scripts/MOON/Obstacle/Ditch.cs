using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ditch : MonoBehaviour
{
    int ditchOut = 0;
    bool isIn = false;
    float gameOverTime = 0;
    Player _player;
    GameObject player;
    float saveSpeed = 0;
    float saveJump = 0;

    bool CoolTime=false;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (isIn)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                --ditchOut;
                if (ditchOut <= 0)
                {
                    StartCoroutine(Cool());
                    ditchOut = 0;
                    SetRigidbodyToDynamic();
                    isIn = false;
                }
            }
        }
    }

    private void SetRigidbodyToDynamic()
    {
        if (_player.MovementCompo.moveSpeed == 0)
        {
            _player.MovementCompo.moveSpeed = saveSpeed;
            _player.MovementCompo.jumpPower = saveJump;
        }
    }
    IEnumerator InDitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (ditchOut <= 0)
            {
                break;
            }
            gameOverTime -= 0.1f;
            if (gameOverTime <= 0)
            {
                //게임오버 스크립트
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CoolTime&&collision.gameObject == player)
        {
            _player = collision.GetComponent<Player>();
            isIn = true;
            ditchOut = 20;
            gameOverTime = 5;
            saveSpeed = _player.MovementCompo.moveSpeed;
            saveJump = _player.MovementCompo.jumpPower;
            _player.MovementCompo.moveSpeed = 0;
            _player.MovementCompo.jumpPower = 0;
            StartCoroutine(InDitch());
        }
    }
    IEnumerator Cool()
    {
        CoolTime = true;
        yield return new WaitForSeconds(0.5f);
        CoolTime = false;
    }
}
