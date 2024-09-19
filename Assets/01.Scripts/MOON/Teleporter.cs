using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform target;
    private bool _isPlayer;
    [SerializeField] GameObject Player;
    [SerializeField]Player player;
    [SerializeField] private RawImage fade;
    [SerializeField] private GameObject[] destroyGameobject;
    bool done = false;
    float saveSpeed = 0;
    float saveJump = 0;
    private void Awake()
    {
        player = Player.GetComponent<Player>();
    }
    private void Start()
    {
        saveSpeed = player.MovementCompo.moveSpeed;
        saveJump = player.MovementCompo.jumpPower;
    }
    private void Update()
    {
        if (_isPlayer&&!done)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                done = true;
                if (destroyGameobject != null)
                {
                    foreach(GameObject gameObject in destroyGameobject)
                    {
                        Destroy(gameObject);
                    }
                }
                StartCoroutine(WaitFade());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isPlayer = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isPlayer = false;
    }
    IEnumerator WaitFade()
    {
        player.MovementCompo.moveSpeed = 0;
        player.MovementCompo.jumpPower = 0;
        fade.DOFade(1, 1.5f);
        yield return new WaitForSeconds(1.5f);
        Player.transform.position = target.position;
        fade.DOFade(0, 1f).SetDelay(2);
        yield return new WaitForSeconds(1);
        player.MovementCompo.moveSpeed = saveSpeed;
        player.MovementCompo.jumpPower = saveJump;
    }
}
