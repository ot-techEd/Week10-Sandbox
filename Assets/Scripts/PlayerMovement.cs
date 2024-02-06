using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    float horizontalInput, verticalInput;
    private float speed;
    [SerializeField] private float normalSpeed;

    [SerializeField] private float runningSpeed;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalInput, 0, verticalInput);
        if(Input.GetKey(KeyCode.Z)){
                speed = runningSpeed;
        }else{
            speed = normalSpeed;
        }

        characterController.Move(move * speed * Time.deltaTime);
    }
}
