using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float speed = 500;
    [SerializeField] Transform paddle;
    [SerializeField] GameObject explosion;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform extraLifePowerup;
    public bool inPlay = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (gameManager.gameOver) { return; }
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
            gameManager.UpdateLives(-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            int randChance = Random.Range(1, 101);
            if (randChance < 20)
            {
                Instantiate(extraLifePowerup, other.transform.position, Quaternion.identity);
            }
            GameObject particleSystemTransform = Instantiate(explosion, other.transform.position, Quaternion.identity);
            Destroy(particleSystemTransform, 2.5f);
            Brick brick = other.gameObject.GetComponent<Brick>();
            gameManager.UpdateScore(brick.points);
            gameManager.UpdateNumberOfBricks();
            //Debug.Log("scor " + brick.points)
            Destroy(other.gameObject);
        }
    }

}
