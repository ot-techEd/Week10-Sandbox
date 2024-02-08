using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterUnit : MonoBehaviour
{
    [SerializeField] protected Transform agentDestination;

    [SerializeField] protected Transform rayCastOrigin;

    [Range(0f,20f)]
    [SerializeField] protected float checkDistance = 5f;

    [Range(0f, 20f)]
    [SerializeField] protected float checkRadius = 5f;

    [SerializeField] protected UnitType unitType;
    [SerializeField] protected UnitType oppositionType;
    [SerializeField] protected LayerMask layerMask;

    protected NavMeshAgent agent;
    protected RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agentDestination == null)
        {
            agentDestination = transform;

        }
    }

    // Update is called once per frame§
    void Update()
    {
        UpdateDestination();
        CheckForOpposition();
    }

    public virtual void MoveUnitToDestination(Vector3 newDestination)
    {
        agentDestination.position = newDestination;
    }

    public virtual void UpdateDestination()
    {
        agent.destination = agentDestination.position;
    }

    public virtual void CheckForOpposition()
    {
        if (Physics.SphereCast(rayCastOrigin.position, checkRadius, rayCastOrigin.forward, out hit, checkDistance, layerMask))
        {
            CharacterUnit unitFound = hit.transform.GetComponent<CharacterUnit>();

            if (unitFound != null)
            {
                if ( unitFound.GetUnitType() == oppositionType)
                {
                    Debug.Log($"I , the {unitType} found My Opposition{oppositionType}");
                }
            }
            else
            {
                Debug.Log("No Unit Found");
            }

        }
    }


    public virtual void Attack()
    {

    }

    public UnitType GetUnitType()
    {
        return unitType;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(rayCastOrigin.position, checkRadius);
        Gizmos.DrawWireSphere(rayCastOrigin.position + rayCastOrigin.forward * checkDistance, checkRadius);
        Gizmos.DrawLine(rayCastOrigin.position, rayCastOrigin.position + rayCastOrigin.forward * checkDistance);
        
    }
}

public enum UnitType
{
    Unknown,
    PlayerUnit,
    EnemyUnit
}