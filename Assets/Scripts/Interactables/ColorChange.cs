using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : InteractableItem
{
    public override void Interact(RaycastHit hit)
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        Debug.Log("COLOR CHANGE IS INTERACTING");
    }
}
