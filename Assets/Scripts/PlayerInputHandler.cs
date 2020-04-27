using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private int index;

    private float xInput;

    private PlayerInput playerInput;

    private GameObject pOne,
                       pTwo;

    private PlayerOneScript pOneScript;
    private PlayerTwoScript pTwoScript;

    private Controls controlsScript;

    private Vector2 moveInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        index = playerInput.playerIndex;
        
        if (index == 0)
        {
            pOne = GameObject.FindWithTag("PlayerOne");
            pOneScript = pOne.GetComponent<PlayerOneScript>();
        }

        if (index == 1)
        {
            pTwo = GameObject.FindWithTag("PlayerTwo");
            pTwoScript = pTwo.GetComponent<PlayerTwoScript>();
        }
    }

    private void Update()
    {
        if (index == 1)
        {
            pTwoScript.RunInputUpdate(xInput);
        }
    }

    private void OnMove(InputValue value)
    {
        if (index == 1)
        {
            xInput = value.Get<Vector2>().x;

            if (xInput > 0)
            {
                xInput = 1.0f;
            }
            if (xInput < 0)
            {
                xInput = -1.0f;
            }
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
}
