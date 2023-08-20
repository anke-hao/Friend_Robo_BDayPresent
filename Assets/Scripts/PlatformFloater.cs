using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFloater : MonoBehaviour
{
    public float speed;
    private float currentSpeed;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    float timer;
    int direction = 1;
    bool timerRunning = true;
    float height;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning) {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position; 
        position.y = position.y + Time.deltaTime * currentSpeed * direction;
        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null && player.transform.position.y < rigidbody2D.position.y)
        {
            currentSpeed = 0;
            timerRunning = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        currentSpeed = speed;
        timerRunning = true;
    }
}
