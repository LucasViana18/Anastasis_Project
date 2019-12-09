using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Instance variables
        //Character movement
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private LayerMask checkMask;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private Transform checkBody;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
        //Character mechanics
    private LampLight lampLight;
    private IntangibleForm intangibleForm;
        //Input variables
    private float moveX;
    private float moveZ;
    private Vector3 move;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        lampLight = GetComponent<LampLight>();
        intangibleForm = GetComponent<IntangibleForm>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(checkBody.position, checkRadius, checkMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        // Calculation of movement
        move = transform.right * moveX + transform.forward * moveZ;

        // Action of movement to the character controller
        controller.Move(Vector3.ClampMagnitude(move, 1f) * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Update()
    {
        // Movement input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        //Lamp Light input
        if (Input.GetKeyDown(KeyCode.Q))
            lampLight.ChangeLight();
        //Intangible Form input
        if (Input.GetKeyDown(KeyCode.E))
            intangibleForm.ChangeForm();
    }
}
