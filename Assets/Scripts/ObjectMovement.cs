using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5.0f; // Adjust this to set the movement speed
    public float jumpForce = 10.0f;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Get the object's current Transform
        Transform objectTransform = transform;

        // Calculate the new position based on user input or any other logic
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 newPosition = objectTransform.position + moveDirection * moveSpeed * Time.deltaTime;

        // Update the object's position
        objectTransform.position = newPosition;

        // Check if the object is grounded (you need to implement this)
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            isGrounded = true;
        }
    }
}
