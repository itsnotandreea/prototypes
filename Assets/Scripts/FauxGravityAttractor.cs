﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    public float gravity;

    public Vector2 gravityUp = Vector2.zero;

    private Vector2 bodyUp = Vector2.zero;

    private void Start()
    {
    }

    public void Attract(Transform body, Rigidbody2D rb)
    {
        //determines the direction of the player from the centre of the circle
        gravityUp = new Vector2(body.position.x - transform.position.x, body.position.y - transform.position.y).normalized;
        
        //Debug.Log("gravityUp= " + gravityUp);

        //the direction the body is currently facing
        bodyUp  = body.up;

        //adds a force in the direction from the center of the planet to the player
        rb.AddForce(gravityUp * gravity);

        //the rotation between two directions, gravityUp and bodyUp
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp,gravityUp) * body.rotation;

        //smooth rotation for the player
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
