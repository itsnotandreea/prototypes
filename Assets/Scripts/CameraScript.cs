using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    float d;

    public RawImage splitTwo,
                    splitOne;

    public GameObject floor,
                      playerOne,
                      playerTwo;
    
    void LateUpdate()
    {
        CameraControls();
    }

    float GetAngleBetweenPlayers()
    {
        Vector3 pOneToWorld = playerOne.transform.position - floor.transform.position;
        Vector3 pTwoToWorld = playerTwo.transform.position - floor.transform.position;

        return Vector3.Angle(pOneToWorld, pTwoToWorld);
    }

    float GetArc()
    {
        float r = GetAngleBetweenPlayers();

        d = floor.GetComponent<SpriteRenderer>().sprite.bounds.size.x * floor.transform.localScale.x;
        
        return (r / (2f * Mathf.PI)) * d;
    }

    void CameraAlteration(float perc)
    {
        GetComponent<Camera>().orthographicSize = 27 + (5 * perc);
    }

    float GetPerc()
    {
        return GetArc() / d;
    }

    void TurnOnSecondCam()
    {
        splitOne.GetComponent<RawImage>().enabled = true;
        splitTwo.GetComponent<RawImage>().enabled = true;
    }

    void CameraControls()
    {
        if (GetPerc() > 1.10f)
        {
            TurnOnSecondCam();
        }
        else
        {
            CameraAlteration(GetPerc());

            if(splitTwo.GetComponent<RawImage>().enabled && playerOne.GetComponent<PlayerOneController>().round == playerTwo.GetComponent<PlayerTwoController>().round)
            {
                splitOne.GetComponent<RawImage>().enabled = false;
                splitTwo.GetComponent<RawImage>().enabled = false;
            }
        }
    }
}
