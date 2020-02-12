using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed,  //the speed
                 jumpHeight,
                 dashSpeed,
                 originalSpeed,
                 breakSpeed,
                 moreWeight;

    private bool isGrounded;

    private Rigidbody2D rb;  //the rigidbody of the player
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        moveSpeed = originalSpeed;
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
        if (Input.GetKey("joystick 2 button 0"))
        {
            //duck
            Vector3 down = transform.TransformDirection(Vector3.down);
            rb.AddForce(down * moreWeight, ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown("joystick 2 button 1"))
        {
            //dash
            moveSpeed = dashSpeed;
            StartCoroutine(Wait(0.75f));
        }
        else if (Input.GetKey("joystick 2 button 2"))
        {
            moveSpeed = breakSpeed;
        }
        else if (Input.GetKeyDown("joystick 2 button 3"))
        {
            //jumps, uses physics engine and adds force in the up direction
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }
        else
        {
            if(moveSpeed != dashSpeed)
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
