using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CSI_smoke : MonoBehaviour
{
    private CapsuleCollider2D _collider;
    private LayerMask _hidelayerMask,_playerlayerMask;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _hidelayerMask = LayerMask.NameToLayer("HidePlayer");
        _playerlayerMask = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.name);
        if (other.gameObject.layer == _playerlayerMask)
        {
            other.gameObject.layer = _hidelayerMask;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == _hidelayerMask)
        {
            other.gameObject.layer = _playerlayerMask;
            
        }
    }
}
