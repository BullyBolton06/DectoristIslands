using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class CameraController : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private Camera cam;
    private Transform cameraTransform;

    [SerializeField] private float zoomMin;
    [SerializeField] private float zoomMax;

    [SerializeField]
    private float zoomSpeed = 1;

    private void Start()
    {
        cam = GetComponent<Camera>();
        //this is seemingly breaking rules to do with levels of access.
        InputManager.instance.playerInputs.Detecting.CameraZoom.performed += OnCameraZoomRequested;
      
    }

    private void OnCameraZoomRequested(InputAction.CallbackContext context)
    {
        var zoomValue = context.ReadValue<float>();
        Debug.Log(zoomValue);

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize += zoomValue * zoomSpeed, zoomMin, zoomMax);
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
