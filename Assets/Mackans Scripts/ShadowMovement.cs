using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 4f;
    [SerializeField] private float acceleration = 6f;
    [SerializeField] private float retardMod = -1f;
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
        //Changes movement direction if speed is zero, to allow for deacceleration in previous movement
        ChangeMoveDirectionIfStill(moveSpeedX, ref moveDirectionX, moveVector, 'x');
        ChangeMoveDirectionIfStill(moveSpeedY, ref moveDirectionY, moveVector, 'y');

        //Increases or decreases current movement speed based on user input
        bool isXInput = !moveVector.x.Equals(0);
        bool isYInput = !moveVector.y.Equals(0);
        ChangeSpeedInDirection(isXInput, moveDirectionX, moveVector, 'x', ref moveSpeedX);
        ChangeSpeedInDirection(isYInput, moveDirectionY, moveVector, 'y', ref moveSpeedY);
        
        //Clamps movespeed in order to not exceed the max speed, or fall below 0
        moveSpeedX = Mathf.Clamp(moveSpeedX, 0, maxMoveSpeed);
        moveSpeedY = Mathf.Clamp(moveSpeedY, 0, maxMoveSpeed);

        //Stores the movement direction of last movement input in order to go to a smooth stop after key release
        transform.position += new Vector3(
            moveDirectionX * moveSpeedX * Time.fixedDeltaTime, 
            moveDirectionY * moveSpeedY * Time.fixedDeltaTime, 0);
    }

    private void ChangeSpeedInDirection(bool isInput, float moveDir, Vector2 vector, char axis, ref float speed)
    {
        float vectorValue = axis.Equals('x') ? vector.x : vector.y;
        speed += isInput && moveDir.Equals(vectorValue)
            ? acceleration * Time.fixedDeltaTime
            : acceleration * retardMod * Time.fixedDeltaTime;
    }

    private void ChangeMoveDirectionIfStill(float speed, ref float dir, Vector2 vector, char axis)
    {
        if (speed.Equals(0f)) 
            dir = axis.Equals('x') ? vector.x : vector.y;
    }

    //Event method for movement input
    public void MoveEvent(InputAction.CallbackContext context)
    {
        //Movement direction is saved at every change in input value...
        //E.g. Is 1 or -1 if moving left or right, and 0 when button is released
        moveVector = context.action.ReadValue<Vector2>();
    }
}
