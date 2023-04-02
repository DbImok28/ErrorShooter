using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class EnemyDistanceController : EnemyInterface
{
    private void Update()
    {
        float dis = Vector3.Distance(target.transform.position, transform.position);

        if (target == null)
            return;
        if(dis >= distanceForAttake)
        {
            RotateToTarget();
            if (IsViewTarget())
                EnemyAttack();
        }
        else if (dis < distance && dis> distanceForFastAttake)
        {
            Vector3 newPos = transform.position + (transform.position - target.position);
            EnemyWalk(newPos);
        }
        else if(dis <= distanceForFastAttake)
        {
            RotateToTarget();
            EnemyAttack();
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

}
