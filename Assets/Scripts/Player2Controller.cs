using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float moveSpeed;  //the speed

    private bool isGrounded;

    private Rigidbody2D rb;  //the rigidbody of the player
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
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

        //jumps, uses physics engine and adds force in the up direction
        if (Input.GetKeyDown("joystick 2 button 0"))
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * 25f, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
