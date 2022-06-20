using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public float Speed;

    private Rigidbody2D rigidbody;
    Vector2 mousePos;
    Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mousePos, Speed * Time.deltaTime);
        if (transform.position.x == mousePos.x)
        {
            if (transform.position.y == mousePos.y)
            {

                extrapolateTargetPosition();

            }
        }
    }

    private void extrapolateTargetPosition()
    {
        float offsetY = Mathf.Abs(mousePos.y - initialPosition.y);
        float offsetX = Mathf.Abs(mousePos.x - initialPosition.x);

        if (mousePos.y <= 0)
        {
            mousePos.x += offsetX;
            mousePos.y -= offsetY;
        }
        else
        {
            mousePos.x += offsetX;
            mousePos.y += offsetY;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }


}
