using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MusicPlayerScript : MonoBehaviour
{
    public static List<List<string>> playList = new List<List<string>>();

    public float timeInSeconds;
    
    public FMOD.Studio.EventInstance musicEvent;

    public TextAsset songFile;
    
    private int index;
    
    void OnEnable()
    {
        index = 0;

        if (playList.Count > 0)
        {
            playList.Clear();
        }
        
        ReadTxtFile();
        
        musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SOUND6/Empty");

        musicEvent.start();

        StartCoroutine(Play(timeInSeconds));
    }

    private void OnDisable()
    {
        musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        if (playList.Count > 0)
        {
            playList.Clear();
        }
    }

    private void ReadTxtFile()
    {
        string allText = songFile.ToString();
        char[] temp = new char[10];

        int k;
        k = 0;

        bool newLine = true;

        for (int i = 0; i < allText.Length; i++)
        {
            char currentChar = allText[i];

            if (currentChar == ' ')
            {
                string tempo = new string(temp);

                if (newLine)
                {
                    List<string> noteList = new List<string>
                    {
                        "event:/SOUND6/" + tempo
                    };

                    playList.Add(noteList);

                    index = playList.Count - 1;
                    newLine = false;
                }
                else
                {
                    playList[index].Add("Layer" + tempo);
                }

                for (int j = 0; j < k; j++)
                {
                    temp[j] = '\0';
                }
                k = 0;
            }
            else if (currentChar == '\n')
            {
                newLine = true;
            }
            else
            {
                temp[k] = currentChar;
                k++;
            }
        }
        index = 0;
    }

    IEnumerator Play(float time)
    {
        while (index < playList.Count)
        {
            Layers(index);

            FMODUnity.RuntimeManager.CreateInstance(playList[index][0]);
            FMODUnity.RuntimeManager.PlayOneShot(playList[index][0], transform.position);
            
            yield return new WaitForSeconds(time);

            if (playList[index][0] == "shintoStart")
            {
                yield return new WaitForSeconds(0.38f);
            }
            else if (playList[index][0] == "shintoEnd")
            {
                yield return new WaitForSeconds(0.38f);
            }
            else if (playList[index][0] == "taoismStart")
            {
                yield return new WaitForSeconds(0.38f);
            }
            else if (playList[index][0] == "taoismEnd")
            {
                yield return new WaitForSeconds(0.38f);
            }
            else if (playList[index][0] == "christianityStart")
            {
                yield return new WaitForSeconds(0.98f);
            }
            else if (playList[index][0] == "christianityEnd")
            {
                yield return new WaitForSeconds(1.6f);
            }
            
            index++;
        }
    }

    private void Layers(int noteIndex)
    {
        bool sacred = false;

        for (int j = 2; j < 21; j++)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer" + j.ToString(), 0f);
        }
        
        for (int k = playList[noteIndex].Count - 1; k > 0; k--)
        {
            char[] temp = new char[8];
            string tempo = new string(temp);
            
            if (playList[noteIndex][k].Equals("Layer20" + tempo) || playList[noteIndex][k].Equals("Layer19" + tempo) || playList[noteIndex][k].Equals("Layer18" + tempo))
            {
                sacred = true;
            }

            if (sacred)
            {
                if (playList[noteIndex][k].Equals("Layer20" + tempo) || playList[noteIndex][k].Equals("Layer19" + tempo) || playList[noteIndex][k].Equals("Layer18" + tempo))
                {
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName(playList[noteIndex][k], 1f);
                }
                else
                {
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName(playList[noteIndex][k], 0.0f);
                }
            }
            else
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(playList[noteIndex][k], 1f);
            }
        }

        if (sacred)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer1", 0.0f);
        }
        else
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer1", 1f);
        }
    }
}
