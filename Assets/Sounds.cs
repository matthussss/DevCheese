// We are still using Unity API, don't forget to import this too!
using UnityEngine;

// Allows us to initialize these fields in Unity Inspector
[System.Serializable]
public class Sound
{
    public string name;

    // the actual audio file to be played
    public AudioClip clip;
}
