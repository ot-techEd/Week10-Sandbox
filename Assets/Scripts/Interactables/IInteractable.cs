using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact(RaycastHit hit);

    public void OnHoverEnter(Material hoverMaterial);

    public void OnHoverExit();
}
