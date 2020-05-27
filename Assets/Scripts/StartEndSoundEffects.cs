﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEndSoundEffects : MonoBehaviour
{
    public AudioClip currentClip,
                     shintoStart,
                     shintoEnd,
                     taoismStart,
                     taoismEnd,
                     christianityStart,
                     christianityEnd,
                     robotsStart,
                     robotsEnd;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStartSoundEffect(GameObject collectable)
    {
        if (collectable.transform.name == "Collectable18(Clone)")
        {
            currentClip = shintoStart;
        }
        else if (collectable.transform.name == "Collectable19(Clone)")
        {
            currentClip = taoismStart;
        }
        else if (collectable.transform.name == "Collectable20(Clone)")
        {
            currentClip = christianityStart;
        }
        else if (collectable.transform.name == "Collectable21(Clone)")
        {
            currentClip = robotsStart;
        }

        audioSource.PlayOneShot(currentClip);
    }

    public void PlayEndSoundEffect(GameObject zone)
    {
        if (zone.transform.name == "shintoKnotsZone")
        {
            currentClip = shintoEnd;
        }
        else if (zone.transform.name == "taoismKnotsZone")
        {
            currentClip = taoismEnd;
        }
        else if (zone.transform.name == "christianityKnotsZone")
        {
            currentClip = christianityEnd;
        }
        else if (zone.transform.name == "robotsKnotsZone")
        {
            currentClip = robotsEnd;
        }

        audioSource.PlayOneShot(currentClip);
    }
}