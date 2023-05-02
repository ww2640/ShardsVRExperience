using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimController : MonoBehaviour
{
    [SerializeField] InputActionReference gripAxis;
    [SerializeField] InputActionReference triggerAxis;

    Animator m_animator;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gripAxis.action.performed += GripPressed;
        triggerAxis.action.performed += TriggerPressed;
    }

    private void OnDisable()
    {
        gripAxis.action.performed -= GripPressed;
        triggerAxis.action.performed -= TriggerPressed;
    }

    private void TriggerPressed(InputAction.CallbackContext obj)
    {
        m_animator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripPressed(InputAction.CallbackContext obj)
    {
        m_animator.SetFloat("Grip", obj.ReadValue<float>());
    }
}
