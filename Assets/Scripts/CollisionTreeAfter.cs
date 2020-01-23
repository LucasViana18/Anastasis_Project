using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTreeAfter : MonoBehaviour
{
    private PlayerInteractions player;

    public void Awake()
    {
        player = FindObjectOfType<PlayerInteractions>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && player.ConfirmAmulet)
            FindObjectOfType<AudioManager>().Play("Have Amulet");
        else if (other.CompareTag("Player") && !player.ConfirmAmulet)
            FindObjectOfType<AudioManager>().Play("No Amulet");
    }
}
