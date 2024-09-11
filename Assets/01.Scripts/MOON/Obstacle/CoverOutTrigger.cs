using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverOutTrigger : MonoBehaviour
{
    [SerializeField] private Vector2 _checkerSize;

    [SerializeField] private LayerMask _whatIsEnemy;
    private void Update()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, _checkerSize, 0, _whatIsEnemy);
        if (collider != null)
        {
            GetComponentInParent<Cover>().ChangeString();
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _checkerSize);
        Gizmos.color = Color.white;
    }
}
