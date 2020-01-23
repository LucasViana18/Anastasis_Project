using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTree : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            FindObjectOfType<AudioManager>().Play("Tree Dialog");
    }
}
