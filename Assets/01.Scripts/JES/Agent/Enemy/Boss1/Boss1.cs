using UnityEngine;
using UnityEngine.PlayerLoop;
using Update = Unity.VisualScripting.Update;

public class Boss1 : Boss
{
    public float SpreadAngle=15f;
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();            
        
        stateMachine.AddState(EnemyEnum.Chase,new Boss1ChaseState(this,stateMachine,"Chase"));
        stateMachine.AddState(EnemyEnum.Attack1, new Boss1Attack1State(this,stateMachine,"Attack1"));
        stateMachine.AddState(EnemyEnum.Attack2, new Boss1Attack2State(this,stateMachine,"Attack2"));
        
        stateMachine.Initalize(EnemyEnum.Chase,this);
    }

    public override void FireBullet()
    {
        for (int i = 0; i < Random.Range(5, 8); i++)
        {
            float spreadAngle = Random.Range(-SpreadAngle, SpreadAngle);

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, spreadAngle));

            EnemyBullet bullet = PoolManager.Instance.Pop("Enemybullet") as EnemyBullet;
        
            bullet.transform.position = muzzleTrm.position;
            bullet.transform.rotation = rotation * muzzleTrm.rotation;
        }
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(EnemyEnum.Attack2);
        }
    }
}
