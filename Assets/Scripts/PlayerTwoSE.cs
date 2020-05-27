using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoSE : MonoBehaviour
{
    public AudioClip collect,
                     jump,
                     bounce,
                     currentClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlaySoundEffect(int number)
    {
        if (number == 1)
        {
            currentClip = jump;
        }
        else if (number == 2)
        {
            currentClip = bounce;
        }
        else if (number == 3)
        {
            currentClip = collect;
        }

        audioSource.PlayOneShot(currentClip);
    }
}
