using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Stage3_Door : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Stage3EnemyManager enemyManager;
    private bool _isPlayer;
    [SerializeField] GameObject Player;
    [SerializeField] Player player;
    [SerializeField] private RawImage fade;
    [SerializeField]GageGameUI gage;
    public bool done = false;
    float saveSpeed = 0;
    float saveJump = 0;
    private void Awake()
    {
        player = Player.GetComponent<Player>();
        gage = GameObject.Find("GageBar").GetComponent<GageGameUI>();
    }
    private void Start()
    {
        saveSpeed = player.MovementCompo.moveSpeed;
        saveJump = player.MovementCompo.jumpPower;
    }
    private void Update()
    {
        if (_isPlayer && !done)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                done = true;
                if (enemyManager.AllDeadCheck())
                {
                    StartCoroutine(WaitFade());
                }
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
    public IEnumerator WaitFade()
    {
        player.MovementCompo.moveSpeed = 0;
        player.MovementCompo.jumpPower = 0;
        fade.DOFade(1, 0.3f);
        yield return new WaitForSeconds(0.3f);
        Player.transform.position = target.position;
        fade.DOFade(0, 0.3f);
        yield return new WaitForSeconds(0.3f/2);
        player.MovementCompo.moveSpeed = saveSpeed;
        player.MovementCompo.jumpPower = saveJump;
        gage.gameObject.SetActive(true);
    }
}
