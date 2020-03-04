using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject ball;
    
    void Start()
    {
        ball.GetComponent<FauxGravityBody>().enabled = false;
    }

    public void FallingBall()
    {
        ball.AddComponent<Rigidbody2D>();
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.mass = 0.8f;
        ball.GetComponent<FauxGravityBody>().enabled = true;
    }
}
