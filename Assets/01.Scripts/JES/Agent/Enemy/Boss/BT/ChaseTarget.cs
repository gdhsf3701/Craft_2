using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class ChaseTarget : Action
{
    public SharedTransform target;
    public SharedEnemy enemy;

    private BossDataSO _enemyData;
    private BossMovement _movement;
    
    public override void OnAwake()
    {
        _enemyData = enemy.Value.enemyData;
        _movement = enemy.Value.GetCompo<BossMovement>();
    }
    public override TaskStatus OnUpdate()
    {
        Vector2 playerPosition = target.Value.position;
        Vector2 myPositionp = transform.position;
        Vector2 direction = playerPosition - myPositionp;
        
        _movement.SetVelocity(direction.normalized * _enemyData.runSpeed);
        
        return TaskStatus.Running;
    }
    public override void OnEnd()
    {
        _movement.SetVelocity(Vector2.zero);
    }
}
