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

    private void Update()
    {
        var movement = InputManager.instance.playerInputs.Detecting.MoveCharacter.ReadValue<Vector2>();
        if (movement != Vector2.zero)
        {
            
            var movementVector = new Vector3(movement.x, 0, movement.y);
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