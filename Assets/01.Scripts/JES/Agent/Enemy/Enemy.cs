using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : Agent
{
    public UnityEvent FinalDeadEvent;

    [Header("Attack Settings")]
    public float detectRadius;
    public float attackRadius;
    public float attackCooldown,KnockbackPower;
    public int attackDamage;
    public ContactFilter2D contactFilter;

    [HideInInspector] public Transform targerTrm = null;

    protected int _enemyLayer;


    private Collider2D[] _colliders;

    [Header("Gun Settings")]
    [SerializeField]
    private Transform muzzleTrm;
    [SerializeField]
    private int bulletDamage;
    [SerializeField]
    private float bulletKnockBack;

    protected override void Awake()
    {
        base.Awake();
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        _colliders = new Collider2D[1];
    }

    public Collider2D GetPlayerInRange()
    {
        int count = Physics2D.OverlapCircle(transform.position,detectRadius,contactFilter,_colliders);
        return count >0? _colliders[0]: null;
    }


    public abstract void AnimationEndTrigger();
    public void SetDead(bool value)
    {
        IsDead = value;
        CanStateChangeable = !value;
    }

    public virtual void Attack()
    {
        DamageCasterCompo.CastDamage(attackDamage, KnockbackPower);
    }

    public virtual void FireBullet()
    {
        float x = targerTrm.position.x-transform.position.x;
        EnemyBullet bullet = PoolManager.Instance.Pop("Enemybullet") as EnemyBullet;
        bullet.InitAndFire(muzzleTrm,x,bulletDamage, bulletKnockBack);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius-5);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius-8);
    }
#endif

}
