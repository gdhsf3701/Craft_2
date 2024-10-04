using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Moon_Enemy : MonoBehaviour, Ipoolable
{
    [SerializeField] private string _poolname = "NormalEnemy";
    public string PoolName => _poolname;

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
    }
}
