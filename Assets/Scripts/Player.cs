using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Instance variables
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask checkMask;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private Transform checkBody;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Local variables
        float moveX;
        float moveZ;
        Vector3 move;

        isGrounded = Physics.CheckSphere(checkBody.position, checkRadius, checkMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Movement input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        // Calculation of movement
        move = transform.right * moveX + transform.forward * moveZ;

        // Action of movement to the character controller
        controller.Move(Vector3.ClampMagnitude(move, 1f) * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
