using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckRange : Conditional
{
   public SharedTransform target;
   public SharedEnemy _enemy;
   public SharedBool isPlayerSpoted;

   public float range =5f;

   
   public override TaskStatus OnUpdate()
   {
      Vector2 playerPosition = target.Value.position;
      Vector2 myPositionp = transform.position;
      Vector2 direction = playerPosition - myPositionp;

      
      if (direction.magnitude < range)
      {
         isPlayerSpoted.Value = true;
         return TaskStatus.Success;
      }
      else
      {
         return TaskStatus.Failure;
      }
   }

   public override void OnDrawGizmos()
   {
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(transform.position,range);
      Gizmos.color = Color.white;
   }
}
