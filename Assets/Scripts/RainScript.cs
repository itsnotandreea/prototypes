using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    public GameObject dropOne,
                      dropTwo,
                      dropThree;

    private Vector3 posOne,
                    posTwo,
                    posThree;

    void Start()
    {
        posOne = dropOne.transform.position;
        posTwo = dropTwo.transform.position;
        posThree = dropThree.transform.position;

        dropOne.SetActive(false);
        dropTwo.SetActive(false);
        dropThree.SetActive(false);
    }

    public IEnumerator MakeItRain()
    {
        dropOne.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        dropThree.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        dropTwo.SetActive(true);


        yield return new WaitForSeconds(5.0f);

        dropOne.transform.position = posOne;
        dropTwo.transform.position = posTwo;
        dropThree.transform.position = posThree;

        dropOne.SetActive(false);
        dropTwo.SetActive(false);
        dropThree.SetActive(false);
    }
}
