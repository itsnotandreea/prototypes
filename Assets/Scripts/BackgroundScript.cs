using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public int first,
               second,
               third,
               cloudIndex;

    private Color orangeCol,
                    blueCol,
                    greenCol,
                    yellowCol,
                    pinkCol,
                    purpleCol,
                    whiteCol,
                    coraiCol,
                    originalColour,
                    firstColour,
                    secondColour,
                    thirdColour,
                    newColour,
                    currentColour;

    public List<GameObject> cloudsList = new List<GameObject>();

    public Color[,] coloursArray= new Color[30,4];
    public int[,] elementsArray= new int[30,3];

    private GameObject currentCloud;

    void Start()
    {
        orangeCol = new Color(0.81f, 0.56f, 0.37f, 1.0f);
        blueCol = new Color(0.63f, 0.70f, 0.77f, 1.0f);
        greenCol = new Color(0.59f, 0.75f, 0.36f, 1.0f);
        yellowCol = new Color(0.95f, 0.87f, 0.53f, 1.0f);
        pinkCol = new Color(0.82f, 0.62f, 0.66f, 1.0f);
        purpleCol = new Color(0.49f, 0.43f, 0.54f, 1.0f);
        whiteCol = new Color(0.79f, 0.79f, 0.79f, 1.0f);
        coraiCol = new Color(0.80f, 0.70f, 0.56f, 1.0f);

        firstColour = secondColour = thirdColour = originalColour = new Color(0.20f, 0.25f, 0.25f, 1.0f);

        newColour = originalColour;

        first = second = third = 0;

        cloudIndex = 0;

        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                coloursArray[i, j] = originalColour;

                if (j < 3)
                {
                    elementsArray[i, j] = 0;
                }
            }
        }
    }
    
    void Update()
    {
        if (currentCloud != null)
        {
            ChangeColour(currentCloud);
        }
    }

    public void GetCollectable(GameObject collectable)
    {
        if (collectable.transform.name == "CollectableCorai(Clone)")
        {
            AddColour(coraiCol);
        }
        else if (collectable.transform.name == "CollectablePink(Clone)")
        {
            AddColour(pinkCol);
        }
        else if (collectable.transform.name == "CollectableOrange(Clone)")
        {
            AddColour(orangeCol);
        }
        else if (collectable.transform.name == "CollectablePurple(Clone)")
        {
            AddColour(purpleCol);
        }
        else if (collectable.transform.name == "CollectableGreen(Clone)")
        {
            AddColour(greenCol);
        }
        else if (collectable.transform.name == "CollectableBlue(Clone)")
        {
            AddColour(blueCol);
        }
        else if (collectable.transform.name == "CollectableYellow(Clone)")
        {
            AddColour(yellowCol);
        }
    }

    public void GetCloud(GameObject cloud)
    {
        bool gasit = false;

        if (cloudsList.Count > 0)
        {
            for (int i = 0; i < cloudsList.Count && !gasit; i++)
            {
                if (cloud == cloudsList[i])
                {
                    currentCloud = cloudsList[i];
                    gasit = true;
                    cloudIndex = i + 1;
                }
            }
            if (!gasit)
            {
                cloudsList.Add(cloud);
                currentCloud = cloudsList[cloudsList.Count - 1];

                cloudIndex = cloudsList.Count;
            }
        }
        else
        {
            cloudsList.Add(cloud);
            currentCloud = cloudsList[cloudsList.Count - 1];

            cloudIndex = cloudsList.Count;
        }
    }

    private void ChangeColour(GameObject curCloud)
    {
        curCloud.GetComponent<SpriteRenderer>().color = Color.Lerp(curCloud.GetComponent<SpriteRenderer>().color, coloursArray[cloudIndex, 3], Time.deltaTime * 0.5f);
    }

    private void AddColour(Color newCol)
    {
        if (cloudIndex > 0)
        {
            first = elementsArray[cloudIndex, 0];
            second = elementsArray[cloudIndex, 1];
            third = elementsArray[cloudIndex, 2];

            firstColour = coloursArray[cloudIndex, 0];
            secondColour = coloursArray[cloudIndex, 1];
            thirdColour = coloursArray[cloudIndex, 2];

            if (first == second && second == third)
            {
                firstColour = newCol;
                coloursArray[cloudIndex, 0] = newCol;
                first++;
                elementsArray[cloudIndex, 0] = first;
            }
            else if (first > second && second == third)
            {
                secondColour = newCol;
                coloursArray[cloudIndex, 1] = newCol;
                second++;
                elementsArray[cloudIndex, 1] = second;
            }
            else if (first == second && second > third)
            {
                thirdColour = newCol;
                coloursArray[cloudIndex, 2] = newCol;
                third++;
                elementsArray[cloudIndex, 2] = third;
            }

            newColour.r = (firstColour.r + secondColour.r + thirdColour.r) / 3;
            newColour.g = (firstColour.g + secondColour.g + thirdColour.g) / 3;
            newColour.b = (firstColour.b + secondColour.b + thirdColour.b) / 3;
            newColour.a = 1.0f;

            coloursArray[cloudIndex, 3] = newColour;
        }
    }
}
