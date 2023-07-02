using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMeleeController : EnemyInterface
{
    private void Update()
    {
        if (target == null)
            return;

        float dis = Vector3.Distance(target.position, transform.position);
        if (dis <= distance && dis > distanceForFastAttake)
        {
            EnemyWalk(target.position);
        }
        else if (dis > distance)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        else if (dis <= distanceForFastAttake)
        {
            RotateToTarget();
            EnemyAttack();
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

}
