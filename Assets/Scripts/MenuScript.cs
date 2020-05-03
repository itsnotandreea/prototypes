using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public bool playButton,
                composeButton,
                scoreButton,
                galleryButton;

    public GameObject playButtonGO,
                      composeButtonGO,
                      scoreButtonGO,
                      galleryButtonGO;

    private GameObject playerOne;

    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");

        playButton = false;
        composeButton = false;
        scoreButton = false;
        galleryButton = false;
    }
    
    void Update()
    {
        if (playerOne.transform.position == playButtonGO.transform.position)
        {
            playButton = true;
            composeButton = false;
            scoreButton = false;
            galleryButton = false;
        }
        else if (playerOne.transform.position == composeButtonGO.transform.position)
        {
            playButton = false;
            composeButton = true;
            scoreButton = false;
            galleryButton = false;
        }
        else if (playerOne.transform.position == scoreButtonGO.transform.position)
        {
            playButton = false;
            composeButton = false;
            scoreButton = true;
            galleryButton = false;
        }
        else if (playerOne.transform.position == galleryButtonGO.transform.position)
        {
            playButton = false;
            composeButton = false;
            scoreButton = false;
            galleryButton = true;
        }
        else
        {
            playButton = false;
            composeButton = false;
            scoreButton = false;
            galleryButton = false;
        }
    }
}
