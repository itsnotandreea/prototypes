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
                 regularTime,
                 shintoTime,
                 taoismTime,
                 christianityTime,
                 robotsTime,
                 endSacredTime;

    public bool cancelLayers,
                sacred,
                sacredCollectable;

    public string currentNote;

    public FMOD.Studio.EventInstance musicEvent;

    public bool[] layersArray = new bool[19];

    public int[] code = new int[5];

    public RecorderScript recScript;
    
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
                   Gsharp,
                   sStart,
                   sEnd,
                   tStart,
                   tEnd,
                   cStart,
                   cEnd,
                   rStart,
                   rEnd;
    
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
        sStart = "event:/SOUND6/sStart";
        sEnd = "event:/SOUND6/sEnd";
        tStart = "event:/SOUND6/tStart";
        tEnd = "event:/SOUND6/tEnd";
        cStart = "event:/SOUND6/cStart";
        cEnd = "event:/SOUND6/cEnd";
        rStart = "event:/SOUND6/rStart";
        rEnd = "event:/SOUND6/rEnd";
        
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
        timeInSeconds = regularTime;
    }
    
    void Update()
    {
        if (sequence.Count > 0 && started == false)
        {
            started = true;
            StartCoroutine(Play());
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
                    timeInSeconds = shintoTime;
                    
                    if (i + 1 <= sequence.Count - 1)
                    {
                        sequence.Insert(i + 1, shintoStart);
                    }
                    else
                    {
                        sequence.Insert(0, shintoStart);
                    }
                    
                    code[currentDigit] = 0;
                    currentDigit++;
            

                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }
                    
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
                    timeInSeconds = taoismTime;
                    
                    if (i + 1 <= sequence.Count - 1)
                    {
                        sequence.Insert(i + 1, taoismStart);
                    }
                    else
                    {
                        sequence.Insert(0, taoismStart);
                    }
                    
                    code[currentDigit] = 0;
                    currentDigit++;


                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }
                    
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
                    timeInSeconds = christianityTime;
                    
                    if (i + 1 <= sequence.Count - 1)
                    {
                        sequence.Insert(i + 1, christianityStart);
                    }
                    else
                    {
                        sequence.Insert(0, christianityStart);
                    }
                    
                    code[currentDigit] = 0;
                    currentDigit++;

            
                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }

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
                    timeInSeconds = robotsTime;
            
                    if (i + 1 <= sequence.Count - 1)
                    {
                        sequence.Insert(i + 1, robotsStart);
                    }
                    else
                    {
                        sequence.Insert(0, robotsStart);
                    }
                    
                    code[currentDigit] = 0;
                    currentDigit++;

            
                    if (activeLayers <= activeLayersLimit)
                    {
                        activeLayers++;
                    }
                    else
                    {
                        DeleteRandomLayer();
                    }
                    
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

        if (sacred && value != 0.0f)
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

    private IEnumerator Play()
    {
        while (i < sequence.Count)
        {
            FindNote(sequence[i]);

            FMODUnity.RuntimeManager.CreateInstance(currentNote);
            FMODUnity.RuntimeManager.PlayOneShot(currentNote, transform.position);
            
            if (sequence[i].transform.childCount > 0)
            {
                if (sequence[i].transform.GetChild(0).GetComponent<Animator>())
                {
                    Animator animator = sequence[i].transform.GetChild(0).GetComponent<Animator>();

                    animator.SetTrigger("playIdle");
                }
            }


            yield return new WaitForSecondsRealtime(timeInSeconds);

            if (currentNote == sStart)
            {
                yield return new WaitForSecondsRealtime(0.38f);
                sequence.RemoveAt(i);

                layersArray[16] = true;
                recScript.AddKnot(shintoStart);
                sacred = true;
                AssignLayer();
            }
            else if (currentNote == sEnd)
            {
                yield return new WaitForSecondsRealtime(0.38f);
                sequence.RemoveAt(i);

                layersArray[16] = false;
                recScript.AddKnot(shintoEnd);
                sacred = false;
                AssignLayer();
            }
            else if (currentNote == tStart)
            {
                yield return new WaitForSecondsRealtime(0.38f);
                sequence.RemoveAt(i);

                layersArray[17] = true;
                recScript.AddKnot(taoismStart);
                sacred = true;
                AssignLayer();
            }
            else if (currentNote == tEnd)
            {
                yield return new WaitForSecondsRealtime(0.38f);
                sequence.RemoveAt(i);
                
                layersArray[17] = false;
                recScript.AddKnot(taoismEnd);
                sacred = false;
                AssignLayer();
            }
            else if (currentNote == cStart)
            {
                sequence.RemoveAt(i);

                layersArray[18] = true;
                recScript.AddKnot(christianityStart);
                sacred = true;
                AssignLayer();
            }
            else if (currentNote == cEnd)
            {
                sequence.RemoveAt(i);

                layersArray[18] = false;
                recScript.AddKnot(christianityEnd);
                sacred = false;
                AssignLayer();
            }
            else if (currentNote == rStart)
            {
                sequence.RemoveAt(i);

                layersArray[19] = true;
                recScript.AddKnot(robotsStart);
                sacred = true;
                AssignLayer();
            }
            else if (currentNote == rEnd)
            {
                sequence.RemoveAt(i);
                
                layersArray[19] = false;
                recScript.AddKnot(robotsEnd);
                sacred = false;
                AssignLayer();
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
        else if (knot.transform.name == "shintoStart")
        {
            currentNote = sStart;
        }
        else if (knot.transform.name == "shintoEnd")
        {
            currentNote = sEnd;
        }
        else if (knot.transform.name == "taoismStart")
        {
            currentNote = tStart;
        }
        else if (knot.transform.name == "taoismEnd")
        {
            currentNote = tEnd;
        }
        else if (knot.transform.name == "christianityStart")
        {
            currentNote = cStart;
        }
        else if (knot.transform.name == "christianityEnd")
        {
            currentNote = cEnd;
        }
        else if (knot.transform.name == "robotsStart")
        {
            currentNote = rStart;
        }
        else if (knot.transform.name == "robotsEnd")
        {
            currentNote = rEnd;
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
        
        if (knot.transform.name == "shintoStart" || knot.transform.name == "shintoEnd" || knot.transform.name == "taoismStart" || knot.transform.name == "taoismEnd" ||
            knot.transform.name == "christianityStart" || knot.transform.name == "christianityEnd" || knot.transform.name == "robotsStart" || knot.transform.name == "robotsEnd")
        {
            onScreen = true;
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
            if (i + 1 <= sequence.Count - 1)
            {
                sequence.Insert(i + 1, shintoEnd);
            }
            else
            {
                sequence.Insert(0, shintoEnd);
            }
        }
        else if (sacredObject.transform.name == "taoismKnotsZone")
        {
            if (i + 1 <= sequence.Count - 1)
            {
                sequence.Insert(i + 1, taoismEnd);
            }
            else
            {
                sequence.Insert(0, taoismEnd);
            }
        }
        else if (sacredObject.transform.name == "christianityKnotsZone")
        {
            if (i + 1 <= sequence.Count - 1)
            {
                sequence.Insert(i + 1, christianityEnd);
            }
            else
            {
                sequence.Insert(0, christianityEnd);
            }
        }
        else if (sacredObject.transform.name == "robotsKnotsZone")
        {
            if (i + 1 <= sequence.Count - 1)
            {
                sequence.Insert(i + 1, robotsEnd);
            }
            else
            {
                sequence.Insert(0, robotsEnd);
            }
        }
        
        timeInSeconds = regularTime;

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
