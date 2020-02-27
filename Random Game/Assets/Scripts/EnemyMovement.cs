using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);

    }
}
