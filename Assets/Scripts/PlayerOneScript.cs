using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneScript : MonoBehaviour
{
    public float moveSpeed,
                 radius,
                 closestKnotDist,
                 currentKnotDist,
                 length,
                 adjustAngle;

    public GameObject line,
                      floor;

    private bool canConnect;

    private Vector2 centre,
                    aimDirection;

    private GameObject closestKnot,
                       firstKnot,
                       secondKnot,
                       musicGO;

    private MusicSequence musicSequence;

    void Start()
    {
        musicGO = GameObject.FindGameObjectWithTag("Music");
        musicSequence = musicGO.GetComponent<MusicSequence>();

        closestKnotDist = 1000f;
        closestKnot = null;

        canConnect = true;
    }

    private void FixedUpdate()
    {
        //tells object what position to move to
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
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
            var main = closestKnot.GetComponent<ParticleSystem>().main;
            main.startColor = new Color(255f, 225f, 0f, 255f);

            closestKnot.GetComponent<ParticleSystem>().Play();
        }
    }

    void Navigate()
    {
        //Calculates angle between start position and current position
        Vector2 initialPos = new Vector2(floor.transform.position.x, floor.transform.position.y) - new Vector2(floor.transform.position.x, floor.transform.position.y + 575.0f);
        Vector2 currentPos = new Vector2(floor.transform.position.x, floor.transform.position.y) - new Vector2(transform.position.x, transform.position.y);
        float adjustAngle = 360.0f - Vector2.Angle(initialPos, currentPos);
        
        //Takes Input from Joystick axis
        float x = Input.GetAxis("POneLeftJoystickHorizontal");
        float y = Input.GetAxis("POneLeftJoystickVertical");

        //Converts to radians and calculates cos and sin
        float angle = adjustAngle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);

        //applies the new input to the player's position, respecting the radius
        float x2 = this.transform.position.x + (radius * (x * cos - y * sin));
        float y2 = this.transform.position.y + (radius * (x * sin + y * cos));

        aimDirection = new Vector2(x2, y2);

        /*
        float horizontal = this.transform.position.x + (radius * Input.GetAxis("POneLeftJoystickHorizontal"));
        float vertical = this.transform.position.y + (radius * Input.GetAxis("POneLeftJoystickVertical"));

        aimDirection = new Vector2(horizontal, vertical);
        */

        Debug.DrawLine(this.transform.position, new Vector3(x2, y2, 0f), Color.black);
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

                //firstKnot.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
            }
            else if (firstKnot == closestKnot && closestKnot != null)
            {
                //firstKnot.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f);

                firstKnot = null;
            }
            else if (firstKnot != null && firstKnot != closestKnot)
            {
                secondKnot = closestKnot;

                secondKnot.GetComponent<ParticleSystem>().Stop();
                secondKnot.GetComponent<ParticleSystem>().Clear();

                //secondKnot.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);


                //checks if there are any other lines in range that might be intersecting if creating a line
                Collider2D[] lineList = Physics2D.OverlapCircleAll(centre, radius * 5.0f, 1 << 9);
                
                if (lineList.Length > 0)
                {   
                    foreach (Collider2D line in lineList)
                    {
                        if (IsIntersecting(line.gameObject, firstKnot.transform.position.x, firstKnot.transform.position.y,
                                                            secondKnot.transform.position.x, secondKnot.transform.position.y) == true)
                        {
                            //if there is one such line, then a connection is not possible
                            canConnect = false;
                        }
                    }

                    if (canConnect)             //if there is no such line, a connection is possible and it creates one.
                    {
                        CreateLine();
                        canConnect = true;
                    }
                    else                        //if there is a line, deselects both knots so the player can try again
                    {
                        firstKnot = null;
                        secondKnot = null;
                        canConnect = true;
                    }
                }
                else
                {
                    CreateLine();
                }
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

        newLine.transform.SetParent(secondKnot.transform);

        newLine.GetComponent<Transform>().localScale = scaler;

        newLine.transform.eulerAngles = new Vector3(0.0f, 0.0f, rotation);

        newLine.AddComponent<BoxCollider2D>();

        AddToMusicSequenceList(firstKnot, secondKnot);
        
        firstKnot = null;
        secondKnot = null;
    }

    bool IsIntersecting(GameObject prevLine, float lineTwoStartX, float lineTwoStartY, float lineTwoEndX, float lineTwoEndY)
    {
        bool isIntersecting = false;
        
        //3d -> 2d
        Vector2 p1 = new Vector2(prevLine.transform.position.x, prevLine.transform.position.y);
        Vector2 p2 = new Vector2(prevLine.transform.parent.transform.position.x, prevLine.transform.parent.transform.position.y);

        Vector2 p3 = new Vector2(lineTwoStartX, lineTwoStartY);
        Vector2 p4 = new Vector2(lineTwoEndX, lineTwoEndY);

        float denominator = (p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y);

        //Make sure the denominator is > 0, if so the lines are parallel
        if (denominator != 0)
        {
            float u_a = ((p4.x - p3.x) * (p1.y - p3.y) - (p4.y - p3.y) * (p1.x - p3.x)) / denominator;
            float u_b = ((p2.x - p1.x) * (p1.y - p3.y) - (p2.y - p1.y) * (p1.x - p3.x)) / denominator;

            //Is intersecting if u_a and u_b are between 0 and 1
            if ((u_a >= 0) && (u_a <= 1) && (u_b >= 0) && (u_b <= 1))
            {
                isIntersecting = true;
            }
        }
        
        if ((p1 == p3) || (p1 == p4) || (p2 == p3) || (p2 == p4))
        {
            isIntersecting = false;
        }
        
        return isIntersecting;
    }

    private void AddToMusicSequenceList(GameObject firstKnot, GameObject secondKnot)
    {
        //checks if the last knot is the same as the first one in th new line, so it doesn't add the same note twice?
        if (musicSequence.sequence.Count > 0)
        {
            if (musicSequence.sequence[musicSequence.sequence.Count - 1] != firstKnot)
            {
                musicSequence.sequence.Add(firstKnot);
            }
        }
        else
        {
            musicSequence.sequence.Add(firstKnot);
        }
        
        musicSequence.sequence.Add(secondKnot);
    }
}
