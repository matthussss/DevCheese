using UnityEngine;
// import for Array.Find
using System;

public class AudioManager : MonoBehaviour
{
    // we can make this class static, that way ALL game objects can use its functions
    public static AudioManager Instance;

    // list of music and sound effects
    public Sound[] musicSounds, sfxSounds;

    // stores AudioSource components, which are game objects that play sound wherever they are
    // on the board. Kind of like a speaker of sorts
    public AudioSource musicSource, sfxSource;

    // Function called BEFORE Start()
    private void Awake()
    {
        // we are using an instance of this component to initialize Instance
        // if its empty, we initialize it here
        if (Instance == null)
        {
            Instance = this;

            // this allows us to access Instance in different scenes!
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // plays our bg music as we start
    public void Start()
    {
        playMusic("music1");
    }

    // Plays an audio clip (music specifically) according to its file name
    public void playMusic(string name)
    {
        // Some working function that apparently finds an item in array
        Sound s = Array.Find(musicSounds, x => x.name == name);

        // if s exists in list
        if (s != null)
        {
            // Loads the source with the soundclip
            // Analogy: connecting your Headphones (musicSource) with your phone (s.clip)
            musicSource.clip = s.clip;

            // dont forget to enable "Loop" in the Unity Inspector
            musicSource.Play();
        }
        else
        {
            Debug.Log("Music Not Found!");
        }
    }

    // Plays an audio clip (sfx specifically) according to its file name
    public void playSfx(string name)
    {
        // Some working function that apparently finds an item in array
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        // if s exists in list
        if (s != null)
        {
            // plays audio clip once
            sfxSource.PlayOneShot(s.clip);
        }
        else
        {
            Debug.Log("Music Not Found!");
        }
    }
}
