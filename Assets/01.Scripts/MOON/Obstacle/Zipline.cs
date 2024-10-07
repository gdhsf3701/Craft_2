using Cinemachine;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    [SerializeField] GameObject LineEnd;
    private float targetY;
    //[SerializeField] private TextMeshProUGUI text;
    // text는 상호작용 안 텍스트 (월드스페이스 캔버스)
    private bool _isPlayer = false;
    public static bool isMove = false;
    [SerializeField] SoundSO sound, exitSound;
    [SerializeField] float min;

    bool can = true;

    SoundPlayer soundPlayer;

    [SerializeField]Player _player;

    [SerializeField] float Speed = 10;
    private void Awake()
    {
        Collider2D collider = GetComponent<Collider2D>();
        targetY = collider.bounds.max.y;
    }
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
            if (Input.GetKeyDown(KeyCode.F) && !isMove && can)
            {
                can = false;
                _player.MovementCompo.rbCompo.bodyType = RigidbodyType2D.Kinematic;
                _player.MovementCompo.rbCompo.velocity = Vector2.zero;
                _player.PlayerInput._controls.Disable();
                StartCoroutine(MoveToTarget());
                soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
                soundPlayer.PlaySound(sound);
                
            }
        }
        if (isMove && _player != null)
        {
            _player.transform.position += (LineEnd.transform.position - _player.transform.position).normalized * Speed * Time.deltaTime;
            if (Mathf.Abs(Vector3.Distance(_player.transform.position, LineEnd.transform.position)) < 0.1f)
            {
                isMove = false;
                soundPlayer.StopAndGoToPool();
                SoundPlayer exitSoundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
                exitSoundPlayer.PlaySound(exitSound);
            }
        }
        if (!_isPlayer && _player != null && !isMove)
        {
            _player = null;
        }
    }
    IEnumerator MoveToTarget()
    {
        _player.stateMachine.ChangeState(PlayerEnum.Idle);
        while (Mathf.Abs(_player.transform.position.y - (targetY- min)) > 0.1f)
        {
            Vector3 currentPosition = _player.transform.position;
            Vector3 targetPosition = new Vector3(currentPosition.x, targetY- min, currentPosition.z);

            _player.transform.position = Vector3.Lerp(currentPosition, targetPosition, 5 * Time.deltaTime);

            yield return null;
        }
        _player.MovementCompo.rbCompo.bodyType = RigidbodyType2D.Dynamic;
        _player.stateMachine.ChangeState(PlayerEnum.Wire);
        isMove = true;
        can = true;
    }
}
