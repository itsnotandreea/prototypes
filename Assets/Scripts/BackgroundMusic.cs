using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip Cmaj,
                     Amin;

    private PlayerOneController pOneController;

    public AudioSource MusicSource;         //the audio source that plays the clips

    private AudioClip currentClip;          //the current clip to be played

    void Start()
    {
        pOneController = GetComponent<PlayerOneController>();

        MusicSource = GetComponent<AudioSource>();
        currentClip = Cmaj;
    }
    
    void Update()
    {
        FindKey();

        MusicSource.clip = currentClip;           //sets current clip to play

        //checks if the audio source isn't playing
        if (!MusicSource.isPlaying)
        {
            MusicSource.Play();     //plays the clip if it isn't 
        }
    }

    void FindKey()
    {
        if(pOneController.key == 1)
        {
            currentClip = Cmaj;
        }
        else if (pOneController.key == 2)
        {
            currentClip = Amin;
        }
    }
}
