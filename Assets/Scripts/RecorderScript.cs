using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecorderScript : MonoBehaviour
{
    public static List<List<string>> playList = new List<List<string>>();

    public TextAsset songFile;

    private int index;

    private string path;

    private MusicSequence musicSeq;

    private MainManager mainManager;

    private void Start()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<MainManager>();

        musicSeq = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSequence>();
        
        path = Path.Combine(Application.persistentDataPath, "Art" + (mainManager.gallerySize + 1) + ".txt");
        
        /*
        if (File.Exists(path))
        {
            File.Delete(path);
            File.Delete(Application.dataPath + "/Resources/Artwork/Art" + (mainManager.gallerySize + 1) + ".txt");
        }
        */
    }

    public void AddKnot(GameObject knot)
    {
        if (knot.transform.name == "knotA" || knot.transform.name == "knotA(Clone)")
        {
            AddToRecording("A");
        }
        else if (knot.transform.name == "knotB" || knot.transform.name == "knotB(Clone)")
        {
            AddToRecording("B");
        }
        else if (knot.transform.name == "knotC" || knot.transform.name == "knotC(Clone)")
        {
            AddToRecording("C");
        }
        else if (knot.transform.name == "knotD" || knot.transform.name == "knotD(Clone)")
        {
            AddToRecording("D");
        }
        else if (knot.transform.name == "knotE" || knot.transform.name == "knotE(Clone)")
        {
            AddToRecording("E");
        }
        else if (knot.transform.name == "knotF" || knot.transform.name == "knotF(Clone)")
        {
            AddToRecording("F");
        }
        else if (knot.transform.name == "knotG" || knot.transform.name == "knotG(Clone)")
        {
            AddToRecording("G");
        }
        else if (knot.transform.name == "knotShintoC" || knot.transform.name == "knotShintoC(Clone)")
        {
            AddToRecording("C");
        }
        else if (knot.transform.name == "knotShintoCsharp" || knot.transform.name == "knotShintoCsharp(Clone)")
        {
            AddToRecording("Csharp");
        }
        else if (knot.transform.name == "knotShintoF" || knot.transform.name == "knotShintoF(Clone)")
        {
            AddToRecording("F");
        }
        else if (knot.transform.name == "knotShintoG" || knot.transform.name == "knotShintoG(Clone)")
        {
            AddToRecording("G");
        }
        else if (knot.transform.name == "knotShintoGsharp" || knot.transform.name == "knotShintoGsharp(Clone)")
        {
            AddToRecording("Gsharp");
        }
        else if (knot.transform.name == "knotShintoCC" || knot.transform.name == "knotShintoCC(Clone)")
        {
            AddToRecording("CC");
        }
        else if (knot.transform.name == "knotShintoCCsharp" || knot.transform.name == "knotShintoCCsharp(Clone)")
        {
            AddToRecording("CCsharp");
        }
        else if (knot.transform.name == "knotShintoC" || knot.transform.name == "knotShintoC(Clone)")
        {
            AddToRecording("C");
        }
        else if (knot.transform.name == "knotShintoCsharp" || knot.transform.name == "knotShintoCsharp(Clone)")
        {
            AddToRecording("Csharp");
        }
        else if (knot.transform.name == "knotShintoD" || knot.transform.name == "knotShintoD(Clone)")
        {
            AddToRecording("D");
        }
        else if (knot.transform.name == "knotShintoE" || knot.transform.name == "knotShintoD(Clone)")
        {
            AddToRecording("E");
        }
        else if (knot.transform.name == "knotShintoF" || knot.transform.name == "knotShintoF(Clone)")
        {
            AddToRecording("F");
        }
        else if (knot.transform.name == "knotShintoG" || knot.transform.name == "knotShintoG(Clone)")
        {
            AddToRecording("G");
        }
        else if (knot.transform.name == "knotShintoGsharp" || knot.transform.name == "knotShintoGsharp(Clone)")
        {
            AddToRecording("Gsharp");
        }
        else if (knot.transform.name == "knotTaoismA" || knot.transform.name == "knotTaoismA(Clone)")
        {
            AddToRecording("A");
        }
        else if (knot.transform.name == "knotTaoismC" || knot.transform.name == "knotTaoismC(Clone)")
        {
            AddToRecording("C");
        }
        else if (knot.transform.name == "knotTaoismD" || knot.transform.name == "knotTaoismD(Clone)")
        {
            AddToRecording("D");
        }
        else if (knot.transform.name == "knotTaoismE" || knot.transform.name == "knotTaoismE(Clone)")
        {
            AddToRecording("E");
        }
        else if (knot.transform.name == "knotTaoismCC" || knot.transform.name == "knotTaoismCC(Clone)")
        {
            AddToRecording("CC");
        }
        else if (knot.transform.name == "knotTaoismG" || knot.transform.name == "knotTaoismG(Clone)")
        {
            AddToRecording("G");
        }
    }

    private void AddToRecording(string newNote)
    {
        List<string> noteList = new List<string>
        {
            newNote
        };

        playList.Add(noteList);

        index = playList.Count - 1;

        GetLayers();
    }

    private void GetLayers()
    {
        if (musicSeq.layersArray[0])
        {
            playList[index].Add("2");
        }

        if (musicSeq.layersArray[1])
        {
            playList[index].Add("3");
        }

        if (musicSeq.layersArray[2])
        {
            playList[index].Add("4");
        }

        if (musicSeq.layersArray[3])
        {
            playList[index].Add("5");
        }

        if (musicSeq.layersArray[4])
        {
            playList[index].Add("6");
        }

        if (musicSeq.layersArray[5])
        {
            playList[index].Add("7");
        }

        if (musicSeq.layersArray[6])
        {
            playList[index].Add("8");
        }

        if (musicSeq.layersArray[7])
        {
            playList[index].Add("9");
        }

        if (musicSeq.layersArray[8])
        {
            playList[index].Add("10");
        }

        if (musicSeq.layersArray[9])
        {
            playList[index].Add("11");
        }

        if (musicSeq.layersArray[10])
        {
            playList[index].Add("12");
        }

        if (musicSeq.layersArray[11])
        {
            playList[index].Add("13");
        }

        if (musicSeq.layersArray[12])
        {
            playList[index].Add("14");
        }

        if (musicSeq.layersArray[13])
        {
            playList[index].Add("15");
        }

        if (musicSeq.layersArray[14])
        {
            playList[index].Add("16");
        }

        if (musicSeq.layersArray[15])
        {
            playList[index].Add("17");
        }

        if (musicSeq.layersArray[16])
        {
            playList[index].Add("18");
        }

        if (musicSeq.layersArray[17])
        {
            playList[index].Add("19");
        }

        if (musicSeq.layersArray[18])
        {
            playList[index].Add("20");
        }
    }

    public void WriteTxtFile()
    {
        StreamWriter writer = new StreamWriter(path, true);

        for (int i = 0; i < playList.Count; i++)
        {
            for (int j = 0; j < playList[i].Count; j++)
            {
                writer.Write(playList[i][j] + " ");
            }
            writer.Write("\n");
        }

        writer.Close();
        writer.Dispose();
    }
}
