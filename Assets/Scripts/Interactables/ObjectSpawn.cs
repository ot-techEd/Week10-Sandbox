using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : InteractableItem
{
    [SerializeField] private GameObject objectToSpawn;

    public override void Interact(RaycastHit hit)
    {
        Instantiate(objectToSpawn, hit.point, Quaternion.identity);
        Debug.Log("OBJECT SPAWN IS INTERACTING");
    }
}
