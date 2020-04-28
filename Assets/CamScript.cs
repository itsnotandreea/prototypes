using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamScript : MonoBehaviour
{
    float d;

    public float speed,
                 dist;

    public bool autoCamera;

    public RawImage splitTwo,
                    splitOne;

    public GameObject floor,
                      playerOne,
                      playerTwo;

    public Vector3 newPosition,
                   behindPos;

    private float distance;

    private bool onScreen;

    private Camera cam;

    private void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();

        behindPos = new Vector3(1.0f, 1.0f) * 10.0f;

        onScreen = true;
        autoCamera = true;
    }

    private void Update()
    {
        if (autoCamera)
        {
            //change position of the camera if playerOne is out of screen
            distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - playerOne.transform.position.x, 2.0f) + Mathf.Pow(transform.position.y - playerOne.transform.position.y, 2.0f));
            if (distance > 18.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerOne.transform.position - transform.TransformDirection(behindPos), Time.deltaTime * speed);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed);
        }
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

    void CameraControls()
    {
        if (GetPerc() < 1.10f)
        {
            //CameraAlteration(GetPerc());
        }
    }

    private void CheckIfOnScreen()
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(playerTwo.transform.position);

        if (screenPoint.x > 0.05f && screenPoint.x < 0.95f && screenPoint.y > 0.05f && screenPoint.y < 0.95f)
        {
            onScreen = true;
        }
        else
        {
            onScreen = false;
        }
    }
}
