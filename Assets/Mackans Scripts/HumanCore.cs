using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class HumanCore : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;
    
    private List<Collider2D> InColliders = new ();
    private Animator animator;
    private Rigidbody2D rigidBody;
    private HumanMovement humanMovement;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        animator.SetFloat("moveSpeed", rigidBody.velocity.x);
        animator.SetBool("isCrouching", humanMovement.isCrouching);
        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isFalling", 0 < rigidBody.velocity.y);

        spriteRenderer.flipX = rigidBody.velocity.x switch
        {
            > 0 => false,
            < 0 => true,
            _ => spriteRenderer.flipX
        };
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        InColliders.Add(col);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        InColliders.Remove(col);
    }
    
    private void InteractAction()
    {
        foreach (var col in InColliders.Where(col => col.gameObject.CompareTag("Switch")))
        {
            col.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
        }
    }
    
    public void InteractEvent(InputAction.CallbackContext context)
    {
        if (context.action.WasPerformedThisFrame())
            InteractAction();
    }
}
