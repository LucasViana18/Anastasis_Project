﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{

    [SerializeField] private Transform Destination;
    private Vector3 postLastFame;
    [SerializeField] private Player player;
    

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            player.enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = Destination.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log("YH tou a funcionar");
            var delta = Input.mousePosition - postLastFame;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.002f, axis) * transform.rotation;

        }

        if (Input.GetKeyDown("space"))
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            player.enabled = true;
        }
    }
}