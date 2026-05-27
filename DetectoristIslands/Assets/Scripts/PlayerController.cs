using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController movementController;
    [SerializeField] private float playerSpeedMultiplier;
    [SerializeField] private float playerRotateSpeed;
    private Vector3 lastMovementDirection;
    

    public void Start()
    {
        movementController = GetComponent<CharacterController>();
        lastMovementDirection = movementController.transform.forward; // set it to the current transform
    }

    [SerializeField] private float cameraAngleModifier = 22.5f;

    private void Update()
    {
        var movement = InputManager.instance.playerInputs.Detecting.MoveCharacter.ReadValue<Vector2>();
        if (movement != Vector2.zero)
        {
            //we need to take the camera angle into account, where 1,0,0 should actually equal 0.77,0,0.77
            //using quaternions, we can rotate our vector
            var movementVector = new Vector3(movement.x, 0, movement.y);
            
            var rotation = Quaternion.AngleAxis(cameraAngleModifier, Vector3.up);
            
            movementVector = rotation * movementVector;
            lastMovementDirection = movementVector;
            movementController.Move(movementVector * (Time.deltaTime * playerSpeedMultiplier));
        }
        
        TurnToFaceDirection();
       
    }

    private void TurnToFaceDirection()
    {
        //convert lastMovementDirection to an angle
        var targetRotation = Quaternion.LookRotation(lastMovementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * playerRotateSpeed);
    }
}