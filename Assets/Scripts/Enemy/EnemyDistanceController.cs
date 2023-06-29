using UnityEngine;

public class EnemyDistanceController : EnemyInterface
{
    private void Update()
    {
        if (target == null)
            return;
        float dis = Vector3.Distance(target.transform.position, transform.position);
        if(dis >= distanceForAttake && !IsRunAway && dis<distance)
        {
            RotateToTarget();
            if (IsViewTarget())
                EnemyAttack();
            else
                EnemyWalk(target.position);
        }
        else if (dis < distanceForAttake && dis>distanceForFastAttake)
        {   if(!IsRunAway)
                EnemyRunAway();
        }
        else if (dis <= distanceForFastAttake)
        {
            RotateToTarget();
            EnemyAttack();
            ResetIsRunAway();
        }

        if (!agent.pathPending && agent.remainingDistance < 1f)
            ResetIsRunAway();

            Vector3 forward = transform.TransformDirection(Vector3.forward) * 1000;
            Debug.DrawRay(transform.position, forward, Color.green);
    } 
}
