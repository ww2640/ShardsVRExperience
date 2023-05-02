using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowObject : MonoBehaviour
{
    [SerializeField] InputActionReference showObjectReference;
    [SerializeField] GameObject objectToShow;
    private void OnEnable()
    {
        showObjectReference.action.performed += PerformShowObject;
    }

    private void OnDisable()
    {
        showObjectReference.action.performed -= PerformShowObject;
    }

    private void PerformShowObject(InputAction.CallbackContext obj)
    {
        if(objectToShow) objectToShow.SetActive(!objectToShow.activeSelf);
    }
}
