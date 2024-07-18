using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Cliff : MonoBehaviour
{
    [SerializeField]Transform[] cliffReturn;
    [SerializeField]GameObject Player;

    public void OnChildTrigger(CliffTrigger child, Collider2D other)
    {
        if(other.gameObject == Player)
        {
            int childIndex = child.transform.GetSiblingIndex();
            //�÷��̾� HP�� ��� �ڵ�
            EasterEggSorry.deathCount++;
            Player.transform.position = cliffReturn[childIndex].position;
        }
    }
}
