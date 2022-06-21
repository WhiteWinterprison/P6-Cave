//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Inputs/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""CAVE"",
            ""id"": ""c6ba5767-0e30-46d3-a6fd-c6aa039aafc3"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""9bb96c6d-bfab-40b7-aee4-3963bb3dd181"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""61caa258-d8fd-4b86-bc9c-8a1e3b65c753"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""VR"",
            ""id"": ""2b98478d-7bd2-4567-ac1a-23fd64f54a32"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""ebd2bbea-dd75-498e-b653-c6371e3e5734"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8dac2722-b54a-47c8-b2c2-8eab59ae15e7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CAVE
        m_CAVE = asset.FindActionMap("CAVE", throwIfNotFound: true);
        m_CAVE_Newaction = m_CAVE.FindAction("New action", throwIfNotFound: true);
        // VR
        m_VR = asset.FindActionMap("VR", throwIfNotFound: true);
        m_VR_Newaction = m_VR.FindAction("New action", throwIfNotFound: true);
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

    // CAVE
    private readonly InputActionMap m_CAVE;
    private ICAVEActions m_CAVEActionsCallbackInterface;
    private readonly InputAction m_CAVE_Newaction;
    public struct CAVEActions
    {
        private @PlayerInputActions m_Wrapper;
        public CAVEActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_CAVE_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_CAVE; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CAVEActions set) { return set.Get(); }
        public void SetCallbacks(ICAVEActions instance)
        {
            if (m_Wrapper.m_CAVEActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_CAVEActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_CAVEActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_CAVEActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_CAVEActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public CAVEActions @CAVE => new CAVEActions(this);

    // VR
    private readonly InputActionMap m_VR;
    private IVRActions m_VRActionsCallbackInterface;
    private readonly InputAction m_VR_Newaction;
    public struct VRActions
    {
        private @PlayerInputActions m_Wrapper;
        public VRActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_VR_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_VR; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VRActions set) { return set.Get(); }
        public void SetCallbacks(IVRActions instance)
        {
            if (m_Wrapper.m_VRActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_VRActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_VRActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_VRActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_VRActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public VRActions @VR => new VRActions(this);
    public interface ICAVEActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IVRActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
