using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSI_well : MonoBehaviour
{
    private AgentMovement _agentMovement;
    private float slow_amount;
    private bool isuse;
    private void Awake()
    {
        _agentMovement = GameObject.FindWithTag("Player").GetComponent<AgentMovement>();
        slow_amount = _agentMovement.moveSpeed / 2;
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (!isuse)
        {
            isuse = true;
            _agentMovement.moveSpeed -= slow_amount;
            StartCoroutine("cooltime");
        }
    }

    IEnumerator cooltime()
    {
        yield return new WaitForSeconds(1);
        _agentMovement.moveSpeed += slow_amount;
        isuse = false;
    }
}
