using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSequence : MonoBehaviour
{
    public List<GameObject> sequence = new List<GameObject>();

    public int i;

    private bool started,
                 once;

    private AudioSource audioSource;

    private AudioClip currentClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        currentClip = null;

        started = false;
        once = true;

        i = 0;
    }
    
    void Update()
    {
        if (sequence.Count > 0 && started == false)
        {
            started = true;
            StartCoroutine(Play(1.2f));
        }
    }

    IEnumerator Play(float time)
    {
        while (i < sequence.Count)
        {
            currentClip = sequence[i].GetComponent<AudioSource>().clip;
            
            audioSource.clip = currentClip;
            
            audioSource.Play();

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
}
