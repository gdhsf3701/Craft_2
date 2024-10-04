using UnityEngine;

public class EnemyBullet : MonoBehaviour, Ipoolable
{
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _lifeTime = 2f;

    [SerializeField] private string _poolName = "Enemybullet";
    public string PoolName => _poolName;
    public GameObject ObjectPrefab => gameObject;


    private DamageCaster _damageCaster;
    private Rigidbody2D _rigidBody;

    private int _damage;
    private float _knockPower;
    private Vector2 _fireDirection;

    private bool _isDead = false;
    private float _timer = 0;
    private void Awake()
    {
        _damageCaster = transform.Find("DamageCaster").GetComponent<DamageCaster>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void InitAndFire(Transform firePosTrm,float x, int damage, float knockBackPower)
    {
        _damage = damage;
        _knockPower = knockBackPower;
        transform.position = firePosTrm.position;
        _fireDirection = new Vector2(x, 0).normalized;
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = _fireDirection* _moveSpeed;
        _timer += Time.fixedDeltaTime;

        if (_timer >= _lifeTime)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead) return;
        _damageCaster.CastDamage(_damage, _knockPower);
        DestroyBullet();
    }
    public void ResetItem()
    {
        _isDead = false;
        _timer = 0;
    }
    private void DestroyBullet()
    {
        _isDead = true;
        PoolManager.Instance.Push(this);
    }
}
