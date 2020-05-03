using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamScript : MonoBehaviour
{
    public float speed;

    public bool autoCamera,
                menuMode,
                finishedMode;
    
    public GameObject floor,
                      playerOne,
                      playerTwo;

    public Vector3 newPosition,
                   behindPos,
                   menuPosOne,
                   menuPosTwo,
                   menuPosThree,
                   menuCurrentPos,
                   finalPicturePos;
    
    public Camera cam;

    private float distance;

    private void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();

        behindPos = new Vector3(1.0f, 1.0f, 0.0f) * 10.0f;

        menuPosOne = new Vector3(21.5f, 19.0f, -10.0f);
        menuPosTwo = new Vector3(71.0f, -22.0f, -10.0f);
        menuPosThree = new Vector3(86.0f, -52.0f, -10.0f);
        finalPicturePos = new Vector3(-89.0f, -131.0f, -10.0f);

        menuCurrentPos = menuPosOne;

        finishedMode = false;
        autoCamera = true;
    }

    private void Update()
    {
        if (!menuMode && !finishedMode)
        {
            if (autoCamera)
            {
                //change position of the camera if playerOne is out of screen
                distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - playerOne.transform.position.x, 2.0f) + Mathf.Pow(transform.position.y - playerOne.transform.position.y, 2.0f));

                if (distance > 30.0f)
                {
                    Vector3 playerPos = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y, transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, playerPos - transform.TransformDirection(behindPos), Time.deltaTime * speed);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed);
            }
        }
        else if (menuMode && !finishedMode)
        {
            transform.position = Vector3.MoveTowards(transform.position, menuCurrentPos, Time.deltaTime * speed);
        }
        else if (finishedMode)
        {
            transform.position = finalPicturePos;
        }
    }
}
