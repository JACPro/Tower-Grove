using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables for input movement
    [SerializeField] CharacterController controller;    
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;

    //Variables for checking if player on ground
    [SerializeField] float gravity= -9.81f; 
    Vector3 velocity;

    //Variables for checking if player on ground
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.04f;
    [SerializeField] LayerMask groundMask;

    bool isGrounded;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }        

        //Handle Input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //Apply movement
        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        //Gravity        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
