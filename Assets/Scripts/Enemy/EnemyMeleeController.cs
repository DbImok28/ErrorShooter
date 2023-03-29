using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeController : EnemyInterface
{
    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) > distance)
            EnemyWalk(target.position);
        else
            EnemyAttack();

    }
}
