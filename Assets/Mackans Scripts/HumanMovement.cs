using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanMovement : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 7f;
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private float accelMod = 4f;
    [SerializeField] private float retardMod = -6f;
    [SerializeField] private float airStrafeModifier = 0.5f;
    private float acceleration, retardation, moveSpeed, moveDirection, moveValue, currentAccel, currentRetard;
    private float xVelocity, yVelocity;
    private bool isJumping, crouchDone;
    private HumanCore humanCore;
    private Rigidbody2D rigidBody;

    public bool isCrouching;

    private void Start()
    {
        humanCore = GetComponent<HumanCore>();
        rigidBody = GetComponent<Rigidbody2D>();
        acceleration = maxMoveSpeed * accelMod;
        retardation = maxMoveSpeed * retardMod;
    }

    // Update is called once per frame. Calls upon the crouch action
    private void Update()
    {
        CrouchAction();
    }

    // The FixedUpdate method is a physics based update, which movement should be part of
    private void FixedUpdate()
    {
        MoveAction();
    }

    //Method which calculates current movement
    private void MoveAction()
    {
        xVelocity = rigidBody.velocity.x;
        yVelocity = rigidBody.velocity.y;

        moveSpeed = Mathf.Abs(xVelocity);
        
        //Changes movement direction if speed is zero, to allow for deacceleration in previous movement
        ChangeMoveDirectionIfStill();

        //Increases or decreases current movement speed based on user input
        bool isInput = !moveValue.Equals(0f);
        currentAccel = humanCore.isGrounded ? acceleration : acceleration * airStrafeModifier;
        currentRetard = humanCore.isGrounded ? retardation : retardation * airStrafeModifier;
        ChangeSpeedInDirection(isInput, moveValue, currentAccel, currentRetard, ref moveSpeed);
        
        //Clamps movespeed in order to not exceed the max speed, or fall below 0
        moveSpeed = Mathf.Clamp(moveSpeed, 0, maxMoveSpeed);

        //Calculates and updates position
        
        rigidBody.velocity = new Vector2(
            moveDirection * moveSpeed, yVelocity);
    }
    
    private void ChangeMoveDirectionIfStill()
    {
        if (moveSpeed.Equals(0f)) 
            moveDirection = moveValue;
    }
    
    private void ChangeSpeedInDirection(bool isInput, float axisValue, float curAccel, float curRetard, ref float speed)
    {
        speed += isInput && moveDirection.Equals(axisValue)
            ? curAccel * Time.fixedDeltaTime
            : curRetard * Time.fixedDeltaTime;
    }

    private void JumpAction()
    {
        if (humanCore.isGrounded)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
            
            rigidBody.velocity = new Vector2(
                xVelocity, jumpForce);
        }
    }

    private void CrouchAction()
    {
        if (isCrouching && !crouchDone)
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            transform.localPosition -= new Vector3(
                0, 0.5f, 0);
            
            maxMoveSpeed /= 2f;
            crouchDone = true;
        }
        
        if (!isCrouching && crouchDone)
        {
            transform.localScale = new Vector3(1, 1f, 1);
            transform.localPosition += new Vector3(
                0, 0.5f, 0);

            maxMoveSpeed *= 2;
            crouchDone = false;
        }
    }

    //Event method for movement input
    public void MoveEvent(InputAction.CallbackContext context)
    {
        //Movement direction is saved at every change in input value...
        //E.g. Is 1 or -1 if moving left or right, and 0 when button is released
        moveValue = context.action.ReadValue<Vector2>().x;
    }

    public void JumpEvent(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
            JumpAction();
    }

    public void CrouchEvent(InputAction.CallbackContext context)
    {
        isCrouching = Mathf.Round(context.action.ReadValue<float>()).Equals(1);
    }
}
