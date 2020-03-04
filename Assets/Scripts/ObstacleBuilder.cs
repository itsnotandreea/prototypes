using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBuilder : MonoBehaviour
{
    private int zone,
                obstacle;

    private string obstacleName;

    private GameObject playerOne,
                       floor,
                       obstacleGO;

    private PlayerOneController playerOneController;

    private KeyManager keyManager;

    private Vector3 objPosition;
                             
    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerOneController = playerOne.GetComponent<PlayerOneController>();

        floor = GameObject.FindGameObjectWithTag("Floor");
        keyManager = floor.GetComponent<KeyManager>();
        
        zone = 1;
        obstacle = 0;
    }

    public void BuildObstacle(int key, int extension)
    {
        if(key > 0)
        {
            zone = keyManager.zone;

            obstacle = zone * 100 + key * 10 + extension;

            obstacleName = obstacle.ToString();

            obstacleGO = GameObject.Find(obstacleName);
            
            objPosition = transform.position;

            Instantiate(obstacleGO, objPosition, transform.rotation);

            //StartCoroutine(Wait(0f));
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Instantiate(obstacleGO, objPosition, transform.rotation);
    }
}
