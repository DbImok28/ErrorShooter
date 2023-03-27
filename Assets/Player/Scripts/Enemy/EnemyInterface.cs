using UnityEngine;

public abstract class EnemyInterface : MonoBehaviour
{
    public abstract void EnemyWalk(Vector3 vector3);
    public abstract void EnemyAttack();
    public abstract void EnemyDie();
    public abstract void EnemyTakeDie();
}
