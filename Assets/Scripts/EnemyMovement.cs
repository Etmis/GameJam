using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    List<Transform> agentPoints = new List<Transform>();

    [SerializeField]
    NavMeshAgent agent;

    int currentDestinationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetNextDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            SetNextDestination();
        }
    }

    void SetNextDestination()
    {
        if (currentDestinationIndex < agentPoints.Count)
        {
            agent.SetDestination(agentPoints[currentDestinationIndex].position);
            agent.transform.LookAt(agentPoints[currentDestinationIndex].position);
            currentDestinationIndex++;
        }
    }
}
