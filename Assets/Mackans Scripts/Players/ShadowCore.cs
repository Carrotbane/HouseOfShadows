using UnityEngine;

public class ShadowCore : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private ShadowMovement shadowMovement;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        shadowMovement = GetComponent<ShadowMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float xVelocity = rigidBody.velocity.x;
        animator.SetFloat("moveSpeedX", Mathf.Abs(xVelocity));

        if (shadowMovement.isXInput && Mathf.Sign(xVelocity).Equals(shadowMovement.moveVector.x))
        {
            spriteRenderer.flipX = rigidBody.velocity.x switch
            {
                > 0 => false,
                < 0 => true,
                _ => spriteRenderer.flipX
            }; 
        }
    }
}
