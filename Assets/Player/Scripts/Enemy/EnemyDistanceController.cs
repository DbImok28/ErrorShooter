using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyDistanceController : EnemyInterface
{

    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Transform target = null;   

    public float health = 15f;
    [SerializeField] public float distance = 5f;
    //public GameObject healthBarUi;
    // public Slider HPBar;  enemy HP bar

    //private float damage;
    private float spawnRate = 2f;
    float nextSpawn = 1.5f;

    private void Start()
    {
        //HPBar.value = health;
        if (agent == null)
            if (!TryGetComponent(out agent))
                print(name + " needs a navmesh agent!");
    }

    private void Update()
    {
        if (target == null)
            return;
        if (Vector3.Distance(target.transform.position, transform.position)<distance)
        {
            Vector3 newPos = transform.position + (transform.position-target.position);
            EnemyWalk(newPos);
        }
        else
            EnemyAttack();
    }

    public override void EnemyWalk(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
    }

    public override void EnemyAttack()
    {
        agent.isStopped = true;

        // method when Enemy ready give damage to Player with reload attake
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            // create animation and after finish animation give damage
            //UserController user = target.transform.GetComponent<UserController>();
            //damage = Random.Range(2, 5);
            //user.takeDamage(damage);
        }
    }

    public override void EnemyDie()
    {
        Destroy(gameObject);
    }

    public override void EnemyTakeDie()
    {
        //health -= amount;
        //    HPBar.value = health;
        //    if (health <= 0f)
        //        Die();
    }
}
