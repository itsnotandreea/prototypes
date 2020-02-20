using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    public int key,                //1-major; 2-minor; 0-nothing
               extension,          //1-A; 2-B; 3-C; 4-D; 0-nothing
               round;

    public float moveSpeed,  //the speed
                 timer,
                 fallMultiplier,
                 lowJumpMultiplier,
                 jumpHeight;

    public bool isMajor;

    private bool LT,
                 RT,
                 triggered,
                 isGrounded,
                 canAddObstacle;

    private int jumped;

    private Transform playerPosition;

    private Rigidbody2D rb;  //the rigidbody of the player

    private ObstacleBuilder obstacleBuilder;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        obstacleBuilder = GetComponent<ObstacleBuilder>();

        LT = false;
        RT = false;
        key = 1;
        extension = 0;
        triggered = false;
        round = 1;

        timer = 2f;
        isGrounded = true;
        jumped = 0;
        isMajor = true;
        canAddObstacle = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Round"))
        {
            round += 1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Obstacle")))
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

    private void Update()
    {
        //quit game in built
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

        //takes input for leading player
        TakeInput();

        //jumps, uses physics engine and adds force in the up direction
        if (Input.GetKeyDown("joystick 1 button 5") && (jumped < 2))
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            //rb.AddForce(up * 25f, ForceMode2D.Impulse);
            rb.velocity = up * jumpHeight;
            isGrounded = false;
            jumped += 1;
        }

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

    private void TakeInput()
    {
        timer += Time.deltaTime;

        if(timer >= 0.25f)
        {
            canAddObstacle = true;
        }
        else
        {
            canAddObstacle = false;
        }

        if(Input.GetAxisRaw("Major") != 0)
        {
            if(!isMajor)
            {
                key = 1;
                isMajor = true;
                timer = 0;
            }
        }
        else if (Input.GetAxisRaw("Minor") != 0)
        {
            if (isMajor)
            {
                key = 2;
                isMajor = false;
                timer = 0;
            }
        }

        if (Input.GetKey("joystick 1 button 0") && canAddObstacle)
        {
            extension = 1;
            obstacleBuilder.BuildObstacle(key, extension);
            timer = 0;
        }
        else if (Input.GetKey("joystick 1 button 1") && canAddObstacle)
        {
            extension = 2;
            obstacleBuilder.BuildObstacle(key, extension);
            timer = 0;
        }
        else if (Input.GetKey("joystick 1 button 2") && canAddObstacle)
        {
            extension = 3;
            obstacleBuilder.BuildObstacle(key, extension);
            timer = 0;
        }
        else if (Input.GetKey("joystick 1 button 3") && canAddObstacle)
        {
            extension = 0;
            obstacleBuilder.BuildObstacle(key, extension);
            timer = 0;
        }
    }
}
