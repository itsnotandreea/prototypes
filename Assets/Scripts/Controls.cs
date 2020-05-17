// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controls.inputactions'

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
                    ""name"": ""NavigateKnotsMouse"",
                    ""type"": ""Value"",
                    ""id"": ""11f8bfb5-69f4-4a9c-bdbb-e045ec5ca23c"",
                    ""expectedControlType"": ""Vector2"",
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
                },
                {
                    ""name"": ""CancelLayers"",
                    ""type"": ""Button"",
                    ""id"": ""9c554529-b31f-4dea-81c9-ddb8186b1801"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CancelLayersRelease"",
                    ""type"": ""Button"",
                    ""id"": ""1a3a4063-5154-471e-8c37-7b9170a7861c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""MoveA"",
                    ""type"": ""Button"",
                    ""id"": ""e35ace46-7c98-4e3d-a9e5-39d2ee253134"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveARelease"",
                    ""type"": ""Button"",
                    ""id"": ""92896173-8a70-40ea-8f50-c87b42bf458f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""MoveD"",
                    ""type"": ""Button"",
                    ""id"": ""57f9ff9e-05bb-4ebf-a921-111bfc123c05"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""MoveDRelease"",
                    ""type"": ""Button"",
                    ""id"": ""eaeb6b21-d092-47cb-b02f-933bc945718f"",
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
                    ""id"": ""6ef4e017-5e1d-4d60-a26b-8a03f3a3f6d3"",
                    ""path"": ""<Mouse>/leftButton"",
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
                    ""id"": ""d08df723-68a7-485a-bacb-70406eb7172f"",
                    ""path"": ""<Keyboard>/space"",
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
                    ""id"": ""9fbced12-2e46-4e9e-8582-66fbe22aef72"",
                    ""path"": ""<Keyboard>/space"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""80b1a2d3-5279-471c-91b2-2b7eaa33d218"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelLayers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""583733c5-1fef-4ad8-b337-9bded945faaf"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelLayers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd88b305-3526-4dc1-b942-48f3985c7ffd"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelLayersRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6977666c-2f53-4189-826b-2a9d51948fb6"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelLayersRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f7c8dde-3abd-4b71-bce4-ba4a2000795f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a03d469-f4c8-4e73-a69f-9780f90aef1a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32b19466-c59a-4925-81e8-e16a1ea6a808"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb00aade-d9bc-4081-89e3-92a44ee9b8aa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a38c606-9abf-4ae8-83f7-c2e0e5615036"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveARelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0af91f8b-b34d-4ca6-98bb-54b9dadb1f07"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveARelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03d22cd9-fb95-4cae-b829-8284523c70d1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f3cb3e8-f080-400c-a584-807173a0b3d5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0eaa419b-53f9-468c-b562-e70e0a5687a2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateKnotsMouse"",
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
        m_PlayerOne_NavigateKnotsMouse = m_PlayerOne.FindAction("NavigateKnotsMouse", throwIfNotFound: true);
        m_PlayerOne_CreateLineButton = m_PlayerOne.FindAction("CreateLineButton", throwIfNotFound: true);
        m_PlayerOne_Jump = m_PlayerOne.FindAction("Jump", throwIfNotFound: true);
        m_PlayerOne_JumpRelease = m_PlayerOne.FindAction("JumpRelease", throwIfNotFound: true);
        m_PlayerOne_Move = m_PlayerOne.FindAction("Move", throwIfNotFound: true);
        m_PlayerOne_CameraMovement = m_PlayerOne.FindAction("CameraMovement", throwIfNotFound: true);
        m_PlayerOne_CancelLayers = m_PlayerOne.FindAction("CancelLayers", throwIfNotFound: true);
        m_PlayerOne_CancelLayersRelease = m_PlayerOne.FindAction("CancelLayersRelease", throwIfNotFound: true);
        m_PlayerOne_MoveA = m_PlayerOne.FindAction("MoveA", throwIfNotFound: true);
        m_PlayerOne_MoveARelease = m_PlayerOne.FindAction("MoveARelease", throwIfNotFound: true);
        m_PlayerOne_MoveD = m_PlayerOne.FindAction("MoveD", throwIfNotFound: true);
        m_PlayerOne_MoveDRelease = m_PlayerOne.FindAction("MoveDRelease", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerOne_NavigateKnotsMouse;
    private readonly InputAction m_PlayerOne_CreateLineButton;
    private readonly InputAction m_PlayerOne_Jump;
    private readonly InputAction m_PlayerOne_JumpRelease;
    private readonly InputAction m_PlayerOne_Move;
    private readonly InputAction m_PlayerOne_CameraMovement;
    private readonly InputAction m_PlayerOne_CancelLayers;
    private readonly InputAction m_PlayerOne_CancelLayersRelease;
    private readonly InputAction m_PlayerOne_MoveA;
    private readonly InputAction m_PlayerOne_MoveARelease;
    private readonly InputAction m_PlayerOne_MoveD;
    private readonly InputAction m_PlayerOne_MoveDRelease;
    public struct PlayerOneActions
    {
        private @Controls m_Wrapper;
        public PlayerOneActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavigateKnots => m_Wrapper.m_PlayerOne_NavigateKnots;
        public InputAction @NavigateKnotsMouse => m_Wrapper.m_PlayerOne_NavigateKnotsMouse;
        public InputAction @CreateLineButton => m_Wrapper.m_PlayerOne_CreateLineButton;
        public InputAction @Jump => m_Wrapper.m_PlayerOne_Jump;
        public InputAction @JumpRelease => m_Wrapper.m_PlayerOne_JumpRelease;
        public InputAction @Move => m_Wrapper.m_PlayerOne_Move;
        public InputAction @CameraMovement => m_Wrapper.m_PlayerOne_CameraMovement;
        public InputAction @CancelLayers => m_Wrapper.m_PlayerOne_CancelLayers;
        public InputAction @CancelLayersRelease => m_Wrapper.m_PlayerOne_CancelLayersRelease;
        public InputAction @MoveA => m_Wrapper.m_PlayerOne_MoveA;
        public InputAction @MoveARelease => m_Wrapper.m_PlayerOne_MoveARelease;
        public InputAction @MoveD => m_Wrapper.m_PlayerOne_MoveD;
        public InputAction @MoveDRelease => m_Wrapper.m_PlayerOne_MoveDRelease;
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
                @NavigateKnotsMouse.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnNavigateKnotsMouse;
                @NavigateKnotsMouse.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnNavigateKnotsMouse;
                @NavigateKnotsMouse.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnNavigateKnotsMouse;
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
                @CancelLayers.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCancelLayers;
                @CancelLayers.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCancelLayers;
                @CancelLayers.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCancelLayers;
                @CancelLayersRelease.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCancelLayersRelease;
                @CancelLayersRelease.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCancelLayersRelease;
                @CancelLayersRelease.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnCancelLayersRelease;
                @MoveA.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveA;
                @MoveA.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveA;
                @MoveA.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveA;
                @MoveARelease.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveARelease;
                @MoveARelease.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveARelease;
                @MoveARelease.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveARelease;
                @MoveD.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveD;
                @MoveD.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveD;
                @MoveD.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveD;
                @MoveDRelease.started -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveDRelease;
                @MoveDRelease.performed -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveDRelease;
                @MoveDRelease.canceled -= m_Wrapper.m_PlayerOneActionsCallbackInterface.OnMoveDRelease;
            }
            m_Wrapper.m_PlayerOneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavigateKnots.started += instance.OnNavigateKnots;
                @NavigateKnots.performed += instance.OnNavigateKnots;
                @NavigateKnots.canceled += instance.OnNavigateKnots;
                @NavigateKnotsMouse.started += instance.OnNavigateKnotsMouse;
                @NavigateKnotsMouse.performed += instance.OnNavigateKnotsMouse;
                @NavigateKnotsMouse.canceled += instance.OnNavigateKnotsMouse;
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
                @CancelLayers.started += instance.OnCancelLayers;
                @CancelLayers.performed += instance.OnCancelLayers;
                @CancelLayers.canceled += instance.OnCancelLayers;
                @CancelLayersRelease.started += instance.OnCancelLayersRelease;
                @CancelLayersRelease.performed += instance.OnCancelLayersRelease;
                @CancelLayersRelease.canceled += instance.OnCancelLayersRelease;
                @MoveA.started += instance.OnMoveA;
                @MoveA.performed += instance.OnMoveA;
                @MoveA.canceled += instance.OnMoveA;
                @MoveARelease.started += instance.OnMoveARelease;
                @MoveARelease.performed += instance.OnMoveARelease;
                @MoveARelease.canceled += instance.OnMoveARelease;
                @MoveD.started += instance.OnMoveD;
                @MoveD.performed += instance.OnMoveD;
                @MoveD.canceled += instance.OnMoveD;
                @MoveDRelease.started += instance.OnMoveDRelease;
                @MoveDRelease.performed += instance.OnMoveDRelease;
                @MoveDRelease.canceled += instance.OnMoveDRelease;
            }
        }
    }
    public PlayerOneActions @PlayerOne => new PlayerOneActions(this);
    public interface IPlayerOneActions
    {
        void OnNavigateKnots(InputAction.CallbackContext context);
        void OnNavigateKnotsMouse(InputAction.CallbackContext context);
        void OnCreateLineButton(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnJumpRelease(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCameraMovement(InputAction.CallbackContext context);
        void OnCancelLayers(InputAction.CallbackContext context);
        void OnCancelLayersRelease(InputAction.CallbackContext context);
        void OnMoveA(InputAction.CallbackContext context);
        void OnMoveARelease(InputAction.CallbackContext context);
        void OnMoveD(InputAction.CallbackContext context);
        void OnMoveDRelease(InputAction.CallbackContext context);
    }
}
