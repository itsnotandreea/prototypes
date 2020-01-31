using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;  //the speed

    public bool keySwitch; // keySwitch

    private Rigidbody2D rb;  //the rigidbody of the player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //true = major, false = minor
        keySwitch = true;
    }

    void FixedUpdate()
    {
        /*
        //takes input on the horizontal axis
        float move = Input.GetAxis("Horizontal");

        //tells object which direction to move in
        if (move > 0)
        {
            rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);
        }
        
        Vector3 right = transform.TransformDirection(Vector3.right);
        rb.AddForce(right * moveSpeed * Time.deltaTime);
        */

        //tells object what position to move to
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        //jumps, uses physics engine and adds force in the up direction
        if (Input.GetKeyDown("space"))
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * 10f, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            keySwitch = !keySwitch;
            Debug.Log("CHANGE!!!");
        }
    }
}
