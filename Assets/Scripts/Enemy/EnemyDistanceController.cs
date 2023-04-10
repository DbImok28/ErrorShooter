using UnityEngine;

public class EnemyDistanceController : EnemyInterface
{
    private void Update()
    {
        float dis = Vector3.Distance(target.transform.position, transform.position);

        if (target == null)
            return;
        if(dis >= distanceForAttake && !IsRunAway)
        {
            RotateToTarget();
            if (IsViewTarget())
                EnemyAttack();
            else
                EnemyWalk(target.position);
        }
        else if (dis < distance && dis>distanceForFastAttake)
        {   if(!IsRunAway)
                EnemyRunAway();
        }
        else if(dis <= distanceForFastAttake)
        {
            RotateToTarget();
            EnemyAttack();
            ResetIsRunAway();
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            ResetIsRunAway();

            Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

}
