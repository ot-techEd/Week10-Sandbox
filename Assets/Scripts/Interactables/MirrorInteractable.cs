using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInteractable : InteractableItem
{
    [SerializeField] private GameObject camObject;
    [SerializeField] private Animator mirrorAnim;

    private bool isInteractable = false;

    public override void Interact(RaycastHit hit)
    {
        if (!isInteractable)
            return;


        
        OpenMirrorCover(isInteractable);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            isInteractable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            isInteractable = false;
            StartCoroutine(CloseMirrorCover(isInteractable));
        }
    }
    public void OpenMirrorCover(bool doorState)
    {
        camObject.SetActive(doorState);
        mirrorAnim.SetBool("OpenDoor", doorState);
    }

    public IEnumerator CloseMirrorCover(bool doorState)
    {
        mirrorAnim.SetBool("OpenDoor", doorState);
        float closeDuration = mirrorAnim.GetCurrentAnimatorStateInfo(0).length;

        Debug.Log("Our transition float is" + closeDuration);
        yield return new WaitForSeconds(closeDuration);

        camObject.SetActive(doorState);
    }
}
