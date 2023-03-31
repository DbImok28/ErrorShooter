using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class EnemyDistanceController : EnemyInterface
{
    private void Update()
    {
        if (target == null)
            return;
        if (Vector3.Distance(target.transform.position, transform.position) < distance)
        {
            Vector3 newPos = transform.position + (transform.position - target.position);
            EnemyWalk(newPos);
        }
        else
            EnemyAttack();
    }

}
