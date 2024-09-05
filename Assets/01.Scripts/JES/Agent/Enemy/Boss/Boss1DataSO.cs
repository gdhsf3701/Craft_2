using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Boss1Gun")]
public class Boss1DataSO : ScriptableObject
{
    public SawedOff gun = new SawedOff();
    
    public int nextGunIndex;

    public Vector2 muzzlePos;
}
