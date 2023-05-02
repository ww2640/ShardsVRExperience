using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    private void Start()
    {

    }
    void Update()
    {
        transform.forward = new Vector3(mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z);
    }
}
