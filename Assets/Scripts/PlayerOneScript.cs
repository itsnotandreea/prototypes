using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    public float radius,
                 closestKnotDist,
                 currentKnotDist;

    private int knotsInRange;

    private Vector2 centre,
                    aimDirection;

    private GameObject closestKnot,
                       firstKnot,
                       secondKnot;

    void Start()
    {
        knotsInRange = 0;

        closestKnotDist = 1000f;
        closestKnot = null;
    }
    
    void Update()
    {
        FindKnots();

        TakeInput();
    }

    void FindKnots()
    {
        centre = this.transform.position;

        Collider2D[] knotsList = Physics2D.OverlapCircleAll(centre, radius, 1 << 8);

        closestKnotDist = 1000.0f;
        
        if (knotsList.Length > 0)
        {
            Navigate();
        }
        
        foreach (Collider2D knot in knotsList)
        {
            currentKnotDist = Mathf.Sqrt(Mathf.Pow(aimDirection.x - knot.gameObject.transform.position.x, 2f) +
                                         Mathf.Pow(aimDirection.y - knot.gameObject.transform.position.y, 2f));

            if (currentKnotDist <= closestKnotDist)
            {
                closestKnotDist = currentKnotDist;

                closestKnot = knot.gameObject;
            }
        }

        foreach (Collider2D knot in knotsList)
        {
            if (knot.gameObject != closestKnot)
            {
                knot.gameObject.GetComponent<ParticleSystem>().Stop();
                knot.gameObject.GetComponent<ParticleSystem>().Clear();
            }
        }

        if (!closestKnot.GetComponent<ParticleSystem>().isPlaying)
        {
            closestKnot.GetComponent<ParticleSystem>().Play();
        }
        
        Debug.Log(closestKnot.name);

    }

    void Navigate()
    {
        float horizontal = this.transform.position.x + (radius * Input.GetAxis("POneLeftJoystickHorizontal"));
        float vertical = this.transform.position.y + (radius * Input.GetAxis("POneLeftJoystickVertical"));
        
        aimDirection = new Vector2(horizontal, vertical);

        Debug.DrawLine(this.transform.position, new Vector3(horizontal, vertical, 0f), Color.black);
    }

    void TakeInput()
    {
        if(Input.GetKey("joystick 1 button 0"))
        {
            if(firstKnot == null)
            {
                firstKnot = closestKnot;
                private ParticleSystem ps;
                ParticleSystem = 
                firstKnot.GetComponent<ParticleSystem>().main.startColor = new Color ();
            }
        }
    }
}
