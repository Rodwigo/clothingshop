using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Attributes")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    public bool canMove = true;

    [Header("Menus")]
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    public GameObject menu4;
    public GameObject menu5;
    public GameObject menu6;
    public GameObject menu7;

    Vector2 movement;
    [Header("Debugging")]
    public bool touchSign1;
    public bool touchSign2;
    public bool touchSign3;
    public bool touchHouse;
    public bool touchNPC1;
    public bool touchNPC2;
    public bool touchNPC3;

    void Start()
    {
        canMove = true;
    }

    private void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (touchSign1)
            {
                if(canMove == true)
                {
                    canMove = false;
                    Debug.Log("Sign!");
                    menu1.SetActive(true);
                }
                else
                {
                    canMove = true;
                    menu1.SetActive(false);
                }            
            }
            if (touchSign2)
            {
                Debug.Log("Sign!");

            }
            if (touchSign3)
            {
                Debug.Log("Sign!");

            }
            if (touchHouse)
            {
                Debug.Log("House!");
            }
            if (touchNPC1)
            {
                Debug.Log("Npc!");
            }
            if (touchNPC2)
            {
                Debug.Log("Npc!");
            }
            if (touchNPC3)
            {
                Debug.Log("Npc!");
            }
        }
    }
 
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Movement()
    {
        if (!canMove)
        {
            return;
        }
        else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement.x != 0 || movement.y != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else { anim.SetBool("isWalking", false); }

            if (movement.x < 0 || movement.y < 0)
            {
                sprite.flipX = true;
            }
            if (movement.x > 0 || movement.y > 0)
            {
                sprite.flipX = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Sign1")
        {
            touchSign1 = true;
        }
        if (collision.tag == "Sign2")
        {
            touchSign2 = true;
        }
        if (collision.tag == "Sign3")
        {
            touchSign3 = true;
        }
        if (collision.tag == "House")
        {
            touchHouse = true;
        }
        if(collision.tag == "Npc1")
        {
            touchNPC1 = true;
        }
        if (collision.tag == "Npc2")
        {
            touchNPC2 = true;
        }
        if (collision.tag == "Npc3")
        {
            touchNPC3 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchHouse = false;
        touchNPC1 = false;
        touchNPC2 = false;
        touchNPC3 = false;
        touchSign1 = false;
        touchSign2 = false;
        touchSign3 = false;
    }
}
