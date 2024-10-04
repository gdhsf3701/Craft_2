using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Player/DamageData")]
public class PlayerDamageSO : ScriptableObject
{
   public int damage;
   public float knockPower;

   public Vector2 damagePos;
   public float damageRadius;

   public float attackCooldown;
}
