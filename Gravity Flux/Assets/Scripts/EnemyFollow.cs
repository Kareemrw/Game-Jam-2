using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 5f;  
    public float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform roofCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Update()
    {
       
        if (player != null)
        {
            // Calculate direction from enemy to player
            float horizontal = player.position.x - transform.position.x;
            horizontal = Mathf.Sign(horizontal); // Get direction as -1, 0, or 1

            // Jump if the player is above and the enemy is grounded
            if (IsGrounded() && player.position.y > transform.position.y + 1f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
            // Jump down if the player is below and the enemy is touching the roof
            else if (IsTouchingRoof() && player.position.y < transform.position.y - 1f)
            {
                rb.velocity = new Vector2(rb.velocity.x, -jumpingPower);
            }
            // Move enemy towards the player
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
            Flip(horizontal);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsTouchingRoof()
    {
        return Physics2D.OverlapCircle(roofCheck.position, 0.2f, groundLayer);
    }

    private void Flip(float horizontal)
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
