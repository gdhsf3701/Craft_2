using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    //[SerializeField] Transform Spawner;
    float minTime = 5f;
    float maxTime = 7f;



    int enemyCount = 16;
    int deadCount = 0;
    public void Spawn()
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
            Stage4Enemy enemy = PoolManager.Instance.Pop("Stage4Enemy") as Stage4Enemy;
            enemy.Inialize(PlayerManager.Instance.transform,DeadCountUP);
            enemy.transform.position = spawnPoint;

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
        gameObject.SetActive(false);
    }

    public void DeadCountUP()
    {
        deadCount++;
        if (deadCount == enemyCount)
        {
            //다 죽은거 클리어 실행
        }
    }
    //private void SetSpawnPoint()
    //{
    //    spawnPoints[0].position = new Vector3(Spawner.position.x - 14, Spawner.position.y, 0);
    //    spawnPoints[1].position = new Vector3(Spawner.position.x + 14, Spawner.position.y, 0);
    //}
}
