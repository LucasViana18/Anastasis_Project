using UnityEngine;

/// <summary>
/// Scripts that supports the detection mechanic
/// </summary>
public class Item : MonoBehaviour
{
    // Instance variable
    [SerializeField] private ParticleSystem myParticles;

    /// <summary>
    /// Awake - first call
    /// </summary>
    private void Awake()
    {
        myParticles.Stop();
    }

    /// <summary>
    /// Glows when the certain object is near
    /// </summary>
    /// <param name="inRange">If its in range of ceratin object</param>
    public void Glow(bool inRange)
    {
        if (inRange && myParticles.isStopped)
            myParticles.Play();
        else if (!inRange && myParticles.isPlaying)
            myParticles.Stop();
    }
}
