using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4_EnemyQuest : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject enemySpawner;
    [SerializeField] List<GameObject> Wall = new List<GameObject>();
    private void Awake()
    {
        enemySpawner.SetActive(false);
        Wall[0].SetActive(false);
        Wall[1].SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            if (enemySpawner == null)
            {
                print("enemySpawner{IsNull}");
            }
            enemySpawner.SetActive(true);
            Wall[0].SetActive(true);
            Wall[1].SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
