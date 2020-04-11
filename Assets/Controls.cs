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
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""bda62575-8316-4537-a06f-83e3f84bf3fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""RunBack"",
                    ""type"": ""Button"",
                    ""id"": ""0c0f4787-d151-49cc-ba85-3846113ec2a7"",
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
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""4774366e-ad07-421b-ba7f-923193cccfcf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RunRelease"",
                    ""type"": ""Button"",
                    ""id"": ""925df8f4-95c2-4544-92e5-85408ad72b9d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""RunBackRelease"",
                    ""type"": ""Button"",
                    ""id"": ""f23cc6a3-971a-44d1-bbf5-e9b7830a63f1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
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
                    ""id"": ""27dad142-0457-4951-8929-05fc01740350"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70046daf-9606-4328-b574-bef88dd56098"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunBack"",
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
                    ""id"": ""3b06e4df-01fa-42f2-8256-9339eed6d9e2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35224d93-68df-4ba7-bd08-4f7cd5e23cde"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""add62273-347d-4c12-8dec-71dea4d8806b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunBackRelease"",
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
        m_PlayerOne_Run = m_PlayerOne.FindAction("Run", throwIfNotFound: true);
        m_PlayerOne_RunBack = m_PlayerOne.FindAction("RunBack", throwIfNotFound: true);
        m_PlayerOne_Jump = m_PlayerOne.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOne_JumpRelease = m_PlayerOne.FindAction("JumpRelease", throwIfNotFound: true);
        m_PlayerOne_Slide = m_PlayerOne.FindAction("Slide", throwIfNotFound: true);
        m_PlayerOne_RunRelease = m_PlayerOne.FindAction("RunRelease", throwIfNotFound: true);
        m_PlayerOne_RunBackRelease = m_PlayerOne.FindAction("RunBackRelease", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerOne_Run;
    private readonly InputAction m_PlayerOne_RunBack;
    private readonly InputAction m_PlayerOne_Jump;
    private readonly InputAction m_PlayerOne_JumpRelease;
    private readonly InputAction m_PlayerOne_Slide;
    private readonly InputAction m_PlayerOne_RunRelease;
    private readonly InputAction m_PlayerOne_RunBackRelease;
    public struct PlayerOneActions
    {
        private @Controls m_Wrapper;
        public PlayerOneActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigateKnots => m_Wrapper.m_PlayerOne_NavigateKnots;
        public InputAction @CreateLineButton => m_Wrapper.m_PlayerOne_CreateLineButton;
        public InputAction @Run => m_Wrapper.m_PlayerOne_Run;
        public InputAction @RunBack => m_Wrapper.m_PlayerOne_RunBack;
        public InputAction @Jump => m_Wrapper.m_PlayerOne_Jump;
        public InputAction @JumpRelease => m_Wrapper.m_PlayerOne_JumpRelease;
        public InputAction @Slide => m_Wrapper.m_PlayerOne_Slide;
        public InputAction @RunRelease => m_Wrapper.m_PlayerOne_RunRelease;
        public InputAction @RunBackRelease => m_Wrapper.m_PlayerOne_RunBackRelease;
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
                @Run.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRun;
                @RunBack.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunBack;
                @RunBack.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunBack;
                @RunBack.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunBack;
                @Jump.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJump;
                @JumpRelease.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnJumpRelease;
                @Slide.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnSlide;
                @RunRelease.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunRelease;
                @RunRelease.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunRelease;
                @RunRelease.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunRelease;
                @RunBackRelease.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunBackRelease;
                @RunBackRelease.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunBackRelease;
                @RunBackRelease.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnRunBackRelease;
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
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @RunBack.started += instance.OnRunBack;
                @RunBack.performed += instance.OnRunBack;
                @RunBack.canceled += instance.OnRunBack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @JumpRelease.started += instance.OnJumpRelease;
                @JumpRelease.performed += instance.OnJumpRelease;
                @JumpRelease.canceled += instance.OnJumpRelease;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
                @RunRelease.started += instance.OnRunRelease;
                @RunRelease.performed += instance.OnRunRelease;
                @RunRelease.canceled += instance.OnRunRelease;
                @RunBackRelease.started += instance.OnRunBackRelease;
                @RunBackRelease.performed += instance.OnRunBackRelease;
                @RunBackRelease.canceled += instance.OnRunBackRelease;
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);
    public interface IPlayerOneActions
    {
        void OnNavigateKnots(InputAction.CallbackContext context);
        void OnCreateLineButton(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnRunBack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
        void OnRunRelease(InputAction.CallbackContext context);
        void OnRunBackRelease(InputAction.CallbackContext context);
    }
}
