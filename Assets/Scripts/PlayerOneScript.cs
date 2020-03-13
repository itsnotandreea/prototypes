using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    public float radius,
                 closestKnotDist,
                 currentKnotDist,
                 length;

    public GameObject line;

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
        if(Input.GetKeyDown("joystick 1 button 0"))
        {
            if(firstKnot == null && closestKnot != null)
            {
                firstKnot = closestKnot;

                firstKnot.GetComponent<ParticleSystem>().Stop();
                firstKnot.GetComponent<ParticleSystem>().Clear();

                firstKnot.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            }
            else if (firstKnot == closestKnot && closestKnot != null)
            {
                firstKnot.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);

                firstKnot = null;
            }
            else if (firstKnot != null && firstKnot != closestKnot)
            {
                secondKnot = closestKnot;

                secondKnot.GetComponent<ParticleSystem>().Stop();
                secondKnot.GetComponent<ParticleSystem>().Clear();

                secondKnot.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);

                CreateLine();
            }
        }
    }

    void CreateLine()
    {
        GameObject newLine = Instantiate(line, firstKnot.transform.position, transform.rotation);

        length = Mathf.Sqrt(Mathf.Pow(firstKnot.transform.position.x - secondKnot.transform.position.x, 2f) +
                            Mathf.Pow(firstKnot.transform.position.y - secondKnot.transform.position.y, 2f));
        
        Vector3 scaler = new Vector3(length / 10f, 1.0f, 1.0f);

        
        float rotation = Vector3.Angle(Vector3.right, secondKnot.transform.position - firstKnot.transform.position);
        
        if(secondKnot.transform.position.y - firstKnot.transform.position.y < 0.0f)
        {
            rotation *= -1.0f;
        }

        //newLine.transform.SetParent(firstKnot.transform);

        newLine.GetComponent<Transform>().localScale = scaler;

        newLine.transform.eulerAngles = new Vector3(0.0f, 0.0f, rotation);

        newLine.AddComponent<BoxCollider2D>();
        
        firstKnot = null;
        secondKnot = null;
    }
}
