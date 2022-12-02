using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanMovement : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 4;
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private float acceleration = 16;
    [SerializeField] private float retardation = 16;
    [SerializeField] private float airStrafeModifier = 0.4f;
    private float moveSpeed, moveDirection, currentAccel, currentRetard, moveValue;
    private bool isCrouching, crouchDone;
    private HumanCore humanCore;

    private void Start()
    {
        humanCore = GetComponent<HumanCore>();
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
        bool isInput = !moveValue.Equals(0f);
        
        currentAccel = humanCore.isGrounded ? acceleration : acceleration * airStrafeModifier;
        currentRetard = humanCore.isGrounded ? retardation : retardation * airStrafeModifier;
        
        //Changes movement direction if speed is zero, to allow for deacceleration in previous movement
        if (moveSpeed.Equals(0f)) 
            moveDirection = moveValue;
        
        //Increases or decreases current movement speed based on user input
        if (isInput && moveDirection.Equals(moveValue))
            moveSpeed += currentAccel * Time.fixedDeltaTime;
        else
            moveSpeed -= currentRetard * Time.fixedDeltaTime;
        
        //Clamps movespeed in order to not exceed the max speed, or fall below 0
        moveSpeed = Mathf.Clamp(moveSpeed, 0, maxMoveSpeed);

        //Stores the movement direction of last movement input in order to go to a smooth stop after key release
        
        transform.position += new Vector3(
            moveDirection * moveSpeed * Time.fixedDeltaTime, 0, 0);
    }

    private void JumpAction()
    {
        if (humanCore.isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                0, jumpForce);
        }
    }

    private void CrouchAction()
    {
        if (isCrouching && !crouchDone)
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
            transform.localPosition -= new Vector3(
                0, 0.5f, 0);
            
            moveSpeed = maxMoveSpeed / 2f;
            crouchDone = true;
        }
        
        if (!isCrouching && crouchDone)
        {
            transform.localScale = new Vector3(1, 1f, 1);
            transform.localPosition += new Vector3(
                0, 0.5f, 0);

            moveSpeed = maxMoveSpeed;
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
        {
            Debug.Log("Performed Jump");
        }
        if (context.action.WasPerformedThisFrame())
            JumpAction();
    }

    public void CrouchEvent(InputAction.CallbackContext context)
    {
        isCrouching = Mathf.Round(context.action.ReadValue<float>()).Equals(1);
    }
}
