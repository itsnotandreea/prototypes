using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSequence : MonoBehaviour
{
    public List<GameObject> sequence = new List<GameObject>();

    public int i, j;

    private bool started,
                 onScreen;

    private AudioSource audioSource;

    private AudioClip currentClip;

    private Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        audioSource = GetComponent<AudioSource>();

        currentClip = null;

        started = false;

        onScreen = false;

        i = 0;

        j = 0;
    }
    
    void Update()
    {
        if (sequence.Count > 0 && started == false)
        {
            started = true;
            StartCoroutine(Play(1.2f));
        }

        while (j < sequence.Count)
        {
            onScreen = false;
            CheckIfOnScreen(sequence[j]);

            j++;
        }

        if (j >= sequence.Count)
        {
            j = 0;
        }
    }

    IEnumerator Play(float time)
    {
        while (i < sequence.Count)
        {
            //Plays the note attached to the object
            currentClip = sequence[i].GetComponent<AudioSource>().clip;
            audioSource.clip = currentClip;
            audioSource.Play();

            //Changes colour of the knot so you can eye-track the music
            SpriteRenderer sRenderer = sequence[i].GetComponent<SpriteRenderer>();
            Color originalColor = sRenderer.color;
            sRenderer.color = new Color(1.0f, 1.0f, 1.0f);

            yield return new WaitForSeconds(time);

            sRenderer.color = originalColor;
            
            i++;
        }

        if (i >= sequence.Count)
        {
            i = 0;
            started = false;
        }
    }

    void CheckIfOnScreen(GameObject knot)
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(knot.transform.position);

        if (screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1)
        {
            onScreen = true;
        }

        if (!onScreen)
        {
            sequence.Remove(knot);

            if(i > 0)
            {
                i--;
            }

            onScreen = false;
        }
    }
}
