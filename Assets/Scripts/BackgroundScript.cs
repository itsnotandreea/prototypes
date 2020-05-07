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
                    darkBlueCol,
                    darkPinkCol,
                    limeCol,
                    marineCol,
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
        //all colours the clouds can take
        orangeCol = new Color(1.0f, 0.12f, 0.29f, 1.0f);
        blueCol = new Color(0.79f, 0.0f, 0.07f, 1.0f);
        greenCol = new Color(0.24f, 0.89f, 0.94f, 1.0f);
        yellowCol = new Color(1.0f, 0.72f, 0.27f, 1.0f);
        pinkCol = new Color(0.92f, 0.38f, 0.47f, 1.0f);
        purpleCol = new Color(0.80f, 0.51f, 1.0f, 1.0f);
        whiteCol = new Color(0.76f, 0.99f, 1.0f, 1.0f);
        coraiCol = new Color(0.53f, 0.26f, 0.53f, 1.0f);
        darkBlueCol = new Color(0.76f, 0.76f, 1.0f, 1.0f);
        darkPinkCol = new Color(1.0f, 0.20f, 0.58f, 1.0f);
        limeCol = new Color(0.75f, 1.0f, 0.20f, 1.0f);
        marineCol = new Color(0.35f, 0.85f, 0.67f, 1.0f);

        //originally, all clouds will be the same colour
        firstColour = secondColour = thirdColour = originalColour = new Color(0.20f, 0.25f, 0.25f, 1.0f);

        newColour = originalColour;

        //initially, the clouds have no extra colours
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
        //gets input from the second player collectable
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
        else if (collectable.transform.name == "CollectableDarkBlue(Clone)")
        {
            AddColour(darkBlueCol);
        }
        else if (collectable.transform.name == "CollectableDarkPink(Clone)")
        {
            AddColour(darkPinkCol);
        }
        else if (collectable.transform.name == "CollectableLime(Clone)")
        {
            AddColour(limeCol);
        }
        else if (collectable.transform.name == "CollectableMarine(Clone)")
        {
            AddColour(marineCol);
        }
    }

    public void GetCloud(GameObject cloud)
    {
        //gets input which cloud player 2 is in
        bool gasit = false;

        //checks if there are any clouds in the list already
        if (cloudsList.Count > 0)
        {
            //checks if the cloud has already been entered in before
            for (int i = 0; i < cloudsList.Count && !gasit; i++)
            {
                if (cloud == cloudsList[i])
                {
                    //if found, the currentCloud temporary variable takes it's reference
                    currentCloud = cloudsList[i];
                    gasit = true;
                    //saves its index, so we can access the coloursList and elementsArray data structures for the specific cloud
                    cloudIndex = i + 1;
                }
            }
            if (!gasit)
            {
                //if not found, adds the cloud to the list
                cloudsList.Add(cloud);
                currentCloud = cloudsList[cloudsList.Count - 1];

                //saves its index
                cloudIndex = cloudsList.Count;
            }
        }
        else
        {
            //if there are not, directly adds new and first cloud
            cloudsList.Add(cloud);
            currentCloud = cloudsList[cloudsList.Count - 1];

            //saves index
            cloudIndex = cloudsList.Count;
        }
    }

    private void ChangeColour(GameObject curCloud)
    {
        //gradually changes the cloud's colour to the forth value saved in the data structure
        if(curCloud.GetComponent<SpriteRenderer>().color != coloursArray[cloudIndex, 3])
        {
            curCloud.GetComponent<SpriteRenderer>().color = Color.Lerp(curCloud.GetComponent<SpriteRenderer>().color, coloursArray[cloudIndex, 3], Time.deltaTime * 0.5f);
        }
    }

    private void AddColour(Color newCol)
    {
        if (cloudIndex > 0)
        {
            //from the elementsArray, takes its values, to know which colour was added last
            first = elementsArray[cloudIndex, 0];
            second = elementsArray[cloudIndex, 1];
            third = elementsArray[cloudIndex, 2];

            //from the coloursArray, takes the previous used colours
            firstColour = coloursArray[cloudIndex, 0];
            secondColour = coloursArray[cloudIndex, 1];
            thirdColour = coloursArray[cloudIndex, 2];

            //checks which element (first/second/third) was changed last, and changes the next's colour
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

            //edits the colour's RGB value, keeping alpha at 1 (opaque)
            newColour.r = (firstColour.r + secondColour.r + thirdColour.r) / 3;
            newColour.g = (firstColour.g + secondColour.g + thirdColour.g) / 3;
            newColour.b = (firstColour.b + secondColour.b + thirdColour.b) / 3;
            newColour.a = 1.0f;

            //saves the new colour properties in a forth variable
            coloursArray[cloudIndex, 3] = newColour;
        }
    }
}
