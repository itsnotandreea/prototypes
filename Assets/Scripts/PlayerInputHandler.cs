using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private int index;

    private bool running,
                 runningBack;

    private PlayerInput playerInput;

    private GameObject pOne,
                       pTwo;

    private PlayerOneScript pOneScript;
    private PlayerTwoScript pTwoScript;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        index = playerInput.playerIndex;

        pOne = GameObject.FindWithTag("PlayerOne");
        pTwo = GameObject.FindWithTag("PlayerTwo");

        pOneScript = pOne.GetComponent<PlayerOneScript>();
        pTwoScript = pTwo.GetComponent<PlayerTwoScript>();

        running = false;
        runningBack = false;
    }

    private void Update()
    {
        if (running)
        {
            if(runningBack)
            {
                runningBack = false;
            }

            pTwoScript.RunInput();
        }

        if (runningBack)
        {
            if (running)
            {
                running = false;
            }

            pTwoScript.RunBackInput();
        }
        
    }

    private void OnNavigateKnots(InputValue value)
    {
        if (index == 0)
        {
            pOneScript.NavigateKnotsInput(value.Get<Vector2>());
        }
    }

    private void OnCreateLineButton()
    {
        if (index == 0)
        {
            pOneScript.CreateLineButtonInput();
        }
    }

    private void OnRun()
    {
        if (index == 1)
        {
            running = true;
        }
    }

    private void OnRunRelease()
    {
        if (index == 1)
        {
            running = false;
        }
    }

    private void OnRunBack()
    {
        if (index == 1)
        {
            runningBack = true;
        }
    }

    private void OnRunBackRelease()
    {
        if (index == 1)
        {
            runningBack = false;
        }
    }

    private void OnJump()
    {
        if (index == 1)
        {
            pTwoScript.JumpInput();
        }
    }

    private void OnJumpRelease()
    {
        if (index == 1)
        {
            pTwoScript.JumpReleaseInput();
        }
    }

    private void OnSlide()
    {
        if (index == 1)
        {
            pTwoScript.SlideInput();
        }
    }
}
