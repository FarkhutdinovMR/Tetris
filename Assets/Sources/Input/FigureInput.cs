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
                    ""name"": ""1D Axis"",
                    ""id"": ""684fcb92-8647-44b4-af80-c44883e1c419"",
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
                    ""id"": ""3f08220e-6131-4088-8af5-d1b9e2a48c84"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4a18defa-aa83-40fc-94a2-2333eec324f5"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
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
    public struct FigureActions
    {
        private @FigureInput m_Wrapper;
        public FigureActions(@FigureInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Figure_Move;
        public InputAction @Rotate => m_Wrapper.m_Figure_Rotate;
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
            }
        }
    }
    public FigureActions @Figure => new FigureActions(this);
    public interface IFigureActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
