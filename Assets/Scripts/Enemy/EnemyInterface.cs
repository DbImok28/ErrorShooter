using UnityEngine;
using UnityEngine.AI;
public abstract class EnemyInterface : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Transform target = null;

    [SerializeField] public float distance = 5f;

    [SerializeField] private HealthComponent EnemyHP;

    private float spawnRate = 2f;
    float nextSpawn = 1.5f;

    private void Start()
    {
        //HPBar.value = health;
        if (agent == null)
            if (!TryGetComponent(out agent))
                print(name + " needs a navmesh agent!");

        EnemyHP = gameObject.GetComponent<HealthComponent>();
        EnemyHP.OnDie.AddListener(EnemyDie);
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    

    public void EnemyWalk(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
    }

    public void EnemyAttack()
    {
        agent.isStopped = true;

        // method when Enemy ready give damage to Player with reload attake
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            print("Hit player from "+gameObject.name);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

    public void EnemyTakeDie()
    {
    }
}
