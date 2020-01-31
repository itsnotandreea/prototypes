using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    public FauxGravityAttractor attractor;   //the script that attracts this object

    public Rigidbody2D rb;                   //the rigidbody of the player object

    private Transform myTransform;           //the transform component of the player object

    private GameObject player;               //the player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;               //sets the usual, normal gravity force scale to 0,
                                            //so the usual physics don't apply and the object can float

        myTransform = GetComponent<Transform>();

        player = this.gameObject;           //the GameObject this MonoBehavious is attached to
    }

    
    void Update()
    {
        //calls for method to attract this GameObject, through the object's Transform and Rigidbody components as parameters
        attractor.Attract(myTransform, rb);
    }
}
