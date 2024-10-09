using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBackTrigger : MonoBehaviour
{
    private GageGameUI gameUI;
    private void Awake()
    {
        gameUI = GameObject.Find("GageBar").GetComponent<GageGameUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameUI.gameObject.SetActive(true);
            gameUI.ChangeNowEnemy(transform.parent.gameObject);
        }
    }
}
