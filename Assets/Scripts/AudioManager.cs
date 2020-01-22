using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    private void Start()
    {
        // Goes through every clip and adds to the new audio source
        foreach(Sound s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Audio;

            s.Source.volume = s.Volume;
        }
    }

    public void Play(string name)
    {
        //Plays the sound
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null) return;
        s.Source.Play();
    }
}
