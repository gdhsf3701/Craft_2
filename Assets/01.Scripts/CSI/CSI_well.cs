using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSI_well : MonoBehaviour
{
    private AgentMovement _agentMovement;
    float slow_amount;
    private bool isuse;
    private void Awake()
    {
        _agentMovement = PlayerManager.Instance.Player.GetComponent<AgentMovement>();
        slow_amount = 3;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _agentMovement.moveSpeed = slow_amount;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _agentMovement.moveSpeed = 7;

        }

    }

}
