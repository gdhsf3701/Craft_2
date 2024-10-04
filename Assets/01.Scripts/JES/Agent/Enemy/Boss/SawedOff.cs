using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class SawedOff : MonoBehaviour
{
    private float SpreadAngle = 7.5f;

    private int bulletCount=3;

    public float knockPower;
    
    public void ShootGun()
    {
        for (int i = 0; i <Random.Range(5,8); i++)
        {
            float spreadAngle = Random.Range(-SpreadAngle, SpreadAngle);

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, spreadAngle));

            EnemyBullet bullet = PoolManager.Instance.Pop("Enemybullet") as EnemyBullet;
            
            rotation *= transform.rotation;
            bullet.InitAndFire(transform,rotation,1,knockPower);
        
        }
        bulletCount--;
    }


    public void Reload()
    {
        bulletCount = 3;
    }
    

    public bool ReloadCheck()//장전을 해야되면 true, 아니면 false
    {
        return bulletCount < 1;
    }
}
public class SharedGun : SharedVariable<SawedOff>
{
    public static implicit operator SharedGun(SawedOff value)
    {
        return new SharedGun {Value = value};
    }
}
