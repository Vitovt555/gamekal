using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ii : MonoBehaviour
{
     private NavMeshAgent agent;
     public Transform player;
     
     
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
         agent.updateRotation = false;
         agent.updateUpAxis = false;
           
    }
    void Update()
    {
         agent.SetDestination(player.position);
    }
    
}
