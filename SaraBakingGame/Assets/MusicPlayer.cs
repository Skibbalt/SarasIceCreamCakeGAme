using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance = null;

    public static MusicPlayer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MusicPlayer>();
                if (instance == null)
                {
                    GameObject go = new GameObject("MusicPlayer");
                    instance = go.AddComponent<MusicPlayer>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        // Make sure the audio source is set to play on awake and loop if desired
        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }
}
