using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public NavMeshAgent agent;
    public GameObject target;

    public float health = 15f;
    public float distance = 5f;
    //public GameObject healthBarUi;
    // public Slider HPBar;  enemy HP bar

    //private float damage;
    //private float spawnRate = 2f;
    //float nextSpawn = 1.5f;

    //private void Start()
    //{
    //    HPBar.value = health;
    //}
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        agent.SetDestination(target.transform.position);
        if (dist > distance)
            EnemyWalk();
        else if (dist <= distance)
            GiveDamage();
    }
    private void EnemyWalk()
    {
        agent.Resume();
    }
    //method when Player hit Enemy
    //public void TakeGamege(float amount)
    //{
    //    health -= amount;
    //    HPBar.value = health;
    //    if (health <= 0f)
    //        Die();
    //}
    private void GiveDamage()
    {
        agent.Stop();

        // method when Enemy ready give damage to Player with reload attake
        //if (Time.time > nextSpawn)
        //{
        //    nextSpawn = Time.time + spawnRate;
        //    // create animation and after finish animation give damage
        //    UserController user = target.transform.GetComponent<UserController>();
        //    damage = Random.Range(2, 5);
        //    user.takeDamage(damage);
        //}
    }
    //when HP bar is 0
    //void Die()
    //{
    //    Destroy(gameObject);
    //}
}
