// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerOne"",
            ""id"": ""8a1a0536-d190-449d-a4fe-527c14cd488d"",
            ""actions"": [
                {
                    ""name"": ""NavigateKnots"",
                    ""type"": ""Value"",
                    ""id"": ""5035062c-45a4-4776-925e-e75ddbd209dd"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CreateLineButton"",
                    ""type"": ""Button"",
                    ""id"": ""3776b342-52ab-4c77-a349-21992fc2a00e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""731d0a9d-689e-4a81-9635-bcb9226779bf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""JumpRelease"",
                    ""type"": ""Button"",
                    ""id"": ""acae2307-8364-46ea-8196-6d4a40e0eaf1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b61307fe-ce26-4e8d-a087-79ae7bde6d9a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""79e17940-d0f4-4071-81e3-8318e5777ab0"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""adcfa659-68a5-4d30-ba4d-e214f58f816e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateKnots"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f59dfe8-52de-4dd8-805d-728f73dc1049"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CreateLineButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81821cfc-1e8a-4e0a-a4a5-4ed78e57a6f5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""236c7517-43de-4f0c-a045-eb2b2b764554"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fadc2ac-6474-4e86-ae2e-25d80b352842"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9e242e4-c020-4490-a154-f0a66b29d012"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33ad6690-2544-40c3-9724-b0470894eed6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerOne
        m_PlayerOne = asset.FindActionMap("PlayerOne", throwIfNotFound: true);
        m_PlayerOne_NavigateKnots = m_PlayerOne.FindAction("NavigateKnots", throwIfNotFound: true);
        m_PlayerOne_CreateLineButton = m_PlayerOne.FindAction("CreateLineButton", throwIfNotFound: true);
        m_PlayerOne_Jump = m_PlayerOne.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOne_JumpRelease = m_PlayerOne.FindAction("JumpRelease", throwIfNotFound: true);
        m_PlayerOne_Move = m_PlayerOne.FindAction("Move", throwIfNotFound: true);
        m_PlayerOne_CameraMovement = m_PlayerOne.FindAction("CameraMovement", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerOne
    private readonly InputActionMap m_PlayerOne;
    private IPlayerOneActions m_PlayerOneActionsCallbackInterface;
    private readonly InputAction m_PlayerOne_NavigateKnots;
    private readonly InputAction m_PlayerOne_CreateLineButton;
    private readonly InputAction m_PlayerOne_Jump;
    private readonly InputAction m_PlayerOne_JumpRelease;
    private readonly InputAction m_PlayerOne_Move;
    private readonly InputAction m_PlayerOne_CameraMovement;
    public struct PlayerOneActions
    {
        private @Controls m_Wrapper;
        public PlayerOneActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigateKnots => m_Wrapper.m_PlayerOne_NavigateKnots;
        public InputAction @CreateLineButton => m_Wrapper.m_PlayerOne_CreateLineButton;
        public InputAction @Jump => m_Wrapper.m_PlayerOne_Jump;
        public InputAction @JumpRelease => m_Wrapper.m_PlayerOne_JumpRelease;
        public InputAction @Move => m_Wrapper.m_PlayerOne_Move;
        public InputAction @CameraMovement => m_Wrapper.m_PlayerOne_CameraMovement;
        public InputActionMap Get() { return m_Wrapper.m_PlayerOne; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerOneActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerOneActions instance)
        {
            if (m_Wrapper.m_PlayerOneActionsCallbackInterface != null)
            {
                @NavigateKnots.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnNavigateKnots;
                @NavigateKnots.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnNavigateKnots;
                @NavigateKnots.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnNavigateKnots;
                @CreateLineButton.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCreateLineButton;
                @CreateLineButton.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCreateLineButton;
                @CreateLineButton.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCreateLineButton;
                @Jump.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @JumpRelease.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJumpRelease;
                @Move.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMove;
                @CameraMovement.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCameraMovement;
                @CameraMovement.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCameraMovement;
            }
            m_Wrapper.m_PlayerOneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavigateKnots.started += instance.OnNavigateKnots;
                @NavigateKnots.performed += instance.OnNavigateKnots;
                @NavigateKnots.canceled += instance.OnNavigateKnots;
                @CreateLineButton.started += instance.OnCreateLineButton;
                @CreateLineButton.performed += instance.OnCreateLineButton;
                @CreateLineButton.canceled += instance.OnCreateLineButton;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @JumpRelease.started += instance.OnJumpRelease;
                @JumpRelease.performed += instance.OnJumpRelease;
                @JumpRelease.canceled += instance.OnJumpRelease;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CameraMovement.started += instance.OnCameraMovement;
                @CameraMovement.performed += instance.OnCameraMovement;
                @CameraMovement.canceled += instance.OnCameraMovement;
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);
    public interface IPlayerOneActions
    {
        void OnNavigateKnots(InputAction.CallbackContext context);
        void OnCreateLineButton(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
    }
}
