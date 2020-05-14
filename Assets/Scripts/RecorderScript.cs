using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecorderScript : MonoBehaviour
{
    public static List<List<string>> playList = new List<List<string>>();

    private int index;

    private string path;

    private MusicSequence musicSeq;
  
    private void Start()
    {
        musicSeq = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSequence>();

        path = Application.dataPath + "/Recording.txt";

        if (File.Exists(path))
        {
            File.Delete(path);
            File.Delete(Application.dataPath + "/Recording.meta");
        }
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

        WriteTxtFile();
    }

    private void GetLayers()
    {
        if (musicSeq.layerTwo)
        {
            playList[index].Add("2");
        }

        if (musicSeq.layerThree)
        {
            playList[index].Add("3");
        }

        if (musicSeq.layerFour)
        {
            playList[index].Add("4");
        }

        if (musicSeq.layerFive)
        {
            playList[index].Add("5");
        }

        if (musicSeq.layerSix)
        {
            playList[index].Add("6");
        }

        if (musicSeq.layerSeven)
        {
            playList[index].Add("7");
        }

        if (musicSeq.layerEight)
        {
            playList[index].Add("8");
        }

        if (musicSeq.layerNine)
        {
            playList[index].Add("9");
        }

        if (musicSeq.layerTen)
        {
            playList[index].Add("10");
        }

        if (musicSeq.layerEleven)
        {
            playList[index].Add("11");
        }

        if (musicSeq.layerTwelve)
        {
            playList[index].Add("12");
        }

        if (musicSeq.layerThirteen)
        {
            playList[index].Add("13");
        }

        if (musicSeq.layerFourteen)
        {
            playList[index].Add("14");
        }

        if (musicSeq.layerFifteen)
        {
            playList[index].Add("15");
        }

        if (musicSeq.layerSixteen)
        {
            playList[index].Add("16");
        }

        if (musicSeq.layerSeventeen)
        {
            playList[index].Add("17");
        }
    }

    public void WriteTxtFile()
    {
        StreamWriter writer = new StreamWriter(path, true);

        for (int i = 0; i < playList[index].Count; i++)
        {
            writer.Write(playList[index][i] + " ");
        }

        writer.Write("\n");
        writer.Close();
    }
}
