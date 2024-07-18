using Cinemachine;
using TMPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // text는 상호작용 안 텍스트 (월드스페이스 캔버스)
    private bool _isPlayer = false;

    Player _player;
    GameObject player;

    CinemachineVirtualCamera camera;

    SpriteRenderer renderer;
    bool hide = false;
    float maxCameraSize = 5f;
    float minCameraSize = 2.5f;


    Coroutine coroutine;

    float saveSpeed = 0;
    float saveJump = 0;

    private void Start()
    {
        camera = FindAnyObjectByType<CinemachineVirtualCamera>();
        player = GameObject.Find("Player");
        renderer = player.GetComponentInChildren<SpriteRenderer>();
        maxCameraSize -= 0.1f;
        minCameraSize += 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player = collision.GetComponent<Player>();
        text.gameObject.SetActive(true);
        _isPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        _isPlayer = false;
    }

    private void Update()
    {
        if (_isPlayer&&!hide)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.gameObject.layer = LayerMask.NameToLayer("HidePlayer");
                renderer.color = Color.clear;

                saveSpeed = _player.MovementCompo.moveSpeed;
                saveJump = _player.MovementCompo.jumpPower;
                _player.MovementCompo.moveSpeed = 0;
                _player.MovementCompo.jumpPower = 0;


                hide = true;
                _player.transform.position = new Vector3(transform.position.x,_player.transform.position.y,_player.transform.position.z );
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = null;
                }
                coroutine = StartCoroutine(Zoom());
            }
        }
        else if(hide)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.gameObject.layer = LayerMask.NameToLayer("Player");
                renderer.color = Color.white;
                renderer.enabled = true;
                hide = false;
                _player.MovementCompo.moveSpeed = saveSpeed;
                _player.MovementCompo.jumpPower = saveJump;
                if (coroutine != null)
                {
                    StopCoroutine(coroutine);
                    coroutine = null;
                }
                coroutine = StartCoroutine(Out());
            }
        }
    }
    IEnumerator Zoom()
    {
        while(camera.m_Lens.OrthographicSize >= minCameraSize)
        {
            camera.m_Lens.OrthographicSize -= 0.1f;
            yield return null;
        }
            }
    IEnumerator Out()
    {
        while (camera.m_Lens.OrthographicSize <= maxCameraSize)
        {
            camera.m_Lens.OrthographicSize += 0.1f;
            yield return null;
        }
    }
}
