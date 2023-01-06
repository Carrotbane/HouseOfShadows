using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 10f;
    [SerializeField] private float accelMod = 2f;
    [SerializeField] private float retardMod = -2f;
    [SerializeField] private float tiltInDegrees = 20f;
    [SerializeField] private float shadowAttachLength = 2.5f;
    [SerializeField] private float shadowAttachChaseFactor = 1.1f;
    private float moveSpeedX, moveSpeedY, moveDirectionX, moveDirectionY;
    private Rigidbody2D rigidBody;
    private Transform shadowTransform;
    private Transform humanTransform;
    private SpriteRenderer spriteRenderer;
    
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool isXInput, isYInput, isAttached = false;
    
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        shadowTransform = GameObject.Find("Body").transform;
        humanTransform = GameObject.Find("Human").transform;
    }

    // The FixedUpdate method is a physics based update, which movement should be part of
    private void FixedUpdate()
    {
        if (!isAttached)
            MoveAction();
        else
            MoveAttached();
    }

    //Method which calculates current movement
    private void MoveAction()
    {
        //Stores velocity values
        float xVelocity = rigidBody.velocity.x;
        float yVelocity = rigidBody.velocity.y;
        
        //Updates movespeed values according to current speed (may change due to in game collisions)
        moveSpeedX = Mathf.Abs(xVelocity);
        moveSpeedY = Mathf.Abs(yVelocity);
        
        //Changes movement direction if speed is zero, to allow for retardation in previous movement
        ChangeMoveDirectionIfStill(moveSpeedX, ref moveDirectionX, 'x');
        ChangeMoveDirectionIfStill(moveSpeedY, ref moveDirectionY, 'y');
        
        //Increases or decreases current movement speed based on user input
        isXInput = !moveVector.x.Equals(0);
        isYInput = !moveVector.y.Equals(0);
        ChangeSpeedInDirection(isXInput, moveDirectionX, 'x', ref moveSpeedX);
        ChangeSpeedInDirection(isYInput, moveDirectionY, 'y', ref moveSpeedY);
        
        //Clamps movespeed in order to not exceed the max speed, or fall below 0
        moveSpeedX = Mathf.Clamp(moveSpeedX, 0, maxMoveSpeed);
        moveSpeedY = Mathf.Clamp(moveSpeedY, 0, maxMoveSpeed);
        
        //Updates rotational tilt to simulate movement on X axis
        shadowTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 
            tiltInDegrees * (moveSpeedX / maxMoveSpeed) * -moveDirectionX));

        //Updates velocity (live speed)
        rigidBody.velocity = new Vector2(
            moveDirectionX * moveSpeedX, 
            moveDirectionY * moveSpeedY);
    }

    private void MoveAttached()
    {
        Vector2 dVec2 = humanTransform.position - shadowTransform.position;
        float dDist = dVec2.magnitude;
        
        //If shadow is outside of their attachment range, move towards it
        if (dDist >= shadowAttachLength)
        {
            Vector2 vec2Direction = dVec2.normalized;
            float speed = Mathf.Pow(
                dDist - shadowAttachLength * 0.8f,1.5f) * shadowAttachChaseFactor;
            rigidBody.velocity = vec2Direction * speed;
        }
        else
        {
            rigidBody.velocity = new Vector2(0, 0);
        }

        if (!rigidBody.velocity.x.Equals(0))
            spriteRenderer.flipX = Mathf.Sign(rigidBody.velocity.x).Equals(-1);
        
        shadowTransform.rotation = Quaternion.Euler(new Vector3(0, 0, 
            tiltInDegrees / 8 * -rigidBody.velocity.x));
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
