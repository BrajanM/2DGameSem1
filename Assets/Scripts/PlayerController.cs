using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float JumpForce;
    public float LiftingForce;
    public static int ManaPoints = 0;
    public GameObject[] LifePointsLabel;
    public GameObject Bow;
    public GameObject ArrowSpawnPoint;
    public GameObject Arrow;
    public int lifePoints = 3;
    public static bool resetLifePoints = false;


    private bool jumped = true;
    private Rigidbody2D rb;
    private float startingY;
    private float canShoot = 0;
    private Animator anim;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startingY = transform.position.y + 0.01f;
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (jumped && transform.position.y - 2 <= startingY)
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

        if (Input.GetKey(KeyCode.Mouse0) && canShoot>=100f)
        {
            ShootArrow();
            canShoot = 0;
        }
        canShoot++;
        RotateBow();

        if (resetLifePoints)
        {
            ResetLifePointsLabel();
            resetLifePoints = false;
        }

    }

    public void ResetLifePointsLabel()
    {
        lifePoints = 3;
        LifePointsLabel[0].SetActive(true);
        LifePointsLabel[1].SetActive(true);
        LifePointsLabel[2].SetActive(true);
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

    private void RotateBow()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Bow.transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Bow.transform.rotation = Quaternion.Slerp(Bow.transform.rotation,rotation,Time.deltaTime*4);

    }

    private void ShootArrow()
    {
        Instantiate(Arrow, new Vector3(ArrowSpawnPoint.transform.position.x, ArrowSpawnPoint.transform.position.y, ArrowSpawnPoint.transform.position.z), ArrowSpawnPoint.transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumped = false;
        }
        if (collision.gameObject.tag == "Platform")
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
