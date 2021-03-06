﻿using UnityEngine;

/// <summary>
/// Script that takes care of pick up items
/// </summary>
public class PickUpItems : MonoBehaviour
{
    // Instance variables
    [SerializeField] private Transform Destination;
    private Vector3 postLastFame;
    [SerializeField] private Player player;
    [SerializeField] private GameObject spinPanel;
    [SerializeField] private Transform camera;

    /// <summary>
    /// Update - updates every frame
    /// </summary>
    private void Update()
    {
        if (Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, 4f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                spinPanel.SetActive(true);
                player.enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                transform.position = Destination.position;
                transform.parent = GameObject.Find("Destination").transform;
            }

            if (Input.GetMouseButton(1))
            {
                var delta = Input.mousePosition - postLastFame;

                var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
                transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.002f, axis) * transform.rotation;

            }
        }
        
        if (Input.GetKeyDown("space"))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            player.enabled = true;
            spinPanel.SetActive(false);
        }
    }
}
