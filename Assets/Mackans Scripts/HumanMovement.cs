using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference movement, jump, interact, crouch;
    [SerializeField] private float maxMoveSpeed = 4;
    private float moveSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        moveSpeed = maxMoveSpeed;
        
        if (movement.action.IsPressed())
            MoveAction();

        if (jump.action.IsPressed())
            JumpAction();

        CrouchAction();
    }

    private void MoveAction()
    {
        float moveDir = movement.action.ReadValue<Vector2>().x;
        transform.position += new Vector3(
            moveDir * Time.deltaTime * moveSpeed,
            0,
            0);

        Debug.Log("YOU SHOULD MOVE");
    }

    private void JumpAction()
    {
        if (GetComponent<HumanCore>().isGrounded)
        {
            Debug.Log("Can jump");
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                0, 6);
        }
    }

    private void CrouchAction()
    {
        if (crouch.action.WasPressedThisFrame())
        {
            Debug.Log("CROUCH");
            transform.localScale = new Vector3(1, 0.5f, 1);

            transform.localPosition -= new Vector3(
                0, 0.5f, 0);

            moveSpeed /= 2f;
        }

        if (crouch.action.WasReleasedThisFrame())
        {
            Debug.Log("STAND UP");
            transform.localScale = new Vector3(1, 1f, 1);
            
            transform.localPosition += new Vector3(
                0, 0.5f, 0);

            moveSpeed *= 2f;
        }
    }
}
