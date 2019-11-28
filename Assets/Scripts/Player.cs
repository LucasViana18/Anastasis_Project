using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Instance variables
    [SerializeField] private float moveSpeed = 20f;
    private CharacterController controller;

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

        // Movement input
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        // Calculation of movement
        move = transform.right * moveX + transform.forward * moveZ;

        // Action of movement to the character controller
        controller.Move(Vector3.ClampMagnitude(move, 1f) * moveSpeed * Time.deltaTime);
    }
}
