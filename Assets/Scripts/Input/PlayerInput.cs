// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Terrain"",
            ""id"": ""c75dc0da-a69d-4053-8029-2b2d9bc18afb"",
            ""actions"": [
                {
                    ""name"": ""MouseDown"",
                    ""type"": ""Button"",
                    ""id"": ""6ce9c10d-1884-4523-b401-f560300f5311"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""f5fbc0ed-f690-40a1-9c00-b730f2a66917"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3737b490-8e80-44c8-9a1d-53a44754205e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d8365e8-ee53-4012-a728-19ce9f6999bc"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Terrain
        m_Terrain = asset.FindActionMap("Terrain", throwIfNotFound: true);
        m_Terrain_MouseDown = m_Terrain.FindAction("MouseDown", throwIfNotFound: true);
        m_Terrain_MousePosition = m_Terrain.FindAction("MousePosition", throwIfNotFound: true);
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

    // Terrain
    private readonly InputActionMap m_Terrain;
    private ITerrainActions m_TerrainActionsCallbackInterface;
    private readonly InputAction m_Terrain_MouseDown;
    private readonly InputAction m_Terrain_MousePosition;
    public struct TerrainActions
    {
        private @PlayerInput m_Wrapper;
        public TerrainActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseDown => m_Wrapper.m_Terrain_MouseDown;
        public InputAction @MousePosition => m_Wrapper.m_Terrain_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_Terrain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TerrainActions set) { return set.Get(); }
        public void SetCallbacks(ITerrainActions instance)
        {
            if (m_Wrapper.m_TerrainActionsCallbackInterface != null)
            {
                @MouseDown.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMouseDown;
                @MouseDown.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMouseDown;
                @MouseDown.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMouseDown;
                @MousePosition.started -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_TerrainActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_TerrainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseDown.started += instance.OnMouseDown;
                @MouseDown.performed += instance.OnMouseDown;
                @MouseDown.canceled += instance.OnMouseDown;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public TerrainActions @Terrain => new TerrainActions(this);
    public interface ITerrainActions
    {
        void OnMouseDown(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
