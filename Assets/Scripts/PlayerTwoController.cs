using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public int button,
               key,
               round,
               jumped;

    public float moveSpeed,  //the speed
                 jumpHeight,
                 dashSpeed,
                 originalSpeed,
                 breakSpeed,
                 moreWeight,
                 fallMultiplier,
                 lowJumpMultiplier;

    public bool isMajor;

    private bool isGrounded,
                 onceA,
                 onceX;

    private Rigidbody2D rb;  //the rigidbody of the player

    private PlayerTwoSound pTwoSound;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pTwoSound = GetComponent<PlayerTwoSound>();

        isGrounded = true;
        moveSpeed = originalSpeed;
        key = 1;
        isMajor = true;
        button = 0;
        onceA = false;
        onceX = false;
        round = 1;
        jumped = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Round"))
        {
            round += 1;
        }
        if (other.CompareTag("JumpingBot"))
        {
            Debug.Log("Fire");
            StartCoroutine(other.GetComponent<JumpingBotScript>().Fire());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Obstacle")) && isGrounded == false)
        {
            isGrounded = true;
            jumped = 0;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    void FixedUpdate()
    {
        //tells object what position to move to
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

        TakeInput();


        //make falling quicker
        Vector2 ups = transform.TransformDirection(Vector3.up);

        if (rb.velocity.y < 0)
        {
            rb.velocity += ups * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey("joystick 2 button 3"))
        {
            rb.velocity += ups * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void TakeInput()
    {
        if (Input.GetAxisRaw("MajorTwo") != 0)
        {
            key = 1;
        }
        else if (Input.GetAxisRaw("MinorTwo") != 0)
        {
            key = 2;
        }
        
        if (Input.GetKey("joystick 2 button 0"))
        {
            //duck
            Vector3 down = transform.TransformDirection(Vector3.down);
            rb.AddForce(down * moreWeight, ForceMode2D.Impulse);
            if(!onceA)
            {
                onceA = true;
                button = 1;
                pTwoSound.AssignClip(key, button);
            }
            button = 0;
        }
        else if (Input.GetKeyDown("joystick 2 button 1"))
        {
            //dash
            moveSpeed = originalSpeed + dashSpeed;
            StartCoroutine(Wait(0.3f));

            button = 2;
            pTwoSound.AssignClip(key, button);
            button = 0;
        }
        else if (Input.GetKeyDown("joystick 2 button 2"))
        {
            /*
            moveSpeed -= Time.deltaTime * 40.0f;

            if(!onceX)
            {
                onceX = true;
                button = 3;
                pTwoSound.AssignClip(key, button);
            }
            button = 0;
            */

            //back dash

            moveSpeed = 0.0f - dashSpeed;
            StartCoroutine(Wait(0.3f));

            button = 3;
            pTwoSound.AssignClip(key, button);
            button = 0;
        }
        else if (Input.GetKeyDown("joystick 2 button 3") && (jumped < 2))
        {
            //jumps, uses physics engine and adds force in the up direction
            Vector3 up = transform.TransformDirection(Vector3.up);
            //rb.AddForce(up * jumpHeight, ForceMode2D.Impulse);
            rb.velocity = up * jumpHeight;
            isGrounded = false;
            jumped += 1;

            button = 4;
            pTwoSound.AssignClip(key, button);
            button = 0;
        }
        else
        {
            onceA = false;
            onceX = false;
            if ((moveSpeed != originalSpeed + dashSpeed) && (moveSpeed != 0.0f - dashSpeed))
            {
                moveSpeed = originalSpeed;
            }
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        moveSpeed = originalSpeed;
    }
}
