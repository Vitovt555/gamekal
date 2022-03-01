using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrul : MonoBehaviour
{
    public float speed;
    public float retreatDistance;
    public float DetectionDistance;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public int health = 6;
    public float stoppingdistance;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    private NavMeshAgent agent;
    public Transform player;
    Vector2 patrolVector;
    private Rigidbody2D rb;
    public GameObject projectile;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        patrolVector = moveSpots[randomSpot].position;
        agent.SetDestination(patrolVector);
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots; 
    }

    void Update()
    {
        Vector2 pos = transform.position;
        if (Vector2.Distance(pos, patrolVector) < 0.1f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                patrolVector = moveSpots[randomSpot].position;
                agent.SetDestination(patrolVector);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
        



        float distanceToPlayer = Vector2.Distance(pos, player.position);
        if (distanceToPlayer <= DetectionDistance)
        { 
            agent.SetDestination(player.position);

            if (timeBtwShots <=0)
         {
                Instantiate(projectile,pos, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
         }
            else
            {
                 timeBtwShots -= Time.deltaTime;
            }
        }
        
        else if (retreatDistance >= distanceToPlayer)
        {
            agent.SetDestination(player.position);
        }

        
        else 
        {
            agent.SetDestination(patrolVector);
        }    
          
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}