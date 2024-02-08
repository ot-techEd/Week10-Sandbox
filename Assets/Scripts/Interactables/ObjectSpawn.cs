using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : InteractableItem
{
    [SerializeField] private Transform objectToSpawn;


    private Transform objectSpawnTransform;
    private bool isObjectSpawned = false;
    public override void Interact(RaycastHit hit)
    {
        if (isObjectSpawned)
        {
            objectSpawnTransform.position = hit.point;
        }
        else
        {
            objectSpawnTransform = Instantiate(objectToSpawn, hit.point, Quaternion.identity);
            isObjectSpawned = true;
        }

        GameManager.GetInstance().GetPlayerUnit().MoveUnitToDestination(objectSpawnTransform.position);

        Debug.Log("OBJECT SPAWN IS INTERACTING");
    }
}
