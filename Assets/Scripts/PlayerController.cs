using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int key,                //1-major; 2-minor; 0-nothing
               extension;          //1-A; 2-B; 3-C; 4-D; 0-nothing

    public float moveSpeed;  //the speed

    public bool keySwitch; // keySwitch

    private bool LT,
                 RT,
                 triggered,
                 isGrounded;

    public float timer;

    private Transform playerPosition;

    private Rigidbody2D rb;  //the rigidbody of the player

    private ObstacleBuilder obstacleBuilder;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        obstacleBuilder = GetComponent<ObstacleBuilder>();

        //true = major, false = minor
        keySwitch = true;

        LT = false;
        RT = false;
        key = 0;
        extension = 0;
        triggered = false;
        
        timer = 0;
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

    private void Update()
    {
        TakeInput();

        //jumps, uses physics engine and adds force in the up direction
        if (Input.GetKeyDown("joystick 1 button 5") && isGrounded)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            rb.AddForce(up * 20f, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void TakeInput()
    {
        if (Input.GetAxisRaw("Major") != 0 && RT == false)
        {
            if (LT == false)
            {
                key = 1;
                LT = true;
                RT = false;
                triggered = true;
            }
        }
        else if (Input.GetAxisRaw("Minor") != 0 && LT == false)
        {
            if (RT == false)
            {
                key = 2;
                RT = true;
                LT = false;
                triggered = true;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Major") == 0)
            {
                key = 0;
                LT = false;
            }
        
            if (Input.GetAxisRaw("Minor") == 0)
            {
                key = 0;
                RT = false;
            }
        }
        
        if(triggered)
        {
            timer += Time.deltaTime;

            if (Input.GetKey("joystick 1 button 0"))
            {
                extension = 1;
                obstacleBuilder.BuildObstacle(key, extension);
                triggered = false;
                timer = 0;
            }
            else if (Input.GetKey("joystick 1 button 1"))
            {
                extension = 2;
                obstacleBuilder.BuildObstacle(key, extension);
                triggered = false;
                timer = 0;
            }
            else if (Input.GetKey("joystick 1 button 2"))
            {
                extension = 3;
                obstacleBuilder.BuildObstacle(key, extension);
                triggered = false;
                timer = 0;
            }
            else if (Input.GetKey("joystick 1 button 3"))
            {
                extension = 4;
                obstacleBuilder.BuildObstacle(key, extension);
                triggered = false;
                timer = 0;
            }
            else if(timer >= 0.8f)
            {
                extension = 0;
                obstacleBuilder.BuildObstacle(key, extension);
                triggered = false;
                timer = 0;
            }
            
            //obstacleBuilder.BuildObstacle(key, extension);
            
        }
    }
}
