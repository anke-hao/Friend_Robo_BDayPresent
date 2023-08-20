using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private CircleCollider2D circleCollider2D;
    // private CapsuleCollider2D capsuleCollider2D;
    [SerializeField] private LayerMask groundLayer;
    [Range(0, 10f)] [SerializeField] private float speed = 0f;
 
    float horizontal = 0f;
    float lastJumpY = 0;

    private bool isFacingRight = true, jump = false;

    public AudioClip footsteps;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        if(isOnGround() && horizontal.Equals(0))
            GetComponent<Animator>().Play("pidle");
        else if(isOnGround() && (horizontal > 0 || horizontal < 0)) 
            GetComponent<Animator>().Play("pright");
        
        if (isOnGround() && Input.GetButtonDown("Jump")) { 
            // GetComponent<Animator>().Play("pjump");
            jump = true;
        }
        
        if (!isOnGround())
        {
            print("lastJumpY is " + lastJumpY);
            print("transform.position.y is " + transform.position.y);
            if (lastJumpY < transform.position.y)
            {
                lastJumpY = transform.position.y;
                print("jumping");
                GetComponent<Animator>().Play("pjump");
            } else {
                GetComponent<Animator>().Play("pfall");
            }
        }
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    

    void FixedUpdate()
    {
        float moveFactor = horizontal * Time.fixedDeltaTime;

        // Movement...
        rigidBody2D.velocity = new Vector2(moveFactor * 10f, rigidBody2D.velocity.y);
        if (moveFactor > 0 && !isFacingRight)    flipSprite();
        else if(moveFactor < 0 && isFacingRight) flipSprite();
        if (jump)
        {
            float jumpvel = 2f;
            rigidBody2D.velocity = Vector2.up * jumpvel;
            jump = false;
        }

        if(!Mathf.Approximately(rigidBody2D.velocity.x, 0.0f) && Mathf.Approximately(rigidBody2D.velocity.y, 0.0f))
        {
            if (!audioSource.isPlaying)
                PlaySound(footsteps);
        }
    }

    private void flipSprite()
    {
        isFacingRight = !isFacingRight;
 
        Vector3 transformScale = transform.localScale;
        transformScale.x *= -1;
        transform.localScale = transformScale;
    }
    private bool isOnGround()
    {
        // print(capsuleCollider2D.size.y);
        RaycastHit2D hit = Physics2D.CircleCast(circleCollider2D.bounds.center, circleCollider2D.radius, Vector2.down, 0.1f, groundLayer);
        if (hit && !lastJumpY.Equals(0)) lastJumpY = 0;
        return hit.collider != null;
    }
}