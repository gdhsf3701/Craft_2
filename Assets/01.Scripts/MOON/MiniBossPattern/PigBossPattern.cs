using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBossPattern : MonoBehaviour
{
    GameObject patternRange;
    bool coolTime;
    private float attackTimer = 0f;
    private float attackDelay = 2.8f;
    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            attackTimer = 0f;
        }

    }
    public void AttackColliderOnOff()
    {
        patternRange.SetActive(!patternRange.activeInHierarchy);
    }
}
