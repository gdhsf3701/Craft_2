using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_EnemyQuest : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject enemySpawner;
    private void Awake()
    {
        enemySpawner.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            enemySpawner.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
