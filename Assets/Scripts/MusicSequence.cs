using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSequence : MonoBehaviour
{
    public List<GameObject> sequence = new List<GameObject>();

    public int i,
               j;

    public float timeInSeconds;
    
    public bool layerOne,
                layerTwo,
                layerThree,
                layerFour,
                layerFive,
                layerSix,
                layerSeven,
                layerEight;

    private bool started,
                 onScreen;

    [FMODUnity.EventRef]
    public string sound,
                  A,
                  C,
                  D,
                  E,
                  G;

    public string currentNote;

    FMOD.Studio.EventInstance musicEvent;
    
    private Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        sound = "event:/KnotSounds/SOUND1/empty";
        A = "event:/KnotSounds/SOUND1/A";
        C = "event:/KnotSounds/SOUND1/C";
        D = "event:/KnotSounds/SOUND1/D";
        E = "event:/KnotSounds/SOUND1/E";
        G = "event:/KnotSounds/SOUND1/G";

        currentNote = null;

        /*
        layerOne = true;
        layerTwo = false;
        layerThree = false;
        layerFour = false;
        layerFive = false;
        layerSix = false;
        layerSeven = false;
        layerEight = false;
        */

        musicEvent = FMODUnity.RuntimeManager.CreateInstance(sound); 

        musicEvent.start();

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
            StartCoroutine(Play(timeInSeconds));
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

        AssignLayer();
    }

    public void AssignLayer()
    {
        if (layerTwo)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerTwo", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerTwo", 0f);
        }

        if (layerThree)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerThree", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerThree", 0f);
        }

        if (layerFour)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerFour", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerFour", 0f);
        }

        if (layerFive)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerFive", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerFive", 0f);
        }

        if (layerSix)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerSix", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerSix", 0f);
        }

        if (layerSeven)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerSeven", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerSeven", 0f);
        }

        if (layerEight)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerEight", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("layerEight", 0f);
        }
    }

    IEnumerator Play(float time)
    {
        while (i < sequence.Count)
        {
            /*
            //Plays the note attached to the object
            currentClip = sequence[i].GetComponent<AudioSource>().clip;
            audioSource.clip = currentClip;
            audioSource.Play();
            */

            FindNote(sequence[i]);

            FMODUnity.RuntimeManager.CreateInstance(currentNote);
            FMODUnity.RuntimeManager.PlayOneShot(currentNote, transform.position);

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

    private void FindNote(GameObject knot)
    {
        if (knot.transform.name == "knotBlue" || knot.transform.name == "knotBlue(Clone)")
        {
            currentNote = A;
        }
        else if (knot.transform.name == "knotBlack" || knot.transform.name == "knotBlack(Clone)")
        {
            currentNote = A;        //!!! not the right one, not enough notes for all seven knots
        }
        else if (knot.transform.name == "knotGreen" || knot.transform.name == "knotGreen(Clone)")
        {
            currentNote = C;
        }
        else if (knot.transform.name == "knotOrange" || knot.transform.name == "knotOrange(Clone)")
        {
            currentNote = D;
        }
        else if (knot.transform.name == "knotPurple" || knot.transform.name == "knotPurple(Clone)")
        {
            currentNote = E;
        }
        else if (knot.transform.name == "knotRed" || knot.transform.name == "knotRed(Clone)")
        {
            currentNote = E;        //!!! not the right one, not enough notes for all seven knots
        }
        else if (knot.transform.name == "knotYellow" || knot.transform.name == "knotYellow(Clone)")
        {
            currentNote = G;
        }
    }

    private void CheckIfOnScreen(GameObject knot)
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
