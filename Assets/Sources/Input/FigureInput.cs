// GENERATED AUTOMATICALLY FROM 'Assets/Sources/Input/FigureInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FigureInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FigureInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FigureInput"",
    ""maps"": [
        {
            ""name"": ""Figure"",
            ""id"": ""d5b905a0-d1ae-4668-90ed-1817d7ca16a6"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""731a01e0-a26c-4ed5-8495-663000c972df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""e5364c5b-5355-4963-b503-5a4f62fbafca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HorizontalMove"",
                    ""type"": ""Button"",
                    ""id"": ""85f8df02-32ee-4ca7-aff7-8c645acdc97d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""VerticalMove"",
                    ""type"": ""Button"",
                    ""id"": ""e03b06ac-a9e2-4ce7-b87d-776fa75f037c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d3199d2a-d332-483f-9e4e-6b9e235333ea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ee370bdf-86c8-47b1-b2c4-2f1caa133927"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b819c20d-b8df-49ba-a3ed-e929e948d2dc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4dec52be-ba77-4669-b0a7-095c6887d87f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""13ffcd23-5e92-430e-82be-d4fe21d8653a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""977c7a73-4e28-4832-9ba2-519933105ba4"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""38f515e9-fe08-41d9-9dc1-7afbd62c2f64"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c7cf0dda-247b-4705-b44e-8470dc032839"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f6c2f623-8165-41f3-bb12-178a293878bb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""568a5000-8a74-4d58-a052-fc8479ef5dcd"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""427f3689-e691-46f0-9d5f-c2ce327f824f"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""85a0fc9e-1eb9-41e7-89b6-72df03f0c18c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8c510784-e530-49b5-8a13-7be12ff3183a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""08d76331-3739-4c79-af8b-7fadb13d81ae"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""200e772d-6533-444e-88b0-3a8515276e5e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""134731f6-7705-4b5a-b03c-f72e7d8cea0a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0397116b-8ecc-49dc-b6ee-9b46cb0f3ae1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""63de01b6-cf8f-43ba-8454-c417780e253a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a4cb69dd-072c-4bb7-923f-8ad2f6f26992"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6746fc88-6458-4fec-842d-3b8d3376dc28"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Figure
        m_Figure = asset.FindActionMap("Figure", throwIfNotFound: true);
        m_Figure_Move = m_Figure.FindAction("Move", throwIfNotFound: true);
        m_Figure_Rotate = m_Figure.FindAction("Rotate", throwIfNotFound: true);
        m_Figure_HorizontalMove = m_Figure.FindAction("HorizontalMove", throwIfNotFound: true);
        m_Figure_VerticalMove = m_Figure.FindAction("VerticalMove", throwIfNotFound: true);
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

    // Figure
    private readonly InputActionMap m_Figure;
    private IFigureActions m_FigureActionsCallbackInterface;
    private readonly InputAction m_Figure_Move;
    private readonly InputAction m_Figure_Rotate;
    private readonly InputAction m_Figure_HorizontalMove;
    private readonly InputAction m_Figure_VerticalMove;
    public struct FigureActions
    {
        private @FigureInput m_Wrapper;
        public FigureActions(@FigureInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Figure_Move;
        public InputAction @Rotate => m_Wrapper.m_Figure_Rotate;
        public InputAction @HorizontalMove => m_Wrapper.m_Figure_HorizontalMove;
        public InputAction @VerticalMove => m_Wrapper.m_Figure_VerticalMove;
        public InputActionMap Get() { return m_Wrapper.m_Figure; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FigureActions set) { return set.Get(); }
        public void SetCallbacks(IFigureActions instance)
        {
            if (m_Wrapper.m_FigureActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_FigureActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_FigureActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_FigureActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_FigureActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_FigureActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_FigureActionsCallbackInterface.OnRotate;
                @HorizontalMove.started -= m_Wrapper.m_FigureActionsCallbackInterface.OnHorizontalMove;
                @HorizontalMove.performed -= m_Wrapper.m_FigureActionsCallbackInterface.OnHorizontalMove;
                @HorizontalMove.canceled -= m_Wrapper.m_FigureActionsCallbackInterface.OnHorizontalMove;
                @VerticalMove.started -= m_Wrapper.m_FigureActionsCallbackInterface.OnVerticalMove;
                @VerticalMove.performed -= m_Wrapper.m_FigureActionsCallbackInterface.OnVerticalMove;
                @VerticalMove.canceled -= m_Wrapper.m_FigureActionsCallbackInterface.OnVerticalMove;
            }
            m_Wrapper.m_FigureActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @HorizontalMove.started += instance.OnHorizontalMove;
                @HorizontalMove.performed += instance.OnHorizontalMove;
                @HorizontalMove.canceled += instance.OnHorizontalMove;
                @VerticalMove.started += instance.OnVerticalMove;
                @VerticalMove.performed += instance.OnVerticalMove;
                @VerticalMove.canceled += instance.OnVerticalMove;
            }
        }
    }
    public FigureActions @Figure => new FigureActions(this);
    public interface IFigureActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnHorizontalMove(InputAction.CallbackContext context);
        void OnVerticalMove(InputAction.CallbackContext context);
    }
}
