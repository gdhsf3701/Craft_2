using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawedOff
{
    private float SpreadAngle = 15f;
    private float attackCooldown=1.3f;
    private float lastAttackTime=0;

    private int bulletCount=3;
    
    
    public void ShootGun(Transform muzzleTrm)
    {
        for (int i = 0; i < Random.Range(5, 8); i++)
        {
            float spreadAngle = Random.Range(-SpreadAngle, SpreadAngle);

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, spreadAngle));

            EnemyBullet bullet = PoolManager.Instance.Pop("Enemybullet") as EnemyBullet;
        
            bullet.transform.position = muzzleTrm.position;
            bullet.transform.rotation = rotation * muzzleTrm.rotation;

        }
        lastAttackTime = Time.time;
        bulletCount--;
    }

    public void Reroad()
    {
        bulletCount = 3;
    }

    public bool TryShot()
    {
        return (attackCooldown + lastAttackTime < Time.time);
    }
}
