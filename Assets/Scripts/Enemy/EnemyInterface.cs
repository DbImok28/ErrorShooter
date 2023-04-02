using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyInterface : MonoBehaviour
{
    [SerializeField] public NavMeshAgent agent;
    [SerializeField] public Transform target = null;

    [SerializeField] public float distance = 10f;
    [SerializeField] public float distanceForAttake = 10f;
    [SerializeField] public float distanceForFastAttake = 3f;

    [SerializeField] private HealthComponent EnemyHP;

    [SerializeField] private RaycastHit raycastHit;

    [SerializeField] public Transform[] points;
    [SerializeField] private int destPoint = 0;

    public float rotationSpeed = 5f;

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

        GotoNextPoint();
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public bool IsViewTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(hit.collider.tag == "Player")
                return true;
        }
        return false;
    }

    public void EnemyWalk(Vector3 pos)
    {
        agent.Resume();
        agent.SetDestination(pos);
    }

    public void RotateToTarget()
    {
        transform.LookAt(new Vector3(target.position.x,target.position.y+1.5f,target.position.z));
        //smooth rotate
        //var targetRotation = Quaternion.LookRotation(new Vector3(target.position.x, target.position.y + 1.5f, target.position.z) - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
    }

    public void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void EnemyAttack()
    {
        agent.Stop();

        // method when Enemy ready give damage to Player with reload attake
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            print(name+" hit player");
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

    public void EnemyTakeDamage()
    {
    }
}
