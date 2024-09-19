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
            //플레이어 HP를 깍는 코드
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
                //끊어진 줄 그림으로 바뀌는 코드
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
        player.MovementCompo.moveSpeed = 0;
        player.MovementCompo.jumpPower = 0;
        dark.DOFade(1, delayTime);
        yield return new WaitForSeconds(delayTime);
        Player.transform.position = cliffReturn[childIndex].position;
        dark.DOFade(0, darkTime);
        yield return new WaitForSeconds(darkTime/2);
        player.MovementCompo.moveSpeed = saveSpeed;
        player.MovementCompo.jumpPower = saveJump;
    }
}
