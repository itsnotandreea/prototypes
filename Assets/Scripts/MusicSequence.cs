using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSequence : MonoBehaviour
{
    public GameObject shintoGO,
                      shintoCollectable,
                      taoismGO,
                      taoismCollectable,
                      christianityGO,
                      christianityCollectable,
                      robotsGO,
                      robotsCollectable,
                      shintoStart,
                      shintoEnd,
                      taoismStart,
                      taoismEnd,
                      christianityStart,
                      christianityEnd,
                      robotsStart,
                      robotsEnd;

    public List<GameObject> sequence = new List<GameObject>();

    public int i,
               j,
               activeLayers,
               activeLayersLimit;

    public float timeInSeconds,
                 endSacredTime;

    public bool cancelLayers,
                sacred,
                sacredCollectable;

    public string currentNote;

    public FMOD.Studio.EventInstance musicEvent;

    public bool[] layersArray = new bool[19];

    public int[] code = new int[5];

    public RecorderScript recScript;

    public PlayerTwoSoundEffects playerTwoSE;

    private int currentDigit;

    private bool started,
                 onScreen;

    private string sound,
                   A,
                   B,
                   C,
                   Csharp,
                   CC,
                   CCsharp,
                   D,
                   E,
                   F,
                   G,
                   Gsharp;
    
    private Camera cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        sound = "event:/SOUND6/Empty";
        A = "event:/SOUND6/A";
        B = "event:/SOUND6/B";
        C = "event:/SOUND6/C";
        Csharp = "event:/SOUND6/Csharp";
        CC = "event:/SOUND6/CC";
        CCsharp = "event:/SOUND6/CCsharp";
        D = "event:/SOUND6/D";
        E = "event:/SOUND6/E";
        F = "event:/SOUND6/F";
        G = "event:/SOUND6/G";
        Gsharp = "event:/SOUND6/Gsharp";
        
        currentNote = null;
        
        for (int i = 0; i < 19; i++)
        {
            layersArray[i] = false;
        }

        for (int i = 0; i < 5; i++)
        {
            code[i] = 0;
        }

        currentDigit = 0;

        AssignLayer();

        musicEvent = FMODUnity.RuntimeManager.CreateInstance(sound); 

        musicEvent.start();

        started = false;

        onScreen = false;

        i = 0;
        j = 0;
        activeLayers = 0;

        sacred = false;
        sacredCollectable = false;
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

        if (currentDigit > 4)
        {
            currentDigit = 0;
        }
    }
    
    private void OnDisable()
    {
        musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        if (sequence.Count > 0)
        {
            sequence.Clear();
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
            code[currentDigit] = 1;
            currentDigit++;

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
            code[currentDigit] = 1;
            currentDigit++;

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
            code[currentDigit] = 1;
            currentDigit++;

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
            code[currentDigit] = 1;
            currentDigit++;

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
            code[currentDigit] = 2;
            currentDigit++;

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
            code[currentDigit] = 2;
            currentDigit++;

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
            code[currentDigit] = 2;
            currentDigit++;

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
            code[currentDigit] = 2;
            currentDigit++;

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
            code[currentDigit] = 3;
            currentDigit++;

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
            code[currentDigit] = 3;
            currentDigit++;

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
            code[currentDigit] = 3;
            currentDigit++;

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
            code[currentDigit] = 3;
            currentDigit++;

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
            code[currentDigit] = 4;
            currentDigit++;

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
            code[currentDigit] = 4;
            currentDigit++;

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
            code[currentDigit] = 4;
            currentDigit++;

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
            code[currentDigit] = 4;
            currentDigit++;

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
        else if (collectable.transform.name == "Collectable18(Clone)")
        {
            //JAPANESE COLLECTABLE

            playerTwoSE.PlayStartSoundEffect(collectable);
            recScript.AddKnot(shintoStart);

            code[currentDigit] = 0;
            currentDigit++;

            sacred = true;

            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[16])
                {
                    layersArray[16] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[16])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }

                    layersArray[16] = true;

                    shintoGO.SetActive(true);
                    shintoGO.transform.position = new Vector3(transform.position.x + transform.TransformDirection(Vector2.up * 11.0f).x,
                                                              transform.position.y + transform.TransformDirection(Vector2.up * 11.0f).y,
                                                              shintoGO.transform.position.z);

                    shintoGO.GetComponent<SpawnKnots>().addKnots = true;
                    StartCoroutine(shintoGO.GetComponent<SpawnKnots>().KnotsWave());

                    StartCoroutine(EndSacred(shintoGO));
                }
            }
        }
        else if (collectable.transform.name == "Collectable19(Clone)")
        {
            //TAOISM COLLECTABLE

            playerTwoSE.PlayStartSoundEffect(collectable);
            recScript.AddKnot(taoismStart);

            code[currentDigit] = 0;
            currentDigit++;

            sacred = true;

            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[17])
                {
                    layersArray[17] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[17])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }

                    layersArray[17] = true;

                    taoismGO.SetActive(true);
                    taoismGO.transform.position = new Vector3(transform.position.x + transform.TransformDirection(Vector2.up * 11.0f).x,
                                                              transform.position.y + transform.TransformDirection(Vector2.up * 11.0f).y,
                                                              taoismGO.transform.position.z);

                    taoismGO.GetComponent<SpawnKnots>().addKnots = true;
                    StartCoroutine(taoismGO.GetComponent<SpawnKnots>().KnotsWave());

                    StartCoroutine(EndSacred(taoismGO));
                }
            }
        }
        else if (collectable.transform.name == "Collectable20(Clone)")
        {
            //CHRISTIANITY COLLECTABLE

            playerTwoSE.PlayStartSoundEffect(collectable);
            recScript.AddKnot(christianityStart);

            code[currentDigit] = 0;
            currentDigit++;

            sacred = true;

            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[18])
                {
                    layersArray[18] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[18])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }

                    layersArray[18] = true;

                    christianityGO.SetActive(true);
                    christianityGO.transform.position = new Vector3(transform.position.x + transform.TransformDirection(Vector2.up * 11.0f).x,
                                                                    transform.position.y + transform.TransformDirection(Vector2.up * 11.0f).y,
                                                                    christianityGO.transform.position.z);

                    christianityGO.GetComponent<SpawnKnots>().addKnots = true;
                    StartCoroutine(christianityGO.GetComponent<SpawnKnots>().KnotsWave());

                    StartCoroutine(EndSacred(christianityGO));
                }
            }
        }
        else if (collectable.transform.name == "Collectable21(Clone)")
        {
            //CHIPTUNE COLLECTABLE

            playerTwoSE.PlayStartSoundEffect(collectable);
            recScript.AddKnot(robotsStart);

            code[currentDigit] = 0;
            currentDigit++;

            sacred = true;

            if (cancelLayers)
            {
                //cancel the layer
                if (layersArray[19])
                {
                    layersArray[19] = false;
                    activeLayers--;
                }
            }
            else
            {
                //add the layer
                if (!layersArray[19])
                {
                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }

                    layersArray[19] = true;

                    robotsGO.SetActive(true);
                    robotsGO.transform.position = new Vector3(transform.position.x + transform.TransformDirection(Vector2.up * 11.0f).x,
                                                              transform.position.y + transform.TransformDirection(Vector2.up * 11.0f).y,
                                                              robotsGO.transform.position.z);

                    robotsGO.GetComponent<SpawnKnots>().addKnots = true;
                    StartCoroutine(robotsGO.GetComponent<SpawnKnots>().KnotsWave());

                    StartCoroutine(EndSacred(robotsGO));
                }
            }
        }
        
        CheckCode();
        AssignLayer();
    }

    private void CheckCode()
    {
        int codeF;

        codeF = code[0] * 10000 + code[1] * 1000 + code[2] * 100 + code[3] * 10 + code[4] * 1;

        string codeS = codeF.ToString();

        if (codeS == "44411" || codeS == "14441" || codeS == "11444" || codeS == "41144" || codeS == "44114")
        {
            if (!sacredCollectable)
            {
                Vector2 pos = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(20.0f, 30.0f));
                Vector3 newPos = new Vector3(transform.position.x + transform.TransformDirection(pos).x,
                                             transform.position.y + transform.TransformDirection(pos).y,
                                             0.0f);
                Instantiate(shintoCollectable, newPos, transform.rotation);
                sacredCollectable = true;
            }
        }
        
        if (codeS == "33311" || codeS == "13331" || codeS == "11333" || codeS == "31133" || codeS == "33113")
        {
            if (!sacredCollectable)
            {
                Vector2 pos = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(20.0f, 30.0f));
                Vector3 newPos = new Vector3(transform.position.x + transform.TransformDirection(pos).x,
                                             transform.position.y + transform.TransformDirection(pos).y,
                                             0.0f);
                Instantiate(taoismCollectable, newPos, transform.rotation);
                sacredCollectable = true;
            }
        }

        if (codeS == "22244" || codeS == "42224" || codeS == "44222" || codeS == "24422" || codeS == "22442")
        {
            if (!sacredCollectable)
            {
                Vector2 pos = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(20.0f, 30.0f));
                Vector3 newPos = new Vector3(transform.position.x + transform.TransformDirection(pos).x,
                                             transform.position.y + transform.TransformDirection(pos).y,
                                             0.0f);
                Instantiate(christianityCollectable, newPos, transform.rotation);
                sacredCollectable = true;
            }
        }

        if (codeS == "33322" || codeS == "23332" || codeS == "22333" || codeS == "32233" || codeS == "33223")
        {
            if (!sacredCollectable)
            {
                Vector2 pos = new Vector2(Random.Range(-15.0f, 15.0f), Random.Range(20.0f, 30.0f));
                Vector3 newPos = new Vector3(transform.position.x + transform.TransformDirection(pos).x,
                                             transform.position.y + transform.TransformDirection(pos).y,
                                             0.0f);
                Instantiate(robotsCollectable, newPos, transform.rotation);
                sacredCollectable = true;
            }
        }
    }

    public void AssignLayer()
    {
        FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Layer1", out float value);

        if (sacred && value != 0.5f)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer1", 0.0f);
        }
        else if (!sacred && value != 1f)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer1", 1f);
        }

        if (layersArray[0])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer2", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer2", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer2", 0f);
        }

        if (layersArray[1])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer3", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer3", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer3", 0f);
        }

        if (layersArray[2])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer4", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer4", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer4", 0f);
        }

        if (layersArray[3])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer5", 0f);
        }

        if (layersArray[4])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer6", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer6", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer6", 0f);
        }

        if (layersArray[5])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer7", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer7", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer7", 0f);
        }

        if (layersArray[6])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer8", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer8", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer8", 0f);
        }

        if (layersArray[7])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer9", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer9", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer9", 0f);
        }

        if (layersArray[8])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer10", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer10", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer10", 0f);
        }

        if (layersArray[9])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer11", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer11", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer11", 0f);
        }

        if (layersArray[10])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer12", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer12", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer12", 0f);
        }

        if (layersArray[11])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer13", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer13", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer13", 0f);
        }

        if (layersArray[12])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer14", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer14", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer14", 0f);
        }

        if (layersArray[13])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer15", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer15", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer15", 0f);
        }

        if (layersArray[14])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer16", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer16", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer16", 0f);
        }

        if (layersArray[15])
        {
            if (!sacred)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer17", 1f);
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer17", 0.0f);
            }
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer17", 0f);
        }

        if (layersArray[16])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer18", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer18", 0f);
        }

        if (layersArray[17])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer19", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer19", 0f);
        }

        if (layersArray[18])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer20", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer20", 0f);
        }

        if (layersArray[19])
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer21", 1f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer21", 0f);
        }
    }

    private IEnumerator Play(float time)
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
                
            if (originalColor == new Color(1.0f, 1.0f, 1.0f, 1.0f))
            {
                sRenderer.color = originalColor;
            }
            else
            {
                if (sacred)
                {
                    sRenderer.color = originalColor;
                }
                else
                {
                    sRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                }
            }

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
        else if (knot.transform.name == "knotShintoC" || knot.transform.name == "knotShintoC(Clone)")
        {
            currentNote = C;
        }
        else if (knot.transform.name == "knotShintoCsharp" || knot.transform.name == "knotShintoCsharp(Clone)")
        {
            currentNote = Csharp;
        }
        else if (knot.transform.name == "knotShintoCC" || knot.transform.name == "knotShintoCC(Clone)")
        {
            currentNote = CC;
        }
        else if (knot.transform.name == "knotShintoCCsharp" || knot.transform.name == "knotShintoCCsharp(Clone)")
        {
            currentNote = CCsharp;
        }
        else if (knot.transform.name == "knotShintoF" || knot.transform.name == "knotShintoF(Clone)")
        {
            currentNote = F;
        }
        else if (knot.transform.name == "knotShintoG" || knot.transform.name == "knotShintoG(Clone)")
        {
            currentNote = G;
        }
        else if (knot.transform.name == "knotShintoGsharp" || knot.transform.name == "knotShintoGsharp(Clone)")
        {
            currentNote = Gsharp;
        }
        else if (knot.transform.name == "knotTaoismA" || knot.transform.name == "knotTaoismA(Clone)")
        {
            currentNote = A;
        }
        else if (knot.transform.name == "knotTaoismC" || knot.transform.name == "knotTaoismC(Clone)")
        {
            currentNote = C;
        }
        else if (knot.transform.name == "knotTaoismD" || knot.transform.name == "knotTaoismD(Clone)")
        {
            currentNote = D;
        }
        else if (knot.transform.name == "knotTaoismE" || knot.transform.name == "knotTaoismE(Clone)")
        {
            currentNote = E;
        }
        else if (knot.transform.name == "knotTaoismCC" || knot.transform.name == "knotTaoismCC(Clone)")
        {
            currentNote = CC;
        }
        else if (knot.transform.name == "knotTaoismG" || knot.transform.name == "knotTaoismG(Clone)")
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

        //removes sacred knots from sequence if the time expired
        if (knot.transform.tag == "ToDestroy")
        {
            if (!sacred)
            {
                onScreen = false;
            }
        }

        if (!onScreen)
        {
            sequence.Remove(knot);

            if (i > 0)
            {
                i--;
            }

            onScreen = false;
        }
    }

    private IEnumerator EndSacred(GameObject sacredObject)
    {
        yield return new WaitForSeconds(endSacredTime);
        
        sacredObject.GetComponent<SpawnKnots>().addKnots = false;

        if (sacredObject.transform.name == "shintoKnotsZone")
        {
            layersArray[16] = false;
            playerTwoSE.PlayEndSoundEffect(sacredObject);
            recScript.AddKnot(shintoEnd);
            yield return new WaitForSeconds(0.38f);
        }
        else if (sacredObject.transform.name == "taoismKnotsZone")
        {
            layersArray[17] = false;
            playerTwoSE.PlayEndSoundEffect(sacredObject);
            recScript.AddKnot(taoismEnd);
            yield return new WaitForSeconds(0.38f);
        }
        else if (sacredObject.transform.name == "christianityKnotsZone")
        {
            layersArray[18] = false;
            playerTwoSE.PlayEndSoundEffect(sacredObject);
            recScript.AddKnot(christianityEnd);
            yield return new WaitForSeconds(1.5f);
        }
        else if (sacredObject.transform.name == "robotsKnotsZone")
        {
            layersArray[19] = false;
            playerTwoSE.PlayEndSoundEffect(sacredObject);
            recScript.AddKnot(robotsEnd);
            yield return new WaitForSeconds(1.15f);
        }

        sacred = false;

        AssignLayer();

        GameObject sacredObjectsParent = sacredObject.GetComponent<SpawnKnots>().parent;

        foreach (Transform child in sacredObjectsParent.transform)
        {
            child.gameObject.layer = 0;
            Destroy(child.gameObject.GetComponent<Collider2D>());
            Destroy(child.gameObject.GetComponent<ParticleSystem>());
            child.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }

        sacredObject.SetActive(false);

        sacredCollectable = false;
    }
}
