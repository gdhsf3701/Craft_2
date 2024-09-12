using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    //[SerializeField] Transform Spawner;
    float minTime = 0.7f;
    float maxTime = 1.7f;



    int enemyCount = 40;

    private void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }
    IEnumerator SpawnCoroutine()
    {
        //SetSpawnPoint();
        while (enemyCount > 0)
        {
            enemyCount--;
            int randomIndex = Random.Range(0, spawnPoints.Count);
            Vector3 spawnPoint = spawnPoints[randomIndex].position;
            GunKnifeEnemy enemy = PoolManager.Instance.Pop("GunKnifeEnemy") as GunKnifeEnemy;
            enemy.transform.position = spawnPoint;

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
        gameObject.SetActive(false);
    }
    //private void SetSpawnPoint()
    //{
    //    spawnPoints[0].position = new Vector3(Spawner.position.x - 14, Spawner.position.y, 0);
    //    spawnPoints[1].position = new Vector3(Spawner.position.x + 14, Spawner.position.y, 0);
    //}
}
