using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ParticleSystem myParticles;

    private void Awake()
    {
        myParticles.Stop();
    }

    public void Glow(bool inRange)
    {
        if (inRange && myParticles.isStopped)
            myParticles.Play();
        else if (!inRange && myParticles.isPlaying)
            myParticles.Stop();
    }
}
