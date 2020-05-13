using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MusicPlayerScript : MonoBehaviour
{
    public static List<List<string>> playList = new List<List<string>>();

    public float timeInSeconds;
    
    FMOD.Studio.EventInstance musicEvent;

    private List<string> currentLine = new List<string>();

    private int index;
    
    void Start()
    {
        ReadTxtFile();
        
        musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/DUODEUSSOUND3/Empty");

        musicEvent.start();

        StartCoroutine(Play(timeInSeconds));
    }

    private void ReadTxtFile()
    {
        string path = Application.dataPath + "/Recording.txt";

        using (StreamReader reader = new StreamReader(path))
        {
            string allText = reader.ReadToEnd();
            char[] temp = new char[30];

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
                            "event:/DUODEUSSOUND3/" + tempo
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
            
            index++;
        }
    }

    private void Layers(int noteIndex)
    {
        for (int j = 0; j < 17; j++)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Layer" + j.ToString(), 0f);
        }
        
        for (int k = 1; k < playList[noteIndex].Count; k++)
        {
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName(playList[noteIndex][k], 1f);
            //Debug.Log(playList[noteIndex][k]);
        }
    }
}
