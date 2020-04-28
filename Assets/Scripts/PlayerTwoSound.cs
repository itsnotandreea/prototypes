using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoSound : MonoBehaviour
{
    public AudioClip run,
                     jump,
                     bounce,
                     slide,
                     empty;

    public AudioSource musicSource;         //the audio source that plays the clips

    private AudioClip currentClip;          //the current clip to be played

    void Start()
    {
        //accesses the audio source and sets the initial clip
        currentClip = empty;
    }

    public void AssignClip(int button)
    {
        /*
        if (button == 0)
        {
            currentClip = jump;
            musicSource.clip = currentClip;
            musicSource.Play();
        }
        else if (button == 1)
        {
            if (!musicSource.isPlaying || musicSource.clip != run)
            {
                currentClip = run;
                musicSource.clip = currentClip;
                musicSource.Play();
            }
        }
        else if (button == 2)
        {
            if (!musicSource.isPlaying || musicSource.clip != run)
            {
                currentClip = run;
                musicSource.clip = currentClip;
                musicSource.Play();
            }
        }
        else if (button == 3)
        {
            currentClip = slide;
            musicSource.clip = currentClip;
            musicSource.Play();
        }
        else if (button == 100)
        {
            currentClip = empty;
            musicSource.clip = currentClip;
            musicSource.Play();
        }
        */
    }
}
