using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    public float Speed;

    private Rigidbody2D rigidbody;
    Vector2 mousePos;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        mousePos = Input.mousePosition;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mousePos, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Destroy(collision.gameObject);
            
        }
    }


}
