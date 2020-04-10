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
                }
            ]
        },
        {
            ""name"": ""PlayerTwo"",
            ""id"": ""493cfb74-1f94-4227-8142-149bee17be41"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""62669853-01c0-4380-9aa7-50db64efa7e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RunBack"",
                    ""type"": ""Button"",
                    ""id"": ""62d104f8-f954-4eac-a6c0-fc1c30b147ed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""617adaac-fe52-4496-b114-8d4791c9234c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpRelease"",
                    ""type"": ""Button"",
                    ""id"": ""9f30df4c-19c6-4f24-9d73-38b5f737215d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""6db0274c-1a20-4e24-9bc9-3fad077cd91d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6e88e419-a67d-4f1e-81c8-c0a3cf0537d4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1edb9a79-54ee-47b5-98ed-c174422e2abb"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunBack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76d2d576-d0a1-4de6-bf18-6909de38194e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef05a667-ce23-41a8-8b1e-d2298641240b"",
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
                    ""id"": ""43b72d78-a911-4cc5-a9a2-88a3fd8f174d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpRelease"",
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
        // PlayerTwo
        m_PlayerTwo = asset.FindActionMap("PlayerTwo", throwIfNotFound: true);
        m_PlayerTwo_Run = m_PlayerTwo.FindAction("Run", throwIfNotFound: true);
        m_PlayerTwo_RunBack = m_PlayerTwo.FindAction("RunBack", throwIfNotFound: true);
        m_PlayerTwo_Jump = m_PlayerTwo.FindAction("Jump", throwIfNotFound: true);
        m_PlayerTwo_JumpRelease = m_PlayerTwo.FindAction("JumpRelease", throwIfNotFound: true);
        m_PlayerTwo_Slide = m_PlayerTwo.FindAction("Slide", throwIfNotFound: true);
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
    public struct PlayerOneActions
    {
        private @Controls m_Wrapper;
        public PlayerOneActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigateKnots => m_Wrapper.m_PlayerOne_NavigateKnots;
        public InputAction @CreateLineButton => m_Wrapper.m_PlayerOne_CreateLineButton;
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
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);

    // PlayerTwo
    private readonly InputActionMap m_PlayerTwo;
    private IPlayerTwoActions m_PlayerTwoActionsCallbackInterface;
    private readonly InputAction m_PlayerTwo_Run;
    private readonly InputAction m_PlayerTwo_RunBack;
    private readonly InputAction m_PlayerTwo_Jump;
    private readonly InputAction m_PlayerTwo_JumpRelease;
    private readonly InputAction m_PlayerTwo_Slide;
    public struct PlayerTwoActions
    {
        private @Controls m_Wrapper;
        public PlayerTwoActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_PlayerTwo_Run;
        public InputAction @RunBack => m_Wrapper.m_PlayerTwo_RunBack;
        public InputAction @Jump => m_Wrapper.m_PlayerTwo_Jump;
        public InputAction @JumpRelease => m_Wrapper.m_PlayerTwo_JumpRelease;
        public InputAction @Slide => m_Wrapper.m_PlayerTwo_Slide;
        public InputActionMap Get() { return m_Wrapper.m_PlayerTwo; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerTwoActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerTwoActions instance)
        {
            if (m_Wrapper.m_PlayerTwoActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRun;
                @RunBack.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRunBack;
                @RunBack.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRunBack;
                @RunBack.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnRunBack;
                @Jump.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJump;
                @JumpRelease.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJumpRelease;
                @JumpRelease.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnJumpRelease;
                @Slide.started -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_PlayerTwoActionsCallbackInterface.OnSlide;
            }
            m_Wrapper.m_PlayerTwoActionsCallbackInterface = instance;
            if (instance != null)
            {
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
            }
        }
    }
    public PlayerTwoActions @PlayerTwo => new PlayerTwoActions(this);
    public interface IPlayerOneActions
    {
        void OnNavigateKnots(InputAction.CallbackContext context);
        void OnCreateLineButton(InputAction.CallbackContext context);
    }
    public interface IPlayerTwoActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnRunBack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
    }
}
