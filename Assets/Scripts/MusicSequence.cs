﻿using System.Collections;
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
                layerEight,
                layerNine,
                layerTen,
                layerEleven,
                layerTwelve,    
                layerThirteen,
                layerFourteen,
                layerFifteen,
                layerSixteen,
                layerSeventeen;

    private bool started,
                 onScreen;

    [FMODUnity.EventRef]
    public string sound,
                  A,
                  B,
                  C,
                  D,
                  E,
                  F,
                  G;

    public string currentNote;

    FMOD.Studio.EventInstance musicEvent;
    
    private Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        sound = "event:/DUODEUSSOUND3/Empty";
        A = "event:/DUODEUSSOUND3/A";
        B = "event:/DUODEUSSOUND3/B";
        C = "event:/DUODEUSSOUND3/C";
        D = "event:/DUODEUSSOUND3/D";
        E = "event:/DUODEUSSOUND3/E";
        F = "event:/DUODEUSSOUND3/F";
        G = "event:/DUODEUSSOUND3/G";

        currentNote = null;
        
        layerOne = true;
        layerTwo = false;
        layerThree = false;
        layerFour = false;
        layerFive = false;
        layerSix = false;
        layerSeven = false;
        layerEight = false;
        layerNine = false;
        layerTen = false;
        layerEleven = false;
        layerTwelve = false;
        layerThirteen = false;
        layerFourteen = false;
        layerFifteen = false;
        layerSixteen = false;
        layerSeventeen = false;

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

    public void GetCollectable(GameObject collectable)
    {
        if (collectable.transform.name == "CollectableCorai(Clone)")
        {
            layerTwo = !layerTwo;
        }
        else if (collectable.transform.name == "Collectable3(Clone)")
        {
            layerThree = !layerThree;
        }
        else if (collectable.transform.name == "CollectableOrange(Clone)")
        {
            layerFour = !layerFour;
        }
        else if (collectable.transform.name == "Collectable5(Clone)")
        {
            layerFive = !layerFive;
        }
        else if (collectable.transform.name == "Collectable6(Clone)")
        {
            layerSix = !layerSix;
        }
        else if (collectable.transform.name == "CollectableBlue(Clone)")
        {
            layerSeven = !layerSeven;
        }
        else if (collectable.transform.name == "CollectableYellow(Clone)")
        {
            layerEight = !layerEight;
        }
        else if (collectable.transform.name == "Collectable9(Clone)")
        {
            layerNine = !layerNine;
        }
        else if (collectable.transform.name == "CollectableDarkBlue(Clone)")
        {
            layerTen = !layerTen;
        }
        else if (collectable.transform.name == "CollectableLime(Clone)")
        {
            layerEleven = !layerEleven;
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            layerTwelve = !layerTwelve;
        }
        else if (collectable.transform.name == "Collectable13(Clone)")
        {
            layerThirteen = !layerThirteen;
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            layerFourteen = !layerFourteen;
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            layerFifteen = !layerFifteen;
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            layerSixteen = !layerSixteen;
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            layerSeventeen = !layerSeventeen;
        }
    }

    public void AssignLayer()
    {
        if (layerTwo)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer2", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer2", 0f);
        }

        if (layerThree)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer3", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer3", 0f);
        }

        if (layerFour)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer4", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 0f);
        }

        if (layerFive)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 0f);
        }

        if (layerSix)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer6", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer6", 0f);
        }

        if (layerSeven)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer7", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer7", 0f);
        }

        if (layerEight)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer8", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer8", 0f);
        }

        if (layerNine)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer9", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer9", 0f);
        }

        if (layerTen)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer10", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer10", 0f);
        }

        if (layerEleven)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer11", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer11", 0f);
        }

        if (layerTwelve)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer12", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer12", 0f);
        }

        if (layerThirteen)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer13", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer13", 0f);
        }

        if (layerFourteen)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer14", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer14", 0f);
        }

        if (layerFifteen)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer15", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer15", 0f);
        }

        if (layerSixteen)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer16", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer16", 0f);
        }

        if (layerSeventeen)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer17", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer17", 0f);
        }
    }

    IEnumerator Play(float time)
    {
        while (i < sequence.Count)
        {
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
            currentNote = B;
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
            currentNote = F;
        }
        else if (knot.transform.name == "knotYellow" || knot.transform.name == "knotYellow(Clone)")
        {
            currentNote = G;
        }
    }

    private void CheckIfOnScreen(GameObject knot)
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(knot.transform.position);

        if (screenPoint.x > -0.2f && screenPoint.x < 1.2f && screenPoint.y > -0.2f && screenPoint.y < 1.2f)
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
