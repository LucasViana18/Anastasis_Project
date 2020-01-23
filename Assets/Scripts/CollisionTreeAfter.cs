using UnityEngine;

/// <summary>
/// Script for detection of collision with the tree after the amulet
/// </summary>
public class CollisionTreeAfter : MonoBehaviour
{
    // Instance variables
    private PlayerInteractions player;

    /// <summary>
    /// Awake - first called
    /// </summary>
    public void Awake()
    {
        player = FindObjectOfType<PlayerInteractions>();
    }

    /// <summary>
    /// On trigger with the collider
    /// </summary>
    /// <param name="other">object that collided</param>
    private void OnTriggerEnter(Collider other)
    {
        // Case is the player and has the amulet
        if (other.CompareTag("Player") && player.ConfirmAmulet)
            FindObjectOfType<AudioManager>().Play("Have Amulet");
        else if (other.CompareTag("Player") && !player.ConfirmAmulet)
            FindObjectOfType<AudioManager>().Play("No Amulet");
    }
}
