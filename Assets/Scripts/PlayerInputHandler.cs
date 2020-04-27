using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private int index;

    private PlayerInput playerInput;

    private GameObject pOne,
                       pTwo;

    private PlayerOneScript pOneScript;
    private PlayerTwoScript pTwoScript;

    private Controls controlsScript;

    private Vector2 moveInput;

    private float xInput;

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

            controlsScript = new Controls();
            controlsScript.PlayerOne.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
            controlsScript.PlayerOne.Move.canceled += ctx => moveInput = Vector2.zero;
        }
    }

    private void Update()
    {
        if (index == 1)
        {
            xInput = moveInput.x;
            pTwoScript.RunInputUpdate(xInput);
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
    /*
    private void OnRun()
    {
        if (index == 1)
        {
            runningBack = false;
            running = true;
        }
    }

    private void OnRunBack()
    {
        if (index == 1)
        {
            running = false;
            runningBack = true;
        }
    }

    private void OnRunRelease()
    {
        if (index == 1)
        {
            running = false;
        }
    }

    private void OnRunBackRelease()
    {
        if (index == 1)
        {
            runningBack = false;
        }
    }
    */
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
            Debug.Log("Jump");
            pTwoScript.JumpReleaseInput();
        }
    }
    
    private void OnEnable()
    {
        controlsScript.Enable();
    }

    private void OnDisable()
    {
        controlsScript.Disable();
    }
}
