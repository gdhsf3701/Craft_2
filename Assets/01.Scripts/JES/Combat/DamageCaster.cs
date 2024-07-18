using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    public ContactFilter2D filter;
    public float damageRadius;
    public int detectcount = 1;

    private Collider2D[] _colliders;

    private void Awake()
    {
        _colliders = new Collider2D[detectcount];
    }

    public bool CastDamage(int damage, float knockbackPower)
    {
        int cnt = Physics2D.OverlapCircle(transform.position, damageRadius, filter, _colliders);


        for (int i = 0; i < cnt; i++)
        {
            if (_colliders[i].TryGetComponent(out Health health))
            {
                Vector2 direction = _colliders[i].transform.position - transform.position;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, direction.magnitude, filter.layerMask);

                health.TakeDamage(damage, hit.normal, hit.point, knockbackPower);
            }

        }
        return cnt > 0;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
        Gizmos.color = Color.white;
    }
#endif
}
