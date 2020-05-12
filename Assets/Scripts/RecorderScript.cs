using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderScript : MonoBehaviour
{
    public static List<string> clipsList = new List<string>(); // Static List instance

    public static string[][] layersArray = new string[101][];

    private string A,
                   B,
                   C,
                   D,
                   E,
                   F,
                   G;

    private int index,
                i,
                j;

    private MusicSequence musicSeq;
  
    private void Start()
    {
        musicSeq = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSequence>();

        A = "event:/DUODEUSSOUND3/A";
        B = "event:/DUODEUSSOUND3/B";
        C = "event:/DUODEUSSOUND3/C";
        D = "event:/DUODEUSSOUND3/D";
        E = "event:/DUODEUSSOUND3/E";
        F = "event:/DUODEUSSOUND3/F";
        G = "event:/DUODEUSSOUND3/G";
    }

    public void AddKnot(GameObject knot)
    {
        if (knot.transform.name == "knotA" || knot.transform.name == "knotA(Clone)")
        {
            AddToRecording(A);
        }
        else if (knot.transform.name == "knotB" || knot.transform.name == "knotB(Clone)")
        {
            AddToRecording(B);
        }
        else if (knot.transform.name == "knotC" || knot.transform.name == "knotC(Clone)")
        {
            AddToRecording(C);
        }
        else if (knot.transform.name == "knotD" || knot.transform.name == "knotD(Clone)")
        {
            AddToRecording(D);
        }
        else if (knot.transform.name == "knotE" || knot.transform.name == "knotE(Clone)")
        {
            AddToRecording(E);
        }
        else if (knot.transform.name == "knotF" || knot.transform.name == "knotF(Clone)")
        {
            AddToRecording(F);
        }
        else if (knot.transform.name == "knotG" || knot.transform.name == "knotG(Clone)")
        {
            AddToRecording(G);
        }
    }

    private void AddToRecording(string newNote)
    {
        clipsList.Add(newNote);

        index = clipsList.Count - 1;

        GetLayers();
    }

    private void GetLayers()
    {
        int count = 0;

        if (musicSeq.layerTwo)
        {
            count++;
        }

        if (musicSeq.layerThree)
        {
            count++;
        }

        if (musicSeq.layerFour)
        {
            count++;
        }

        if (musicSeq.layerFive)
        {
            count++;
        }

        if (musicSeq.layerSix)
        {
            count++;
        }

        if (musicSeq.layerSeven)
        {
            count++;
        }

        if (musicSeq.layerEight)
        {
            count++;
        }

        if (musicSeq.layerNine)
        {
            count++;
        }

        if (musicSeq.layerTen)
        {
            count++;
        }

        if (musicSeq.layerEleven)
        {
            count++;
        }

        if (musicSeq.layerTwelve)
        {
            count++;
        }

        if (musicSeq.layerThirteen)
        {
            count++;
        }

        if (musicSeq.layerFourteen)
        {
            count++;
        }

        if (musicSeq.layerFifteen)
        {
            count++;
        }

        if (musicSeq.layerSixteen)
        {
            count++;
        }

        if (musicSeq.layerSeventeen)
        {
            count++;
        }

        
        layersArray[index] = new string[count];

        j = 0;



        if (musicSeq.layerTwo)
        {
            layersArray[index][j] = "Layer2";
            j++;
        }

        if (musicSeq.layerThree)
        {
            layersArray[index][j] = "Layer3";
            j++;
        }

        if (musicSeq.layerFour)
        {
            layersArray[index][j] = "Layer4";
            j++;
        }

        if (musicSeq.layerFive)
        {
            layersArray[index][j] = "Layer5";
            j++;
        }

        if (musicSeq.layerSix)
        {
            layersArray[index][j] = "Layer6";
            j++;
        }

        if (musicSeq.layerSeven)
        {
            layersArray[index][j] = "Layer7";
            j++;
        }

        if (musicSeq.layerEight)
        {
            layersArray[index][j] = "Layer8";
            j++;
        }

        if (musicSeq.layerNine)
        {
            layersArray[index][j] = "Layer9";
            j++;
        }

        if (musicSeq.layerTen)
        {
            layersArray[index][j] = "Layer10";
            j++;
        }

        if (musicSeq.layerEleven)
        {
            layersArray[index][j] = "Layer11";
            j++;
        }

        if (musicSeq.layerTwelve)
        {
            layersArray[index][j] = "Layer12";
            j++;
        }

        if (musicSeq.layerThirteen)
        {
            layersArray[index][j] = "Layer13";
            j++;
        }

        if (musicSeq.layerFourteen)
        {
            layersArray[index][j] = "Layer14";
            j++;
        }

        if (musicSeq.layerFifteen)
        {
            layersArray[index][j] = "Layer15";
            j++;
        }

        if (musicSeq.layerSixteen)
        {
            layersArray[index][j] = "Layer16";
            j++;
        }

        if (musicSeq.layerSeventeen)
        {
            layersArray[index][j] = "Layer17";
            j++;
        }
    }
}
