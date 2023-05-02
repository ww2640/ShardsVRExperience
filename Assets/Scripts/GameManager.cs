using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] InputActionReference LeftVelocity;
    [SerializeField] InputActionReference RightVelocity;
    [SerializeField] float velocityThreshold = 0.5f;

    private void Update()
    {
        
    }

    public bool TestControllerVelocity()
    {
        if (RightVelocity.action.ReadValue<Vector3>().magnitude > velocityThreshold || LeftVelocity.action.ReadValue<Vector3>().magnitude > velocityThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

