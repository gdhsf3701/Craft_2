using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Cliff : MonoBehaviour
{
    [SerializeField]Transform[] cliffReturn;
    [SerializeField]GameObject Player;
    [SerializeField] Player player;
    [SerializeField] float delayTime=0.25f;
    int childIndex;
    [SerializeField] float darkTime = 0.5f;
    [SerializeField] RawImage dark;
    float saveSpeed = 0;
    float saveJump = 0;

    [SerializeField] SoundSO clothesLineSound, cutOffSound;
    private void Awake()
    {
        player = Player.GetComponent<Player>();
    }
    private void Start()
    {
        saveSpeed = player.MovementCompo.moveSpeed;
        saveJump = player.MovementCompo.jumpPower;
    }

    public void OnChildTrigger(CliffCollison child, Collider2D other)
    {
        if(other.gameObject == Player)
        {
            childIndex = child.transform.GetSiblingIndex();
            PlayerManager.Instance.Player.HealthCompo.NoEventHit(1);
            StartCoroutine(DownTimeDelay());
        }
    }
    public void OnChildCollison(CliffCollison child, Collision2D other)
    {
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        if (other.gameObject == Player)
        {
            player.JumpProcess();
            child.count--;
            if (child.count <= 0)
            {
                child.GetComponent<SpriteRenderer>().enabled = false;
                soundPlayer.PlaySound(cutOffSound);
                child.gameObject.layer = LayerMask.NameToLayer("UITrigger");
                child.transform.GetComponent<Collider2D>().isTrigger = true;
            }
            else
            {
                soundPlayer.PlaySound(clothesLineSound);
            }
        }
    }
    private IEnumerator DownTimeDelay()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        Time.timeScale = 0;
        dark.DOFade(1, delayTime).SetUpdate(true);
        yield return new WaitForSecondsRealtime(delayTime);
        Player.transform.position = cliffReturn[childIndex].position;
        dark.DOFade(0, darkTime).SetUpdate(true);
        yield return new WaitForSecondsRealtime(darkTime/2);
        Time.timeScale = 1;
    }
}
