using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTwoScript : MonoBehaviour
{
    public int button,
               jumped,
               gettingInputFromXSources;

    public float moveSpeed,
                 jumpHeight,
                 fallMultiplier,
                 lowJumpMultiplier,
                 impulse,
                 pressedTime,
                 minimPressedTime,
                 angleFriction,
                 offScreenLimit;
    
    public GameObject score,
                      backgroundClouds;

    public bool isGrounded,
                held,
                menuMode;

    private float offScreenTime,
                  xOne,
                  xTwo,
                  xFinal;

    private bool onScreen;
    
    private Rigidbody2D rb;

    private SpriteRenderer spriteR;

    private PlayerTwoSound pTwoSound;

    private MusicSequence musicSequenceScript;

    private ScoreScript scoreScript;

    private Vector2 moveAmount,
                    smoothMoveVelocity,
                    moveDir,
                    targetMoveAmount;

    private Vector3 bounceDirection;

    private Animator animator;

    private ParticleSystem particleSys;

    private Camera cam;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteR = GetComponent<SpriteRenderer>();

        pTwoSound = GetComponent<PlayerTwoSound>();

        musicSequenceScript = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSequence>();

        scoreScript = score.GetComponent<ScoreScript>();

        animator = GetComponent<Animator>();
        
        particleSys = GetComponent<ParticleSystem>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        button = 100;
        isGrounded = true;
        held = false;
        pressedTime = 0.0f;

        bounceDirection = new Vector3(1, 5, 0);

        gettingInputFromXSources = 0;
    }

    public void RunInputUpdate(float xInput, int source)
    {
        if (source == 1)
        {
            xOne = xInput;
        }
        if (source == 2)
        {
            xTwo = xInput;
        }

        if (xOne == 0.0f && xTwo == 0.0f)
        {
            xFinal = 0.0f;
        }
        else if (xOne != 0)
        {
            xFinal = xOne;
        }
        else if (xTwo != 0)
        {
            xFinal = xTwo;
        }
        
        if (xFinal > 0 && spriteR.flipX == true)
        {
            spriteR.flipX = false;
        }
        else if (xFinal < 0 && spriteR.flipX == false)
        {
            spriteR.flipX = true;
        }

        //gets input from PlayerInputHandler from Left Stick X Axis
        moveDir = new Vector3(xFinal, 0, 0) * 10f;
        //adds speed
        targetMoveAmount = moveDir * moveSpeed;
        //adds a smoothing effect between the current and desired amount of 'moving' the player wants
        moveAmount = Vector2.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, 0.15f);
    }

    public void JumpInput()
    {
        //how long has the player been pressing the jump button
        pressedTime += Time.deltaTime;
    }

    public void JumpReleaseInput()
    {
        //when player releases jump button, if the button wasn't held, calls for jump
        if (!held)
        {
            //checks if the player has jumped already more than twice
            if (jumped < 2)
            {
                Jump();
            }
        }
        else
        {
            if (jumped < 2)
            {
                Bounce();
            }
        }

        //resets pressed time
        pressedTime = 0;
        held = false;
    }

    public void CancelLayersInput()
    {
        if(!musicSequenceScript.cancelLayers)
        {
            musicSequenceScript.cancelLayers = true;
        }
    }

    public void CancelLayersReleaseInput()
    {
        if (musicSequenceScript.cancelLayers)
        {
            musicSequenceScript.cancelLayers = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (((other.gameObject.tag == "Floor") || (other.gameObject.tag == "Line")) && isGrounded == false)
        {
            isGrounded = true;
            jumped = 0;
        }
        /*
        if ((other.gameObject.tag == "Line") && held == true)
        {
            held = false;
            pressedTime = 0.0f;
            //line = other;
            if (jumped < 2)
            {
                Bounce();
            }
        }
        */
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
            other.enabled = false;

            scoreScript.IncreaseScore();
            
            particleSys.Play();
            
            if(other.gameObject.GetComponent<Animator>())
            {
                Animator animator = other.gameObject.GetComponent<Animator>();
                //float clipLength = animator.runtimeAnimatorController.animationClips[0].length;

                animator.SetBool("playAnim", true);
                //Destroy(other.gameObject, clipLength + 0.2f);
            }
            else
            {
                Destroy(other.gameObject);
            }

            musicSequenceScript.GetCollectable(other.gameObject);

            backgroundClouds.GetComponent<BackgroundScript>().GetCollectable(other.gameObject);
        }

        if (other.gameObject.tag == "Clouds")
        {
            backgroundClouds.GetComponent<BackgroundScript>().GetCloud(other.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //transforms the direction in the characte's local space
        Vector2 moveAm = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;

        //adds the distance to the current rigidbody's position
        rb.position += moveAm;
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

        CheckIfOnScreen();
    }
    
    private void Jump()
    {
        //jumps, uses physics engine and adds force in the up direction
        Vector2 up = transform.TransformDirection(Vector2.up);
        rb.AddForce(up * jumpHeight);

        animator.Play("playerTwoJump");

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
        //Vector3 direction = transform.TransformDirection(bounceDirection);
        Vector3 direction = transform.TransformDirection(Vector3.up * 5);
        rb.AddForce(direction * impulse, ForceMode2D.Impulse);

        animator.Play("playerTwoBounce");

        //grounding
        isGrounded = false;
        jumped += 1;

        //sound
        button = 0;
        pTwoSound.AssignClip(button);
    }

    private void CheckIfOnScreen()
    {
        //RESWANS PLAYER 2 IF LEFT OFFSCREEN FOR A LONGER TIME PERIOD
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

        if (screenPoint.x > 0.0f && screenPoint.x < 1.0f && screenPoint.y > 0.0f && screenPoint.y < 1.0f)
        {
            if (!onScreen)
            {
                onScreen = true;
                offScreenTime = 0.0f;
            }
        }
        else
        {
            if (onScreen)
            {
                onScreen = false;
            }
        }

        if (!onScreen)
        {
            offScreenTime += Time.deltaTime;
        }

        if (offScreenTime > offScreenLimit)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector2(0.25f, 0.9f));
        }
    }
}