using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 3f;
    public float jumpForce = 70f;

    PlayerAnimation playerAnim;

    SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            playerAnim.Walk(true);
            sr.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            playerAnim.Walk(true);
            sr.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            playerAnim.Walk(false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(rb.velocity.y) < 0.01f)//проверка стоит ли где то
            {
                rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
