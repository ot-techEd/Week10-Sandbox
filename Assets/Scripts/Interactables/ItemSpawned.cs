using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawned : InteractableItem
{
    public override void Interact(RaycastHit hit)
    {
        Destroy(gameObject);
    }
}
