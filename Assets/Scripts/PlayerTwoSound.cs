using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoSound : MonoBehaviour
{
    public AudioClip CmajA,
                     CmajB,
                     CmajX,
                     CmajY,
                     AminA,
                     AminB,
                     AminX,
                     AminY,
                     empty;

    public AudioSource sourceA,         //the audio source that plays the clips
                       sourceB,
                       sourceX,
                       sourceY;

    private AudioClip currentClip;          //the current clip to be played

    private GameObject playerTwo,
                       floor;

    private PlayerTwoController pTwoController;

    private KeyManager keyManager;

    void Start()
    {
        playerTwo = GameObject.FindGameObjectWithTag("PlayerOne");
        pTwoController = playerTwo.GetComponent<PlayerTwoController>();

        floor = GameObject.FindGameObjectWithTag("Floor");
        keyManager = floor.GetComponent<KeyManager>();

        //accesses the audio source and sets the initial clip
        currentClip = empty;
    }
    
    void Update()
    {
        /*
        MusicSource.clip = currentClip;           //sets current clip to play

        //checks if the audio source isn't playing
        if (!MusicSource.isPlaying)
        {
            MusicSource.Play();     //plays the clip if it isn't 
        }*/
    }

    public void AssignClip(int key, int button)
    {
        if(key == 1)
        {
            if(button == 1)
            {
                sourceA.PlayOneShot(CmajA);
            }
            else if (button == 2)
            {
                sourceB.PlayOneShot(CmajB);
            }
            else if (button == 3)
            {
                sourceX.PlayOneShot(CmajX);
            }
            else if (button == 4)
            {
                sourceY.PlayOneShot(CmajY);
            }
        }
        else if (key == 2)
        {
            if (button == 1)
            {
                sourceA.PlayOneShot(AminA);
            }
            else if (button == 2)
            {
                sourceB.PlayOneShot(AminB);
            }
            else if (button == 3)
            {
                sourceX.PlayOneShot(AminX);
            }
            else if (button == 4)
            {
                sourceY.PlayOneShot(AminY);
            }
        }
    }
}
