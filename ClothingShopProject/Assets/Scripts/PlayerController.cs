using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;

    Vector2 movement;

    void Start()
    {
        
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else { anim.SetBool("isWalking", false); }

        if(movement.x < 0 || movement.y < 0)
        {
            sprite.flipX = true;
        }
        if (movement.x > 0 || movement.y > 0)
        {
            sprite.flipX = false;
        }
    }
 
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
