using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "SO/Enemy/Data")]
public class BossDataSO : ScriptableObject
{
    public float range;
    public float damage;
    public float walkSpeed;
    public float runSpeed;
}