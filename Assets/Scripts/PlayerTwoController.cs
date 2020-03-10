using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public int button,
               key,
               round,
               jumped,
               obstacles,
               total;

    public float moveSpeed,  //the speed
                 jumpHeight,
                 dashSpeed,
                 originalSpeed,
                 breakSpeed,
                 moreWeight,
                 fallMultiplier,
                 lowJumpMultiplier,
                 jellySpeed,
                 bombForce,
                 thwackForce;

    public bool isMajor;

    private bool isGrounded,
                 onceA,
                 isDashing,
                 inTrap;

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
        round = 1;
        jumped = 0;
        isDashing = false;
        inTrap = false;
        obstacles = 0;
        total = 12;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Round"))
        {
            round += 1;
        }

        if (other.CompareTag("JumpingBot"))
        {
            StartCoroutine(other.GetComponent<JumpingBotScript>().Fire());
            obstacles += 1;
        }

        if (other.CompareTag("BombTrigger"))
        {
            other.GetComponent<BombScript>().ActivatedBomb();
            obstacles += 1;
        }

        if (other.CompareTag("Bomb"))
        {
            if (isDashing)
            {
                total = obstacles;
                other.enabled = false;
            }
            else
            {
                other.gameObject.tag = "Untagged";
                obstacles -= 2;
                Vector2 direction = transform.position - other.transform.position;
                rb.AddForce(direction * bombForce, ForceMode2D.Impulse);
            }
        }

        if (other.CompareTag("ThwackTrigger"))
        {
            other.GetComponent<ThwackScript>().ActivatedThwack();
            obstacles += 1;
            StartCoroutine(Reactivate(other, 5.0f));
        }

        if (other.CompareTag("Thwack"))
        {
            Vector2 up = transform.TransformDirection(Vector2.up);
            rb.AddForce(up * thwackForce, ForceMode2D.Impulse);
            obstacles -= 2;
        }

        if (other.CompareTag("RainTrigger"))
        {
            obstacles += 1;
            StartCoroutine(other.GetComponent<RainScript>().MakeItRain());
        }

        if (other.CompareTag("RainDrop"))
        {
            moveSpeed = 0.0f;
            obstacles -= 2;

            foreach (Transform child in other.transform.parent.gameObject.transform)
            {
                child.gameObject.tag = "Untagged";
            }

            StartCoroutine(Wait(0.3f));
        }

        if (other.CompareTag("BatTrigger"))
        {
            other.GetComponent<BatScript>().ActivatedBat();
            obstacles += 1;
            StartCoroutine(Reactivate(other, 5.0f));
        }

        if (other.CompareTag("Bat"))
        {
            moveSpeed = 0.0f;
            obstacles -= 2;
            other.gameObject.tag = "Untagged";
            StartCoroutine(Wait(0.4f));
        }

        if (other.CompareTag("BallTrigger"))
        {
            other.GetComponent<BallScript>().FallingBall();
            obstacles += 1;
        }

        if (other.CompareTag("CatapultTrigger"))
        {
            StartCoroutine(other.GetComponent<CatapultScript>().Catapult());
            obstacles += 1;
        }

        if (other.CompareTag("Jelly"))
        {
            if (isDashing)
            {
                obstacles += 1;
                other.enabled = false;
                StartCoroutine(Reactivate(other, 5.0f));
            }
            else
            {
                obstacles -= 1;
                moveSpeed = jellySpeed;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Jelly"))
        {
            if (isDashing)
            {
                other.enabled = false;
                StartCoroutine(Reactivate(other, 5.0f));
            }
            else
            {
                moveSpeed = jellySpeed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ThwackTrigger") || other.CompareTag("BombTrigger"))
        {
            total = obstacles;
        }

        if (other.CompareTag("RainTrigger") || other.CompareTag("BallTrigger") || other.CompareTag("CatapultTrigger") || other.CompareTag("BatTrigger") || other.CompareTag("JumpingBot"))
        {
            total = obstacles;
            other.gameObject.tag = "Untagged";
        }

        if (other.CompareTag("Jelly"))
        {

            total = obstacles;
            other.gameObject.tag = "Untagged";

            if(!isDashing)
            {
                moveSpeed = originalSpeed;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Obstacle")) && isGrounded == false)
        {
            isGrounded = true;
            jumped = 0;
        }

        if (other.gameObject.tag == "Bot")
        {
            foreach (Transform child in other.transform.parent.gameObject.transform)
            {
                child.gameObject.tag = "Untagged";
            }

            obstacles -= 2;
        }

        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<Collider2D>().isTrigger = false;
            moveSpeed = 0.0f;
            obstacles -= 2;
            other.gameObject.tag = "Untagged";
            StartCoroutine(Wait(0.4f));
        }

        if (other.gameObject.tag == "CatapultBullet")
        {
            foreach (Transform child in other.transform.parent.gameObject.transform)
            {
                child.gameObject.tag = "Untagged";
            }
            obstacles -= 2;
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
        TakeInput();

        if (obstacles < 0)
        {
            obstacles = 0;
        }

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
            if(!inTrap)
            {
                //dash
                isDashing = true;
                moveSpeed = originalSpeed + dashSpeed;
                StartCoroutine(Wait(0.3f));

                button = 2;
                pTwoSound.AssignClip(key, button);
                button = 0;
            }
            
        }
        else if (Input.GetKeyDown("joystick 2 button 2"))
        {
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
            if ((moveSpeed != originalSpeed + dashSpeed) && (moveSpeed != 0.0f - dashSpeed) && (!inTrap) && (moveSpeed != 0.0f))
            {
                moveSpeed = originalSpeed;
            }
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        moveSpeed = originalSpeed;
        isDashing = false;
    }

    IEnumerator Reactivate(Collider2D other, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        other.enabled = true;
    }
}
