using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAway : MonoBehaviour
{
    public float speed;
    public float time = 10.0f;
    int direction = 1;
    // Rigidbody2D rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        // rigidbody2D = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        // Vector2 position = rigidbody2D.position;
        // print(position);
        // position.x = position.y + Time.deltaTime * speed * direction;
        // position.y = position.y + Time.deltaTime * speed * direction;
        // rigidbody2D.MovePosition(position);
        StartCoroutine(Wait());
        
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(1);
        Vector2 position = transform.position;
        print(position);
        position.x = position.x + Time.deltaTime * speed * direction;
        position.y = position.y + Time.deltaTime * speed * direction;
        transform.position = position;
    }
    
}
