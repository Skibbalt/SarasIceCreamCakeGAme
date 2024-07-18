using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioSource sfxSource; 

    public AudioClip Pick; // Array of sound effect clips
    public AudioClip Drop; // Array of sound effect clips

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PickSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(Pick);

        }
    }
    
    public void DropSFX()
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(Drop);
        }
    }
}
