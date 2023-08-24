//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Configures/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""InputActionMap"",
            ""id"": ""3074d659-9f5f-4d64-9d22-b3ce4fc4832d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e8a2c88c-4ddd-4b57-a55a-a4ff7d8e50d9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b465ac2-74ce-4f5f-9cc5-dc860da9f263"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // InputActionMap
        m_InputActionMap = asset.FindActionMap("InputActionMap", throwIfNotFound: true);
        m_InputActionMap_Move = m_InputActionMap.FindAction("Move", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // InputActionMap
    private readonly InputActionMap m_InputActionMap;
    private IInputActionMapActions m_InputActionMapActionsCallbackInterface;
    private readonly InputAction m_InputActionMap_Move;
    public struct InputActionMapActions
    {
        private @PlayerControls m_Wrapper;
        public InputActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InputActionMap_Move;
        public InputActionMap Get() { return m_Wrapper.m_InputActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IInputActionMapActions instance)
        {
            if (m_Wrapper.m_InputActionMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InputActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InputActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InputActionMapActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_InputActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public InputActionMapActions @InputActionMap => new InputActionMapActions(this);
    public interface IInputActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
