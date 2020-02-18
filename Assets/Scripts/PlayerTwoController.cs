using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public int button,
               key,
               round;

    public float moveSpeed,  //the speed
                 jumpHeight,
                 dashSpeed,
                 originalSpeed,
                 breakSpeed,
                 moreWeight;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Round"))
        {
            round += 1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Obstacle")) && isGrounded == false)
        {
            isGrounded = true;
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
            moveSpeed = dashSpeed;
            StartCoroutine(Wait(0.75f));

            button = 2;
            pTwoSound.AssignClip(key, button);
            button = 0;
        }
        else if (Input.GetKey("joystick 2 button 2"))
        {
            moveSpeed -= Time.deltaTime * 40.0f;

            if(!onceX)
            {
                onceX = true;
                button = 3;
                pTwoSound.AssignClip(key, button);
            }
            button = 0;
        }
        else if (Input.GetKeyDown("joystick 2 button 3"))
        {
            //jumps, uses physics engine and adds force in the up direction
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;

            button = 4;
            pTwoSound.AssignClip(key, button);
            button = 0;
        }
        else
        {
            onceA = false;
            onceX = false;
            if (moveSpeed != dashSpeed)
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
