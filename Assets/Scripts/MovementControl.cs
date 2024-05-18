using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public CharacterController characterController;

    private float walkSpeed = 5f;
    private float accelerationDueToGravity = -9.81f;
    private float jumpHeight = 2f;

    public Transform groundCheck;
    public LayerMask groundMask;
    private float groundCheckRadius = 0.3f;
    private float isGroundedTimeoutExpiry = 0f;
    private float isGroundedTimeoutDuration = 0.2f;

    private Vector3 velocity = Vector3.zero;

    void Update() {
        handleWASDInput();
        handleVerticalVelocity();
    }

    private void handleWASDInput() {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        Vector3 movementDirection = transform.right * xMovement + transform.forward * zMovement;
        characterController.Move(movementDirection * Time.deltaTime * walkSpeed);
    }

    private void handleVerticalVelocity() {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (!isGrounded) {
            velocity.y += accelerationDueToGravity * Time.deltaTime;
        } else if (Time.time > isGroundedTimeoutExpiry){
            velocity.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            velocity.y = Mathf.Sqrt(-2 * jumpHeight * accelerationDueToGravity);
            isGroundedTimeoutExpiry = Time.time + isGroundedTimeoutDuration;
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
