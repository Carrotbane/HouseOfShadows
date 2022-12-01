using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    private float moveDir;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(
            moveDir * Time.deltaTime * moveSpeed,
            0,
            0);
        
    }

    private void MoveAction()
    {
        
    }

    public void MoveEvent(InputAction.CallbackContext context)
    {
        Debug.Log("MOVE SHADOW");
        moveDir = context.action.ReadValue<Vector2>().x;
    }

    private void JumpAction()
    {
        if (GetComponent<ShadowCore>().isGroundedShadow)
        {
            Debug.Log("Can jump");
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                0, 6);
        }
    }

    private void CrouchAction()
    {
        
        Debug.Log("CROUCH");
        transform.localScale = new Vector3(1, 0.5f, 1);

        transform.localPosition -= new Vector3(
            0, 0.5f, 0);

        moveSpeed /= 2f;
    

    
        Debug.Log("STAND UP");
        transform.localScale = new Vector3(1, 1f, 1);
        
        transform.localPosition += new Vector3(
            0, 0.5f, 0);

        moveSpeed *= 2f;
        
    }
}
