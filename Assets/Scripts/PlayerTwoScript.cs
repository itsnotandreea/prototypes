using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTwoScript : MonoBehaviour
{
    public int button,
               jumped;

    public float moveSpeed,
                 jumpHeight,
                 fallMultiplier,
                 lowJumpMultiplier,
                 impulse,
                 pressedTime,
                 minimPressedTime,
                 angleFriction;
    
    public GameObject score;

    [SerializeField]
    private int playerIndex = 1;

    private bool isGrounded,
                 held;

    private GameObject line;
   
    private Rigidbody2D rb;

    private PlayerTwoSound pTwoSound;

    private MusicSequence musicSequenceScript;

    private ScoreScript scoreScript;

    private Vector2 moveAmount,
                    smoothMoveVelocity,
                    moveDir,
                    targetMoveAmount;

    private Vector3 bounceDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        pTwoSound = GetComponent<PlayerTwoSound>();

        musicSequenceScript = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSequence>();

        scoreScript = score.GetComponent<ScoreScript>();

        button = 100;
        isGrounded = true;
        held = false;
        pressedTime = 0.0f;
        line = null;

        bounceDirection = new Vector3(1, 5, 0);
    }

    public void RunInputUpdate(float xInput)
    {
        //checks if the player should be flipped to face the right direction
        if ((xInput > 0 && transform.localScale.x < 0) || (xInput < 0 && transform.localScale.x > 0))
        {
            Flip();
        }

        //gets input from PlayerInputHandler from Left Stick X Axis
        moveDir = new Vector3(xInput, 0, 0) * 10f;
        //adds speed
        targetMoveAmount = moveDir * moveSpeed;
        //adds a smoothing effect between the current and desired amount of 'moving' the player wants
        moveAmount = Vector2.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, 0.15f);
    }

    private void FixedUpdate()
    {
        //transforms the direction in the characte's local space
        Vector2 moveAm = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        //adds the distance to the current rigidbody's position
        rb.position += moveAm;
    }

    private void Flip()
    {
        //flips the sprite for when player is going towards the left side/right side
        float newXScale = transform.localScale.x * -1.0f;
        Vector3 newScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
        transform.localScale = newScale;

        //changes bounce direction accroding to the player's facing
        bounceDirection.x *= -1.0f;
    }
    
    public void JumpInput()
    {
        //how long has the player been pressing the jump button
        pressedTime += Time.deltaTime;
    }

    public void JumpReleaseInput()
    {
        //when player releases jump button, if the button wasn't held, calls for jump
        if (!held)
        {
            //checks if the player has jumped already more than twice
            if (jumped < 2)
            {
                Jump();
            }
        }

        //resets pressed time
        pressedTime = 0;
        held = false;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Line")) && isGrounded == false)
        {
            isGrounded = true;
            jumped = 0;
        }

        if ((other.gameObject.tag == "Line") && held == true)
        {
            //line = other;
            if (jumped < 2)
            {
                Bounce();
            }

            isGrounded = true;
            jumped = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Line")) && isGrounded == false)
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            scoreScript.IncreaseScore();
            Destroy(other.gameObject);

            musicSequenceScript.GetCollectable(other.gameObject);
        }
    }

    void Update()
    {
        if (pressedTime != 0)
        {
            pressedTime += Time.deltaTime;

            if (pressedTime > minimPressedTime)
            {
                held = true;
            }
        }
        
        /*
        //make falling quicker
        Vector2 ups = transform.TransformDirection(Vector3.up);

        if (rb.velocity.y < 0)
        {
            rb.velocity += ups * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += ups * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        */
    }
    
    private void Jump()
    {
        //jumps, uses physics engine and adds force in the up direction
        Vector2 up = transform.TransformDirection(Vector2.up);
        rb.AddForce(up * jumpHeight);

        //grounding
        isGrounded = false;
        jumped += 1;

        //sound
        button = 0;
        pTwoSound.AssignClip(button);
    }
    
    private void Bounce()
    {
        //makes player bounce at 78.69 degrees
        Vector3 direction = transform.TransformDirection(bounceDirection);
        rb.AddForce(direction * impulse, ForceMode2D.Impulse);

        //grounding
        isGrounded = false;
        jumped += 1;

        //sound
        button = 0;
        pTwoSound.AssignClip(button);
    }
}