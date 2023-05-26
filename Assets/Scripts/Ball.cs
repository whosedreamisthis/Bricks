using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 500;
    [SerializeField] Transform paddle;
    public bool inPlay = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.position + transform.up * 0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                inPlay = true;
                rb.AddForce(Vector2.up * speed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
        }
    }

}
