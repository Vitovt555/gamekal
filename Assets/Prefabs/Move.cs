using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
       
       public Transform goal;
       
       void Start () {
          UnityEngine.AI.NavMeshAgent enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
          enemy.destination = goal.position; 
       }
    
}
