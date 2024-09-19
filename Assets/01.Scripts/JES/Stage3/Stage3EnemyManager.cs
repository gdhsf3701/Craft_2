using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 그냥 아무 오브젝트에 박아두기만 하면 됨.
/// </summary>
public class Stage3EnemyManager : MonoSingleton<Stage3EnemyManager>
{
    private List<GunKnifeEnemy> enemyList= new List<GunKnifeEnemy>();
    private int count;
    private void Start()
    {
        foreach (var enemy in FindObjectsOfType<GunKnifeEnemy>())
        {
            enemyList.Add(enemy);
            enemy.OnDeathEvent += HandleDeadEvent;
        }
        count = enemyList.Count;
    }

    public void SpotEvent() //플레이어가 발각됐을때 실행하면 됨
    {
        Player player = PlayerManager.Instance.Player;
        foreach (var enemy in enemyList)
        {
            enemy.SetSpotPlayer(player);
        }
    }
    private void HandleDeadEvent(GunKnifeEnemy enemy) //다 죽었는지 안죽었는지 확인 용
    {
        enemyList.Remove(enemy);
        count--;
        if (count <= 0)
        {
            //다죽인거
        }
    }
}