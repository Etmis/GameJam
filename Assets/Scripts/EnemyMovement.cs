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
        List<Transform> waypoints = new List<Transform>();

        for (int i = 1; i <= FindObjectsOfType<Transform>().Where(t => t.name.StartsWith("point")).Count(); i++)
        {
            Transform waypoint = FindObjectsOfType<Transform>().Where(t => t.name == "point" + i).FirstOrDefault();
            if (waypoint != null)
            {
                waypoints.Add(waypoint);
            }
        }

        agentPoints = waypoints;
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
