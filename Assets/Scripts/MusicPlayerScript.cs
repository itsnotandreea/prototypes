using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public float timeInSeconds;
    
    FMOD.Studio.EventInstance musicEvent;

    private int i;

    private RecorderScript recScript;
    
    void Start()
    {
        recScript = GameObject.FindGameObjectWithTag("Recorder").GetComponent<RecorderScript>();

        musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/DUODEUSSOUND3/Empty");

        musicEvent.start();

        StartCoroutine(Play(timeInSeconds));
    }

    IEnumerator Play(float time)
    {
        while (i < RecorderScript.clipsList.Count)
        {
            Layers(i);

            FMODUnity.RuntimeManager.CreateInstance(RecorderScript.clipsList[i]);
            FMODUnity.RuntimeManager.PlayOneShot(RecorderScript.clipsList[i], transform.position);
            
            yield return new WaitForSeconds(time);
            
            i++;
        }
    }

    private void Layers(int index)
    {
        for (int j = 0; j < 17; j++)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer" + j.ToString(), 0f);
        }
        
        for (int k = 0; k < RecorderScript.layersArray[index].Length; k++)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(RecorderScript.layersArray[index][k], 1f);
            Debug.Log(RecorderScript.layersArray[index][k]);
        }
    }
}
