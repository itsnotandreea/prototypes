using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSequence : MonoBehaviour
{
    public List<GameObject> sequence = new List<GameObject>();

    public int i,
               j,
               activeLayers,
               activeLayersLimit;

    public float timeInSeconds;

    public bool cancelLayers;

    public string currentNote;

    public FMOD.Studio.EventInstance musicEvent;

    public bool[] layersArray = new bool[16];

    private bool started,
                 onScreen;
    
    private string sound,
                  A,
                  B,
                  C,
                  D,
                  E,
                  F,
                  G;
    
    private Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        sound = "event:/SOUND4/Empty";
        A = "event:/SOUND4/A";
        B = "event:/SOUND4/B";
        C = "event:/SOUND4/C";
        D = "event:/SOUND4/D";
        E = "event:/SOUND4/E";
        F = "event:/SOUND4/F";
        G = "event:/SOUND4/G";

        currentNote = null;
        
        for (int i = 0; i < 16; i++)
        {
            layersArray[i] = false;
        }

        AssignLayer();

        musicEvent = FMODUnity.RuntimeManager.CreateInstance(sound); 

        musicEvent.start();

        started = false;

        onScreen = false;

        i = 0;
        j = 0;
        activeLayers = 0;
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
    }

    private void DeleteRandomLayer()
    {
        bool cancelledLayer = false;

        while (!cancelledLayer)
        {
            int DeleteRandomLayer = Random.Range(0, 16);
            
            if (layersArray[DeleteRandomLayer] == true)
            {
                layersArray[DeleteRandomLayer] = false;
                cancelledLayer = true;
            }
        }
    }

    public void GetCollectable(GameObject collectable)
    {
        if (collectable.transform.name == "Collectable2(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[0])
                {
                    layersArray[0] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[0])
                {
                    if(activeLayers < activeLayersLimit)
                    {
                        layersArray[0] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[0] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable3(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[1])
                {
                    layersArray[1] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[1])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[1] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[1] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable4(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[2])
                {
                    layersArray[2] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[2])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[2] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[2] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable5(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[3])
                {
                    layersArray[3] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[3])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[3] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[3] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable6(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[4])
                {
                    layersArray[4] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[4])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[4] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[4] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable7(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[5])
                {
                    layersArray[5] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[5])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[5] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[5] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable8(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[6])
                {
                    layersArray[6] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[6])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[6] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[6] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable9(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[7])
                {
                    layersArray[7] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[7])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[7] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[7] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable10(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[8])
                {
                    layersArray[8] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[8])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[8] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[8] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable11(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[9])
                {
                    layersArray[9] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[9])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[9] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[9] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable12(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[10])
                {
                    layersArray[10] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[10])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[10] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[10] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable13(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[11])
                {
                    layersArray[11] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[11])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[11] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[11] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable14(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[12])
                {
                    layersArray[12] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[12])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[12] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[12] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable15(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[13])
                {
                    layersArray[13] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[13])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[13] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[13] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable16(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[14])
                {
                    layersArray[14] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[14])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[14] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[14] = true;
                    }
                }
            }
        }
        else if (collectable.transform.name == "Collectable17(Clone)")
        {
            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[15])
                {
                    layersArray[15] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[15])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        layersArray[15] = true;
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                        layersArray[15] = true;
                    }
                }
            }
        }

        AssignLayer();
    }

    public void AssignLayer()
    {
        if (layersArray[0])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer2", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer2", 0f);
        }

        if (layersArray[1])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer3", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer3", 0f);
        }

        if (layersArray[2])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer4", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer4", 0f);
        }

        if (layersArray[3])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 0f);
        }

        if (layersArray[4])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer6", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer6", 0f);
        }

        if (layersArray[5])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer7", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer7", 0f);
        }

        if (layersArray[6])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer8", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer8", 0f);
        }

        if (layersArray[7])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer9", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer9", 0f);
        }

        if (layersArray[8])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer10", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer10", 0f);
        }

        if (layersArray[9])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer11", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer11", 0f);
        }

        if (layersArray[10])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer12", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer12", 0f);
        }

        if (layersArray[11])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer13", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer13", 0f);
        }

        if (layersArray[12])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer14", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer14", 0f);
        }

        if (layersArray[13])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer15", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer15", 0f);
        }

        if (layersArray[14])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer16", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer16", 0f);
        }

        if (layersArray[15])
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
