using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float JumpForce;
    public float LiftingForce;

    private bool jumped = true;
    private Rigidbody2D rb;
    private float startingY;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startingY = transform.position.y + 0.01f;

    }

    void Update()
    {
        if (jumped && transform.position.y <= startingY)
        {
            jumped = false;

        }

        if (Input.GetKey(KeyCode.W))
        {
            if (!jumped)
             {
                rb.velocity = (new Vector2(0f, JumpForce));
                jumped = true;
            }
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumped = false;
        }
    }
}
