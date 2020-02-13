using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject countdown;

    private CountdownSystem cdSystem;
    private PlayerOneController pOneController;
    private PlayerTwoController pTwoController;
    
    void Start()
    {
        cdSystem = countdown.GetComponent<CountdownSystem>();

        pOneController = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerOneController>();
        pTwoController = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerTwoController>();

    }
    
    void Update()
    {
        if(cdSystem.timer <= 0.0f)
        {
            pOneController.enabled = false;
            pTwoController.enabled = false;
        }
    }
}
