using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        transform.parent.GetComponent<Cliff>().OnChildTrigger(this, other);
    }
}
