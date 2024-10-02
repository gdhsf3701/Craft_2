using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4EnemyManager : MonoBehaviour
{
    private List<GunKnifeEnemy> enemyList = new List<GunKnifeEnemy>();
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var enemy in FindObjectsOfType<GunKnifeEnemy>())
        {
            enemyList.Add(enemy);
            enemy.OnDeathEvent += HandleDeadEvent;
        }
        count = enemyList.Count;
    }

    private void HandleDeadEvent(GunKnifeEnemy obj)
    {
        foreach (var enemy in FindObjectsOfType<GunKnifeEnemy>())
        {
            enemyList.Remove(obj);
        }

        count--;
        if (count <= 0)
        {
            //´ÙÁ×ÀÎ°Å
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
