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

    void Start()
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
    }

    public int GetPlayerInput()
    {
        return playerIndex;
    }

    public void RunInputUpdate(float xInput)
    {
        /*
        if(xInput > 0)
        {
            xInput = 1.0f;
        }
        else if(xInput < 0)
        {
            xInput = -1.0f;
        }
        */
        if ((xInput > 0 && transform.localScale.x < 0) || (xInput < 0 && transform.localScale.x > 0))
        {
            Flip();
        }

        moveDir = new Vector3(xInput, 0, 0) * 10f;
        targetMoveAmount = moveDir * moveSpeed;
        moveAmount = Vector2.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, 0.15f);
    }

    private void FixedUpdate()
    {
        Vector2 moveAm = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rb.position += moveAm;
    }

    private void Flip()
    {
        float newXScale = transform.localScale.x * -1.0f;
        Vector3 newScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
        transform.localScale = newScale;
    }

    /*
    public void RunInput()
    {
        //turns player around
        if (transform.localScale.x < 0)
        {
            float newXScale = transform.localScale.x * -1.0f;
            Vector3 newScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale;
        }
        Vector2 moveDir = transform.TransformDirection(new Vector2(xInput, 0));
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);


        //tells object what position to move to

        //Vector2 right = transform.TransformDirection(Vector2.right);
        // Move the character by finding the target velocity
        //Vector3 targetVelocity = new Vector2(right.x * (xInput * moveSpeed), right.y * rb.velocity.y);
        // And then smoothing it out and applying it to the character
        //Vector3 targetVelocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        //Vector3 targetVelocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocityZero, movementSmoothing);


        //transform.position += right * Time.deltaTime * moveSpeed;
        //transform.Translate(xInput * Vector2.right * moveSpeed * Time.deltaTime);
        //rb.MovePosition(transform.position + right * (xInput * moveSpeed) * Time.fixedDeltaTime);
        //rb.AddForce(right * (xInput * moveSpeed), ForceMode2D.Force);


        //if (isGrounded)
        {
            //Vector3 right = transform.TransformDirection(Vector2.right);
            //rb.velocity = right * (xInput * moveSpeed);
            //rb.velocity = right * moveSpeed;
        }

        //rb.MovePosition(transform.position + right * moveSpeed * Time.fixedDeltaTime);

        //if (rb.velocity.y <= 3.0f && rb.velocity.y >= -3.0f)
        
        //rb.velocity += new Vector2 (right.x * moveSpeed, rb.velocity.y);
        
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        //sound
        button = 1;
        pTwoSound.AssignClip(button);
        
    }
    */
    /*
    public void RunBackInput()
    {
        //turns player around
        if(transform.localScale.x > 0)
        {
            float newXScale = transform.localScale.x * -1.0f;
            Vector3 newScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
            transform.localScale = newScale;
        }

        //tells object what position to move to
        //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        //if (rb.velocity.y <= 2.0f && rb.velocity.y >= -2.0f)
        //if (isGrounded)
        {
            Vector3 left = transform.TransformDirection(Vector2.left);
            rb.MovePosition(transform.position + left * moveSpeed * Time.fixedDeltaTime);
            //rb.velocity = left * moveSpeed;
        }
        
        //sound
        button = 2;
        pTwoSound.AssignClip(button);
    }
    */
    public void JumpInput()
    {
        pressedTime += Time.deltaTime;
    }

    public void JumpReleaseInput()
    {
        if (!held)
        {
            if (jumped < 2)
            {
                Jump();
            }
        }

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
        Vector2 direction = transform.TransformDirection(new Vector3(1, 5, 0));
        rb.AddForce(direction * impulse, ForceMode2D.Impulse);

        //grounding
        isGrounded = false;
        jumped += 1;

        //sound
        button = 0;
        pTwoSound.AssignClip(button);
    }
}