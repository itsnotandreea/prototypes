using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private int index,
                playerTwoIndex;

    private float xInput;
    
    private PlayerInput playerInput;

    private GameObject pOne,
                       pTwo;

    private PlayerOneScript pOneScript;
    private PlayerTwoScript pTwoScript;

    private Controls controlsScript;

    private Vector2 moveInput,
                    cameraInput;

    private Camera cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        playerInput = GetComponent<PlayerInput>();
        index = playerInput.playerIndex;
        
        if (playerInput.devices[0].ToString() == "Mouse:/Mouse")
        {
            index = 0;
        }
        else if (playerInput.devices[0].ToString() == "Keyboard:/Keyboard")
        {
            index = 1;
        }
        else
        {
            index = index % 2;
        }

        pOne = GameObject.FindWithTag("PlayerOne");
        pOneScript = pOne.GetComponent<PlayerOneScript>();
        
        pTwo = GameObject.FindWithTag("PlayerTwo");
        pTwoScript = pTwo.GetComponent<PlayerTwoScript>();

        if (index == 1)
        {
            pTwoScript.gettingInputFromXSources++;
            playerTwoIndex = pTwoScript.gettingInputFromXSources;
        }
    }

    private void Update()
    {
        if (index == 1)
        {
            pTwoScript.RunInputUpdate(xInput, playerTwoIndex);
        }

        if (index == 0)
        {
            pOneScript.MoveCameraInput(cameraInput);
        }
    }

    private void OnNavigateKnotsMouse(InputValue value)
    {
        if (index == 0)
        {
            pOneScript.NavigateKnotsMouseInput(cam.ScreenToWorldPoint(value.Get<Vector2>()));
        }
    }

    private void OnNavigateKnots(InputValue value)
    {
        if (index == 0)
        {
            pOneScript.NavigateKnotsJoystickInput(value.Get<Vector2>());
        }
    }

    private void OnCreateLineButton()
    {
        if (index == 0)
        {
            pOneScript.CreateLineButtonInput();
        }
    }

    private void OnCameraMovement(InputValue value)
    {
        if (index == 0)
        {
            cameraInput = value.Get<Vector2>();
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

    private void OnMoveA()
    {
        if (index == 1)
        {
            xInput = -1.0f;
        }
    }

    private void OnMoveD()
    {
        if (index == 1)
        {
            xInput = 1.0f;
        }
    }

    private void OnMoveARelease()
    {
        if (index == 1)
        {
            xInput = 0.0f;
        }
    }

    private void OnMoveDRelease()
    {
        if (index == 1)
        {
            xInput = 0.0f;
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

    private void OnCancelLayers()
    {
        if (index == 1)
        {
            pTwoScript.CancelLayersInput();
        }
    }

    private void OnCancelLayersRelease()
    {
        if (index == 1)
        {
            pTwoScript.CancelLayersReleaseInput();
        }
    }
}
