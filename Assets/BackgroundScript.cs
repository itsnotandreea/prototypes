using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public int first,
               second,
               third;

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
                    newColour;

    public List<GameObject> clouds = new List<GameObject>();

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
    }
    
    void Update()
    {
        if (currentCloud != null)
        {
            currentCloud.GetComponent<SpriteRenderer>().color = Color.Lerp(currentCloud.GetComponent<SpriteRenderer>().color, newColour, Time.deltaTime);
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

        if (clouds.Count > 0)
        {
            for (int i = 0; i < clouds.Count && !gasit; i++)
            {
                if (cloud == clouds[i])
                {
                    currentCloud = clouds[i];
                    gasit = true;
                }
            }
            if (!gasit)
            {
                currentCloud = cloud;
                clouds.Add(currentCloud);
            }
        }
        else
        {
            currentCloud = cloud;
            clouds.Add(currentCloud);
        }

        first = second = third = 0;

        firstColour = secondColour = thirdColour = originalColour;
    }

    private void AddColour(Color newCol)
    {
        if (first == second && second == third)
        {
            firstColour = newCol;
            first++;
        }
        else if (first > second && second == third)
        {
            secondColour = newCol;
            second++;
        }
        else if (first == second && second > third)
        {
            thirdColour = newCol;
            third++;
        }

        newColour.r = (firstColour.r + secondColour.r + thirdColour.r) / 3;
        newColour.g = (firstColour.g + secondColour.g + thirdColour.g) / 3;
        newColour.b = (firstColour.b + secondColour.b + thirdColour.b) / 3;
        newColour.a = 1.0f;
    }
}
