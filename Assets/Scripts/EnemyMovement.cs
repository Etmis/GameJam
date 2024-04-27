using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;

    List<Transform> agentPoints = new List<Transform>();

    int currentDestinationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agentPoints = new List<Transform>(FindObjectsOfType<Transform>().Where(t => t.name.StartsWith("point")));
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
