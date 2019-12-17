using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable, IPromoteDialogue
{
    private ParticleSystem myParticles;

    private void Awake()
    {
        myParticles = GetComponent<ParticleSystem>();
        myParticles.Stop();
    }

    public void Glow(bool inRange)
    {
        if (inRange && myParticles.isStopped)
            myParticles.Play();
        else if (!inRange && myParticles.isPlaying)
            myParticles.Stop();
    }

    public string Interact()
    {
        throw new System.NotImplementedException();
    }

    public string PromoteDialogue()
    {
        throw new System.NotImplementedException();
    }
}
