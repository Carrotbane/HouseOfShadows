using UnityEngine;

public class HumanCore : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;
    
    private Animator animator;
    private Rigidbody2D rigidBody;
    private HumanMovement humanMovement;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        humanMovement = GetComponent<HumanMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float xVelocity = rigidBody.velocity.x;
        animator.SetFloat("moveSpeed", Mathf.Abs(xVelocity));
        animator.SetBool("isCrouching", humanMovement.isCrouching);
        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isFalling", 0 > rigidBody.velocity.y);

        if (humanMovement.isInput && Mathf.Sign(xVelocity).Equals(humanMovement.moveValue))
        {
            spriteRenderer.flipX = rigidBody.velocity.x switch
            {
                > 0 => false,
                < 0 => true,
                _ => spriteRenderer.flipX
            }; 
        }
        
        Debug.Log(xVelocity);
    }
}
