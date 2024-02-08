using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnit : MonoBehaviour
{
    [SerializeField] private Transform agentDestination;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = agentDestination.position;
    }

    public void MoveUnitToDestination(Vector3 newDestination)
    {
        agentDestination.position = newDestination;
    }
}
