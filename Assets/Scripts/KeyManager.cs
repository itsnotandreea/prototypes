using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int zone;

    private bool keySwitch;

    private Vector2 playerPosition;

    private GameObject player;

    private PlayerController playerController;
    private FauxGravityAttractor attractor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        attractor = GetComponent<FauxGravityAttractor>();

        playerPosition = attractor.gravityUp;

        zone = 1;
    }

    
    void Update()
    {
        FindZone();

        keySwitch = playerController.keySwitch;

        switch(zone)
        {
            case 1:
                if (keySwitch)
                    Debug.Log("Key: C major");
                else Debug.Log("Key: A minor");
                break;
            case 2:
                if (keySwitch)
                    Debug.Log("Key: G major");
                else Debug.Log("Key: E minor");
                break;
            case 3:
                if (keySwitch)
                    Debug.Log("Key: D major");
                else Debug.Log("Key: B minor");
                break;
            case 4:
                if (keySwitch)
                    Debug.Log("Key: A major");
                else Debug.Log("Key: F# minor");
                break;
            case 5:
                if (keySwitch)
                    Debug.Log("Key: E major");
                else Debug.Log("Key: C# minor");
                break;
            case 6:
                if (keySwitch)
                    Debug.Log("Key: B major");
                else Debug.Log("Key: G# minor");
                break;
            case 7:
                if (keySwitch)
                    Debug.Log("Key: F# major");
                else Debug.Log("Key: D# minor");
                break;
            case 8:
                if (keySwitch)
                    Debug.Log("Key: Db major");
                else Debug.Log("Key: Bb minor");
                break;
            case 9:
                if (keySwitch)
                    Debug.Log("Key: Ab major");
                else Debug.Log("Key: F minor");
                break;
            case 10:
                if (keySwitch)
                    Debug.Log("Key: Eb major");
                else Debug.Log("Key: C minor");
                break;
            case 11:
                if (keySwitch)
                    Debug.Log("Key: Bb major");
                else Debug.Log("Key: G minor");
                break;
            case 12:
                if (keySwitch)
                    Debug.Log("Key: F major");
                else Debug.Log("Key: D minor");
                break;
            default:
                Debug.Log("Key: C major");
                break;
        }
    }

    private void FindZone()
    {
        playerPosition = attractor.gravityUp;

        if (-1.0f <= playerPosition.x && playerPosition.x < -0.866f)
        {
            if (playerPosition.y >= 0.0f)
            {
                zone = 10;
            }
            else
            {
                zone = 9;
            }
        }
        else if (-0.866f <= playerPosition.x && playerPosition.x < -0.5f)
        {
            if (playerPosition.y >= 0.0f)
            {
                zone = 11;
            }
            else
            {
                zone = 8;
            }
        }
        else if (-0.5f <= playerPosition.x && playerPosition.x < 0.0f)
        {
            if (playerPosition.y >= 0.0f)
            {
                zone = 12;
            }
            else
            {
                zone = 7;
            }
        }
        else if (0.0f <= playerPosition.x && playerPosition.x < 0.5f)
        {
            if (playerPosition.y >= 0.0f)
            {
                zone = 1;
            }
            else
            {
                zone = 6;
            }
        }
        else if (0.5f <= playerPosition.x && playerPosition.x < 0.866f)
        {
            if (playerPosition.y >= 0.0f)
            {
                zone = 2;
            }
            else
            {
                zone = 5;
            }
        }
        else if (0.866f <= playerPosition.x && playerPosition.x < 1.0f)
        {
            if (playerPosition.y >= 0.0f)
            {
                zone = 3;
            }
            else
            {
                zone = 4;
            }
        }
    }
}
