using UnityEngine;
using System;

/// <summary>
/// Manages the audio in the game
/// </summary>
public class AudioManager : MonoBehaviour
{
    // Instance variables
    [SerializeField] private Sound[] sounds;

    /// <summary>
    /// Start - first call after Awake
    /// </summary>
    private void Start()
    {
        // Goes through every clip and adds to the new audio source
        foreach(Sound s in sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Audio;

            s.Source.volume = s.Volume;
        }

        // Plays the first dialog of the game
        Play("First Dialog");
    }

    /// <summary>
    /// The play button for certain sound
    /// </summary>
    /// <param name="name">sound name</param>
    public void Play(string name)
    {
        //Plays the sound
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null) return;
        s.Source.Play();
    }
}
