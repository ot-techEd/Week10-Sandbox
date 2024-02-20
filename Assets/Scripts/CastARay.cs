using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastARay : MonoBehaviour
{
    [SerializeField] private Transform eyePosition;
    [SerializeField] private float rayDistance = 5.0f;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Material hoverMaterial;

    [SerializeField] private Camera cam;

    [SerializeField] private Button interactButton;

    private bool interactPressed = false;
    private RaycastHit hit;

    private IInteractable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactButton.onClick.AddListener(InteractPressed);
    }
    public void InteractPressed()
    {
        interactPressed = true;
    }

    // Update is called once per frame
    void Update()
    {
        PerformRayCastCheck();
    }

    private void PerformRayCastCheck()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, rayDistance, interactionLayer))
        {
            Hover();

            if (interactPressed == true) //INPUT
            {
                interactPressed = false;
                interactable = hit.transform.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(hit);
                }

                interactable = null;


            }

        }
        else
        {
            ExitHover();
        }
    }

    private void Hover()
    {
        if (interactable == null) //Null CHeck
        {
            interactable = hit.transform.GetComponent<IInteractable>();
        }
        
            interactable.OnHoverEnter(hoverMaterial);
    }
    private void ExitHover()
    {
        if (interactable != null)
        {
            interactable.OnHoverExit();
            interactable = null;
        }
    }

    private void ChangeInteractbleColour()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, rayDistance, interactionLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();

            }

        }
    }

    private void CastASimpleRay()
    {
        Ray ray = new Ray(eyePosition.position, transform.forward);

        if (Physics.Raycast(ray, rayDistance, interactionLayer))
        {
            Debug.Log("Raycast Active");

        }
        else
        {
            Debug.Log("Raycast Inactive");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(eyePosition.position, eyePosition.position + transform.forward * rayDistance);
    }
}
