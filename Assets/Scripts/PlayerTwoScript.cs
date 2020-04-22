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
                 angleFriction,
                 slideSpeed;

    public GameObject score;

    [SerializeField]
    private int playerIndex = 1;

    private bool isGrounded,
                 held,
                 thereIsSlope;

    private GameObject line;

    private Vector2 slideAngle;
   
    private Rigidbody2D rb;

    private PlayerTwoSound pTwoSound;

    private MusicSequence musicSequenceScript;

    private ScoreScript scoreScript;
    
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
        thereIsSlope = false;
        line = null;
    }

    public int GetPlayerInput()
    {
        return playerIndex;
    }

    public void RunInput()
    {
        //tells object what position to move to
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        Vector2 right = transform.TransformDirection(Vector2.right);
        rb.velocity = right * moveSpeed;

        //sound
        button = 1;
        pTwoSound.AssignClip(button);
    }

    public void RunBackInput()
    {
        //tells object what position to move to
        //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        
        Vector2 left = transform.TransformDirection(Vector2.left);
        rb.velocity = left * moveSpeed;

        //sound
        button = 2;
        pTwoSound.AssignClip(button);
    }

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

    public void SlideInput()
    {
        //slide
        if (thereIsSlope)
        {
            //slideAngle = transform.position - (line.transform.parent.transform.position - line.transform.position);
            slideAngle = (line.transform.parent.transform.position - line.transform.position);
            rb.AddForce (slideAngle * slideSpeed);

            /*
            Vector2 up = transform.TransformDirection(Vector2.up);
            slideAngle += up;
            */

            Debug.DrawLine(line.transform.parent.transform.position, line.transform.position, Color.black);

            Debug.Log("SLIDING");
            StartCoroutine(StopSliding(1.0f));
        }

        //sound
        button = 3;
        pTwoSound.AssignClip(button);
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

        if (other.gameObject.tag == "Line")
        {
            //how the fuck do you get that angle? - find the angle between the line and player 2.right
            float angle = Vector2.SignedAngle(transform.TransformDirection(Vector3.right), other.transform.TransformDirection(Vector3.right));

            if (angle > 25.0f || angle < 90.0f || angle > -155.0f || angle < -90.0f)
            {
                thereIsSlope = true;
                line = other.gameObject;
            }
            else
            {
                thereIsSlope = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Line")) && isGrounded == false)
        {
            isGrounded = false;
        }

        if (other.gameObject.tag == "Line")
        {
            thereIsSlope = false;
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

        //TakeInput();

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
        rb.velocity = up * jumpHeight;

        //rb.AddForce(up * jumpHeight);

        //grounding
        isGrounded = false;
        jumped += 1;

        //sound
        button = 0;
        pTwoSound.AssignClip(button);
    }


    private void Bounce()
    {
        //makes player jump at the angle resulted in the difference between the position of the player and the point in which the player collided with the line
        /*
        ContactPoint2D cPoint = line.contacts[0];

        Vector2 direction = new Vector(cPoint.point.x, cPoint.point.y, transform.position.z) - transform.position;
        direction = -direction.normalized;
        */

        //makes player bounce at 45 degrees
        //Vector2 direction = transform.TransformDirection(Vector3.right) + transform.TransformDirection(Vector3.up);

        //makes player bounce at 78.69 degrees
        Vector2 direction = transform.TransformDirection(new Vector3(1, 5, 0));
        rb.AddForce(direction * impulse);
        //rb.velocity = direction * impulse;
        Debug.Log("BOUNCE");

        //grounding
        isGrounded = false;
        jumped += 1;
        //line = null;

        //sound
        button = 0;
        pTwoSound.AssignClip(button);
    }

    IEnumerator StopSliding(float time)
    {
        yield return new WaitForSeconds(time);
    }
    /*
    void NormaliseSlope()
    {
        if (isGrounded)           //checks if the player is grounded
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 6f, whatIsGround);           //accesses info about the object that has been hit

            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.001f)
            {
                Vector2 up = transform.TransformDirection(Vector2.up);
                Vector2 right = transform.TransformDirection(Vector2.right);

                Vector2 hitUp = hit.transform.TransformDirection(Vector2.up);
                Vector2 hitRight = hit.transform.TransformDirection(Vector2.right);

                //rb.velocity = up * jumpHeight;

                //applies the opposite force against the slope force
                rb.velocity = new Vector2(right.x - (hitRight.x * angleFriction), up.y);
                //rb.velocity = new Vector2(rb.velocity.x - (hit.normal.x * angleFriction), rb.velocity.y);

                //moves Lamplighter up or down to compensate for the slope below them
                Vector2 pos = transform.position;
                pos.y += -hit.normal.x * Mathf.Abs(right.x) * Time.deltaTime * (right.x - hit.normal.x > 0 ? 1 : -1);
                transform.position = pos;
            }
        }
    }
    */
}