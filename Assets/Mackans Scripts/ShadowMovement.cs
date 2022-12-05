using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 5f;
    [SerializeField] private float accelMod = 2f;
    [SerializeField] private float retardMod = -3f;
    [SerializeField] private float tiltInDegrees = 20f;
    private float moveSpeedX, moveSpeedY, moveDirectionX, moveDirectionY;
    private Vector2 moveVector;

    // The FixedUpdate method is a physics based update, which movement should be part of
    private void FixedUpdate()
    {
        MoveAction();
    }

    //Method which calculates current movement
    private void MoveAction()
    {
        //Changes movement direction if speed is zero, to allow for retardation in previous movement
        ChangeMoveDirectionIfStill(moveSpeedX, ref moveDirectionX, 'x');
        ChangeMoveDirectionIfStill(moveSpeedY, ref moveDirectionY, 'y');

        //Increases or decreases current movement speed based on user input
        bool isXInput = !moveVector.x.Equals(0);
        bool isYInput = !moveVector.y.Equals(0);
        ChangeSpeedInDirection(isXInput, moveDirectionX, 'x', ref moveSpeedX);
        ChangeSpeedInDirection(isYInput, moveDirectionY, 'y', ref moveSpeedY);
        
        //Clamps movespeed in order to not exceed the max speed, or fall below 0
        moveSpeedX = Mathf.Clamp(moveSpeedX, 0, maxMoveSpeed);
        moveSpeedY = Mathf.Clamp(moveSpeedY, 0, maxMoveSpeed);
        
        //Updates rotational tilt to simulate movement on X axis
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 
            tiltInDegrees * (moveSpeedX / maxMoveSpeed) * -moveDirectionX));

        //Calculates and updates position
        transform.position += new Vector3(
            moveDirectionX * moveSpeedX * Time.fixedDeltaTime, 
            moveDirectionY * moveSpeedY * Time.fixedDeltaTime, 0);
    }

    private void ChangeMoveDirectionIfStill(float speed, ref float dir, char axis)
    {
        if (speed.Equals(0f)) 
            dir = axis.Equals('x') ? moveVector.x : moveVector.y;
    }

    private void ChangeSpeedInDirection(bool isInput, float moveDir, char axis, ref float speed)
    {
        float vectorValue = axis.Equals('x') ? moveVector.x : moveVector.y;
        speed += isInput && moveDir.Equals(vectorValue)
            ? maxMoveSpeed * accelMod * Time.fixedDeltaTime
            : maxMoveSpeed * retardMod * Time.fixedDeltaTime;
    }

    //Event method for movement input
    public void MoveEvent(InputAction.CallbackContext context)
    {
        //Movement direction is saved at every change in input value...
        //E.g. Is 1 or -1 if moving left or right, and 0 when button is released
        moveVector = context.action.ReadValue<Vector2>();
    }
}
