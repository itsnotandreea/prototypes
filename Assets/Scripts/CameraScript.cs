using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    float d;

    public float speed,
                 dist;

    public RawImage splitTwo,
                    splitOne;

    public GameObject floor,
                      playerOne,
                      playerTwo;

    private Vector3 newPosition,
                    initialPosition;

    private void Start()
    {
        initialPosition = transform.position - floor.transform.position;
    }

    private void Update()
    {
        newPosition = new Vector3((playerOne.transform.position.x + playerTwo.transform.position.x) / 2,
                                  (playerOne.transform.position.y + playerTwo.transform.position.y) / 2,
                                  this.transform.position.z);
        
        newPosition = newPosition + transform.TransformDirection(Vector3.up) * dist;

        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed);
    }

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
        GetComponent<Camera>().orthographicSize = 35 + (5 * perc);
    }

    float GetPerc()
    {
        return GetArc() / d;
    }

    /*
    void TurnOnSecondCam()
    {
        splitOne.GetComponent<RawImage>().enabled = true;
        splitTwo.GetComponent<RawImage>().enabled = true;
    }
    */

    void CameraControls()
    {
        if (GetPerc() > 1.10f)
        {
            //TurnOnSecondCam();
        }
        else
        {
            CameraAlteration(GetPerc());

            /*
            if(splitTwo.GetComponent<RawImage>().enabled && playerOne.GetComponent<PlayerOneController>().round == playerTwo.GetComponent<PlayerTwoController>().round)
            {
                splitOne.GetComponent<RawImage>().enabled = false;
                splitTwo.GetComponent<RawImage>().enabled = false;
            }
            */
        }
    }
}
