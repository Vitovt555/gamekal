using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrul : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    private NavMeshAgent agent;
    public Transform player;
    Vector2 patrolVector;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        patrolVector = moveSpots[randomSpot].position;
        agent.SetDestination(patrolVector);
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
    }
}