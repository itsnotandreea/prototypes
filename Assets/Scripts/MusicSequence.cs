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

    public FMOD.Studio.EventInstance musicEvent;

    private bool started,
                 onScreen,
                 cancelLayers;
    
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
            if (layerTwo && cancelLayers)
            {
                layerTwo = false;
            }
            else if (!layerTwo)
            {
                layerTwo = true;
            }
        }
        else if (collectable.transform.name == "Collectable3(Clone)")
        {
            if (layerThree && cancelLayers)
            {
                layerThree = false;
            }
            else if (!layerThree)
            {
                layerThree = true;
            }
        }
        else if (collectable.transform.name == "CollectableOrange(Clone)")
        {
            if (layerFour && cancelLayers)
            {
                layerFour = false;
            }
            else if (!layerFour)
            {
                layerFour = true;
            }
        }
        else if (collectable.transform.name == "Collectable5(Clone)")
        {
            if (layerFive && cancelLayers)
            {
                layerFive = false;
            }
            else if (!layerFive)
            {
                layerFive = true;
            }
        }
        else if (collectable.transform.name == "Collectable6(Clone)")
        {
            if (layerSix && cancelLayers)
            {
                layerSix = false;
            }
            else if (!layerSix)
            {
                layerSix = true;
            }
        }
        else if (collectable.transform.name == "CollectableBlue(Clone)")
        {
            if (layerSeven && cancelLayers)
            {
                layerSeven = false;
            }
            else if (!layerSeven)
            {
                layerSeven = true;
            }
        }
        else if (collectable.transform.name == "CollectableYellow(Clone)")
        {
            if (layerEight && cancelLayers)
            {
                layerEight = false;
            }
            else if (!layerEight)
            {
                layerEight = true;
            }
        }
        else if (collectable.transform.name == "Collectable9(Clone)")
        {
            if (layerNine && cancelLayers)
            {
                layerNine = false;
            }
            else if (!layerNine)
            {
                layerNine = true;
            }
        }
        else if (collectable.transform.name == "CollectableDarkBlue(Clone)")
        {
            if (layerTen && cancelLayers)
            {
                layerTen = false;
            }
            else if (!layerTen)
            {
                layerTen = true;
            }
        }
        else if (collectable.transform.name == "CollectableLime(Clone)")
        {
            if (layerEleven && cancelLayers)
            {
                layerEleven = false;
            }
            else if (!layerEleven)
            {
                layerEleven = true;
            }
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            if (layerTwelve && cancelLayers)
            {
                layerTwelve = false;
            }
            else if (!layerTwelve)
            {
                layerTwelve = true;
            }
        }
        else if (collectable.transform.name == "Collectable13(Clone)")
        {
            if (layerThirteen && cancelLayers)
            {
                layerThirteen = false;
            }
            else if (!layerThirteen)
            {
                layerThirteen = true;
            }
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            if (layerFourteen && cancelLayers)
            {
                layerFourteen = false;
            }
            else if (!layerFourteen)
            {
                layerFourteen = true;
            }
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            if (layerFifteen && cancelLayers)
            {
                layerFifteen = false;
            }
            else if (!layerFifteen)
            {
                layerFifteen = true;
            }
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            if (layerSixteen && cancelLayers)
            {
                layerSixteen = false;
            }
            else if (!layerSixteen)
            {
                layerSixteen = true;
            }
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            if (layerSeventeen && cancelLayers)
            {
                layerSeventeen = false;
            }
            else if (!layerSeventeen)
            {
                layerSeventeen = true;
            }
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
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer4", 0f);
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
        if (knot.transform.name == "knotA" || knot.transform.name == "knotA(Clone)")
        {
            currentNote = A;
        }
        else if (knot.transform.name == "knotB" || knot.transform.name == "knotB(Clone)")
        {
            currentNote = B;
        }
        else if (knot.transform.name == "knotC" || knot.transform.name == "knotC(Clone)")
        {
            currentNote = C;
        }
        else if (knot.transform.name == "knotD" || knot.transform.name == "knotD(Clone)")
        {
            currentNote = D;
        }
        else if (knot.transform.name == "knotE" || knot.transform.name == "knotE(Clone)")
        {
            currentNote = E;
        }
        else if (knot.transform.name == "knotF" || knot.transform.name == "knotF(Clone)")
        {
            currentNote = F;
        }
        else if (knot.transform.name == "knotG" || knot.transform.name == "knotG(Clone)")
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
