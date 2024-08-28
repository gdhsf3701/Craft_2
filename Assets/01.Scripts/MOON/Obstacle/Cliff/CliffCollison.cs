using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffCollison : MonoBehaviour
{
    public int count = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponentInParent<Cliff>().OnChildTrigger(this, other);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponentInParent<Cliff>().OnChildCollison(this, collision);
    }
}
