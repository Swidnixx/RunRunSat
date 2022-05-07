using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float liftingForce;

    public LayerMask groundLayer;

    private bool jumped;
    private bool doubleJumped;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if( Input.GetMouseButtonDown(0) && ( IsGrounded() || !doubleJumped ) )
        {
            if ( !jumped )
            {
                // pierwszy skok
                rb.velocity = Vector2.up * jumpForce;
                jumped = true; 
            }
            else if( !doubleJumped )
            {
                // drugi skok
                rb.velocity = Vector2.up * jumpForce;
                doubleJumped = true;
            }
        }
        if( Input.GetMouseButton(0) && rb.velocity.y < 0)
        {
            rb.AddForce(Vector2.up * Time.deltaTime * liftingForce * -rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle") && !GameManager.instance.immortality.isActive )
        {
            GameManager.instance.GameOver();
        }
        else if(collision.CompareTag("Coin"))
        {
            GameManager.instance.CoinCollected();
            // do zrobienia: animacja znikania (za pomoc¹ prefaba)
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Battery"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.BatteryCollected();
        }
        else if(collision.CompareTag("Magnet"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.MagnetCollected();
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            Vector2.down,
            0.1f,
            groundLayer
            ); 

        if(hit.collider != null)
        {
            jumped = false;
            doubleJumped = false;
            return true;
        }
        return false;
    }
}
