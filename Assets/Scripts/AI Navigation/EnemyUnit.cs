using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : CharacterUnit
{
    [SerializeField] private Transform[] patrolPositions;

    [Range(0.01f, 1.0f)]
    [SerializeField] private float distanceToDestination = 0.1f;

    [SerializeField] private bool setRandomPatrol = false;

    private int currentPositionIndex = 0;
    public override void UpdateDestination()
    {
        agentDestination = patrolPositions[currentPositionIndex];
        base.UpdateDestination();
        if (agent.remainingDistance < distanceToDestination)
        {
            if (setRandomPatrol)
            {
                PatrolPositionsAtRandom();
            }
            else
            {
                PatrolPositionsDefault();
            }


        }
    }

    private void PatrolPositionsDefault()
    {
        if (currentPositionIndex < patrolPositions.Length - 1)
        {

            currentPositionIndex++;
        }
        else
        {
            currentPositionIndex = 0;
        }
    }

    private void PatrolPositionsAtRandom()
    {
        currentPositionIndex = Random.Range(0, patrolPositions.Length);
    }
}
