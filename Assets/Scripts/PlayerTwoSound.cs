using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoSound : MonoBehaviour
{
    public AudioClip A,
                     Asharp,
                     B,
                     C,
                     Csharp,
                     D,
                     Dsharp,
                     E,
                     F,
                     Fsharp,
                     G,
                     Gsharp,
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
                sourceA.PlayOneShot(G);
            }
            else if (button == 2)
            {
                sourceB.PlayOneShot(E);
            }
            else if (button == 3)
            {
                sourceX.PlayOneShot(B);
            }
            else if (button == 4)
            {
                sourceY.PlayOneShot(C);
            }
        }
        else if (key == 2)
        {
            if (button == 1)
            {
                sourceB.PlayOneShot(E);
            }
            else if (button == 2)
            {
                sourceY.PlayOneShot(C);
            }
            else if (button == 3)
            {
                sourceA.PlayOneShot(G);
            }
            else if (button == 4)
            {
                sourceX.PlayOneShot(A);
            }
        }
    }
}
