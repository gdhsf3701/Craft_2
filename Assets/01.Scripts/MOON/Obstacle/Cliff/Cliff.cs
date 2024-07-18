using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Cliff : MonoBehaviour
{
    [SerializeField]Transform[] cliffReturn;
    [SerializeField]GameObject Player;
    public Player player;
    [SerializeField] float delayTime=0.25f;
    int childIndex;
    private void Awake()
    {
        player = Player.GetComponent<Player>();
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
        if (other.gameObject == Player)
        {
            player.JumpProcess();
            child.count--;
            if (child.count <= 0)
            {
                child.gameObject.layer = LayerMask.NameToLayer("UITrigger");
                child.transform.GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
    private IEnumerator DownTimeDelay()
    {
        yield return new WaitForSeconds(delayTime);
        EasterEggSorry.deathCount++;
        Player.transform.position = cliffReturn[childIndex].position;
    }
}
