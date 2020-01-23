using UnityEngine;

/// <summary>
/// Script for detection of collision with the tree for the first time
/// </summary>
public class CollisionTree : MonoBehaviour
{
    /// <summary>
    /// On trigger with the collider
    /// </summary>
    /// <param name="other">object that collided</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            FindObjectOfType<AudioManager>().Play("Tree Dialog");
    }
}
