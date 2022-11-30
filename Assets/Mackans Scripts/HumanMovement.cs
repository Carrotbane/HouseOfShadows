using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference movement, jump, interact;

    private bool isGrounded = true, hasJumped = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.action.IsPressed())
            MoveAction();

        if (jump.action.WasPressedThisFrame())
        {
            hasJumped = false;
            isGrounded = false;
            JumpAction();
        }
    }

    private void MoveAction()
    {
        float moveDir = movement.action.ReadValue<Vector2>().x;
        transform.position += new Vector3(moveDir, 0, 0) * Time.deltaTime;
    }

    private void JumpAction()
    {
        
    }
}
