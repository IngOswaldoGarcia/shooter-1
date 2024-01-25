using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 8.0f; // Adjust this to set the movement speed
    public float runSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public float jumpHeight = 1.9f;
    public float gravityScale = -20f;
    Vector3 moveInput = Vector3.zero;
    CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        if(characterController.isGrounded){
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            if(Input.GetButton("Sprint")){
                moveInput = transform.TransformDirection(moveInput) * runSpeed;
            }else{
                moveInput = transform.TransformDirection(moveInput) * moveSpeed;
            }

            // Check if the object is grounded (you need to implement this)
            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }
        }
        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

}
