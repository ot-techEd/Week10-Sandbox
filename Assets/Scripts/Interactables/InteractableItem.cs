using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    protected Material defaultMaterial;
    protected MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }
    public virtual void Interact(RaycastHit hit)
    {
        
    }


    public virtual void OnHoverEnter(Material hoverMaterial)
    {
        meshRenderer.material = hoverMaterial;
    }

    public virtual void OnHoverExit()
    {
        meshRenderer.material = defaultMaterial;
    }
}
