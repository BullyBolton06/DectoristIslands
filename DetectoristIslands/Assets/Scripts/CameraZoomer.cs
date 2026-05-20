using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class CameraZoomer : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private Camera cam;
    private Transform cameraTransform;

    private void Start()
    {
        cam = GetComponent<Camera>();
        playerInputs = new PlayerInputs();
        playerInputs.Detecting.Enable();
        playerInputs.Detecting.CameraZoom.performed += OnCameraZoomRequested;
        // playerControls 
    }

    private void OnCameraZoomRequested(InputAction.CallbackContext context)
    {
        var zoomValue = context.ReadValue<float>();
        Debug.Log(zoomValue);
        cam.orthographicSize = cam.orthographicSize += zoomValue;
    }

    private void OnCameraZoomCancelled(InputAction.CallbackContext context)
    {
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        playerInputs.Detecting.Disable();
    }
}
