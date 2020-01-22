using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // Name
    [SerializeField] private string name;
    public string Name { get => name; }

    // Audio clip
    [SerializeField] private AudioClip audio;
    public AudioClip Audio { get => audio; }

    // Volume
    [Range(0f, 1f)]
    [SerializeField] private float volume;
    public float Volume { get => volume; }

    // Audio Source
    [HideInInspector]
    public AudioSource Source { get; set; }
}
