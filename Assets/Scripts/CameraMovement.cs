using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Instance variables
    [SerializeField] private float sensibility = 100f;
    [SerializeField] private Transform body;
    private float verticalRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Local variables
        float mouseX;
        float mouseY;

        // Mouse input
        mouseX = Input.GetAxis("Mouse X") * sensibility * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensibility * Time.deltaTime;

        // Process of calculation and clamp of the x axis rotation of camera
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        // Rotation of the camera or player
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
