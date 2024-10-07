using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Cinemachine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform target;
    private bool _isPlayer;
    [SerializeField] GameObject Player;
    [SerializeField] Player player;
    [SerializeField] private RawImage fade;
    [SerializeField] private GameObject[] destroyGameobject;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private EnemySpawner enemyspawn;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] CinemachineConfiner2D setting;

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
    public void Died()
    {
        StartCoroutine(WaitFade());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.m_Lens.OrthographicSize = 5;
        setting.InvalidateCache();
        if (destroyGameobject != null)
        {
            foreach (GameObject gameObject in destroyGameobject)
            {
                Destroy(gameObject);
            }
        }
        StartCoroutine(WaitFade());

    }
    IEnumerator WaitFade()
    {
        player.MovementCompo.moveSpeed = 0;
        player.MovementCompo.jumpPower = 0;

        fade.DOFade(1, 1.5f);
        ChatSystem.Instance.TypCoStart("금자월", "이번엔!!!!!", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        
        yield return new WaitForSeconds(1.5f);

        ChatSystem.Instance.StopTyp();
        Player.transform.position = target.position;

        fade.DOFade(0, 1f).SetDelay(2);
        ChatSystem.Instance.TypCoStart("명성황후", "저를 돕기위해 와주셨군요…!", 0.2f);
        yield return new WaitUntil(() => ChatSystem.Instance.endText == true);
        yield return new WaitForSeconds(1);
        ChatSystem.Instance.StopTyp();
        player.MovementCompo.moveSpeed = saveSpeed;
        player.MovementCompo.jumpPower = saveJump;
        enemyspawn.Spawn();


      
    }

}
