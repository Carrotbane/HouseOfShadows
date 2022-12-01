using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanMovement : MonoBehaviour
{
    [SerializeField] private float maxMoveSpeed = 4;
    private float moveSpeed;
    private float moveDir;
    private bool isCrouching, crouchDone = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        MoveAction();

        CrouchAction();

        InteractAction();
    }

    private void MoveAction()
    {
        moveSpeed = maxMoveSpeed;
        transform.position += new Vector3(
            moveDir * Time.deltaTime * moveSpeed,
            0,
            0);
    }

    public void MoveEvent(InputAction.CallbackContext context)
    {
        Debug.Log("MOVE HUMAN");
        moveDir = context.action.ReadValue<Vector2>().x;
    }

    private void JumpAction()
    {
        if (GetComponent<HumanCore>().isGrounded)
        {
            Debug.Log("JUMPING AMOGNSU");
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                0, 6);
        }
    }

    public void JumpEvent(InputAction.CallbackContext context)
    {
        
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

    public void CrouchEvent(InputAction.CallbackContext context)
    {
        isCrouching = Mathf.Round(context.action.ReadValue<float>()).Equals(1);
        
        
        //isCrouching = context.action.ReadValue<float>();
        Debug.Log(context.action.ReadValue<float>());
    }
    
    private void InteractAction()
    {
        
    }
    
    public void InteractEvent(InputAction.CallbackContext context) {}
}
