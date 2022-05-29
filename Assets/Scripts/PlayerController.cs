using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float JumpForce;
    public float LiftingForce;
    public static int ManaPoints = 0;
    public GameObject[] LifePointsLabel;


    private bool jumped = true;
    private Rigidbody2D rb;
    private float startingY;
    private int lifePoints = 3;

    private Animator anim;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startingY = transform.position.y + 0.01f;
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (jumped && transform.position.y <= startingY)
        {
            jumped = false;
            anim.SetBool("isJump", false);

        }

        if (Input.GetKey(KeyCode.W))
        {
            if (!jumped)
             {
                rb.velocity = (new Vector2(0f, JumpForce));
                jumped = true;
                anim.SetBool("isJump", true);
            }
        }

        
    }

    private void LostLifeEvent()
    {
        if(lifePoints == 3)
        {
            lifePoints--;
            LifePointsLabel[0].SetActive(false);
        }
        else if(lifePoints == 2)
        {
            lifePoints--;
            LifePointsLabel[1].SetActive(false);
        }
        else
        {
            LifePointsLabel[2].SetActive(false);
            GameHandler.GameOver = true;
        }
    }

    private void GainLifeEvent()
    {
        if (lifePoints == 1)
        {
            lifePoints++;
            LifePointsLabel[1].SetActive(true);
        }
        else if(lifePoints == 2)
        {
            lifePoints++;
            LifePointsLabel[0].SetActive(true);
        }
        else
        {
            ManaPoints++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumped = false;
        }
        if (collision.gameObject.tag == "ManaPotion")
        {
            ManaPoints++;
            Destroy(collision.gameObject, 0);
        }
        if (collision.gameObject.tag == "Trap")
        {

            LostLifeEvent();
            Destroy(collision.gameObject, 0);
        }
        if (collision.gameObject.tag == "LifePoint")
        {

            GainLifeEvent();
            Destroy(collision.gameObject, 0);
        }
    }
}
