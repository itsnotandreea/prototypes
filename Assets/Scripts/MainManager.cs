using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Text UIWinner;

    public GameObject countdown;

    private CountdownSystem cdSystem;
    private PlayerOneController pOneController;
    private PlayerTwoController pTwoController;
    
    void Start()
    {
        cdSystem = countdown.GetComponent<CountdownSystem>();

        pOneController = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerOneController>();
        pTwoController = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerTwoController>();

        UIWinner.enabled = false;

    }
    
    void Update()
    {
        //quit game in built
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

        if (cdSystem.timer <= 0.0f)
        {
            pOneController.enabled = false;
            pTwoController.enabled = false;
            UIWinner.text = "Player 1 wins!";
            UIWinner.enabled = true;
        }

        if (pTwoController.total >= 24)
        {
            cdSystem.enabled = false;
            pOneController.enabled = false;
            pTwoController.enabled = false;
            UIWinner.text = "Player 2 wins!";
            UIWinner.enabled = true;
        }
    }
}
