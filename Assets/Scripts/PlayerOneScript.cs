using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneScript : MonoBehaviour
{
    public float moveSpeed,
                 radius,
                 closestKnotDist,
                 currentKnotDist,
                 length,
                 adjustAngle,
                 lineLength,
                 extraLength;

    public GameObject drawing,
                      floor,  
                      firstKnot,
                      line;

    [SerializeField]
    private int playerIndex = 0;

    private bool canConnect;

    private LineRenderer lineRenderer;

    private Vector2 centre,
                    aimDirection,
                    stickInput;

    private GameObject closestKnot,
                       secondKnot,
                       musicGO;

    private MusicSequence musicSequence;

    void Start()
    {
        transform.position = firstKnot.transform.position;

        //The music object and script to which the 'notes' are added to
        musicGO = GameObject.FindGameObjectWithTag("Music");
        musicSequence = musicGO.GetComponent<MusicSequence>();

        lineRenderer = drawing.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, firstKnot.transform.position);
        lineRenderer.SetPosition(1, firstKnot.transform.position + new Vector3(lineLength, 0, 0));

        closestKnotDist = 1000f;
        closestKnot = null;

        canConnect = true;
    }

    public int GetPlayerInput()
    {
        return playerIndex;
    }

    public void NavigateKnotsInput(Vector2 value)
    {
        stickInput = value;
    }

    public void CreateLineButtonInput()
    {
        if (firstKnot != null && firstKnot != closestKnot)
        {
            secondKnot = closestKnot;

            //checks if there are any other lines in range that might be intersecting if creating a line
            Collider2D[] lineList = Physics2D.OverlapCircleAll(centre, lineLength * 5.0f, 1 << 9);

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

                    firstKnot = secondKnot;
                    secondKnot = null;

                    transform.position = firstKnot.transform.position;

                    lineRenderer.SetPosition(0, firstKnot.transform.position);
                    lineRenderer.SetPosition(1, firstKnot.transform.position + new Vector3(lineLength, 0, 0));

                    canConnect = true;
                }
                else                        //if there is a line, deselects both knots so the player can try again
                {
                    secondKnot = null;

                    canConnect = true;
                }
            }
            else
            {
                CreateLine();

                firstKnot = secondKnot;
                secondKnot = null;

                transform.position = firstKnot.transform.position;

                lineRenderer.SetPosition(0, firstKnot.transform.position);

                canConnect = true;
            }
        }
    }

    void Update()
    {
        FindKnots();
    }

    void FindKnots()
    {
        //adds all knots in range of radius to an array
        centre = firstKnot.transform.position;

        Collider2D[] knotsList = Physics2D.OverlapCircleAll(centre, lineLength, 1 << 8);
        
        //resets closest distance every time
        closestKnotDist = 1000.0f;
        
        //if there are knots in range, it starts the navigation through them 
        if (knotsList.Length > 0)
        {
            Navigate();
        }
        
        //for each knot on the array, it calculates whether it's the closest to the player's input point
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

        //stops particle effect system for all knots but the closestKnot
        foreach (Collider2D knot in knotsList)
        {
            if (knot.gameObject != closestKnot)
            {
                knot.gameObject.GetComponent<ParticleSystem>().Stop();
                knot.gameObject.GetComponent<ParticleSystem>().Clear();
            }
        }

        //if the particle system of the closest knot is not already playing, it starts playing it
        if(closestKnot != null)
        {
            if (!closestKnot.GetComponent<ParticleSystem>().isPlaying)
            {
                var main = closestKnot.GetComponent<ParticleSystem>().main;
                main.startColor = new Color(255f, 225f, 0f, 255f);

                closestKnot.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    void Navigate()
    {
        //Calculates angle between start position and current position
        Vector2 initialPos = new Vector2(floor.transform.position.x, floor.transform.position.y) - new Vector2(floor.transform.position.x, floor.transform.position.y + 575.0f);
        Vector2 currentPos = new Vector2(floor.transform.position.x, floor.transform.position.y) - new Vector2(transform.position.x, transform.position.y);

        if(transform.position.x > 0)
        {
            adjustAngle = 360.0f - Vector2.Angle(initialPos, currentPos);
        }
        else
        {
            adjustAngle = Vector2.Angle(initialPos, currentPos);
        }

        //Takes Input from Joystick axis
        float x = stickInput.x;
        float y = stickInput.y;

        //Converts to radians and calculates cos and sin
        float angle = adjustAngle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(angle);
        float sin = Mathf.Sin(angle);

        //applies the new input to the player's position, respecting the radius
        float x2 = firstKnot.transform.position.x + (lineLength * (x * cos - y * sin));
        float y2 = firstKnot.transform.position.y + (lineLength * (x * sin + y * cos));

        aimDirection = new Vector2(x2, y2);
        
        DrawLine(aimDirection);

        Debug.DrawLine(firstKnot.transform.position, new Vector3(x2, y2, 0f), Color.black);
    }

    void DrawLine(Vector2 endPos)
    {
        Vector2 startPos = firstKnot.transform.position;
        Vector2 dir = endPos - startPos;

        float dist = Mathf.Clamp(Vector3.Distance(startPos, endPos), 0, lineLength);

        endPos = startPos + (dir.normalized * dist);

        lineRenderer.SetPosition(1, endPos);
    }

    /*
    void TakeInput()
    {
        //A button on xbox
        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            if (firstKnot != null && firstKnot != closestKnot)
            {
                secondKnot = closestKnot;
                
                //checks if there are any other lines in range that might be intersecting if creating a line
                Collider2D[] lineList = Physics2D.OverlapCircleAll(centre, lineLength * 5.0f, 1 << 9);
                
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

                        firstKnot = secondKnot;
                        secondKnot = null;

                        lineRenderer.SetPosition(0, firstKnot.transform.position);
                        lineRenderer.SetPosition(1, firstKnot.transform.position + new Vector3(lineLength, 0, 0));

                        canConnect = true;
                    }
                    else                        //if there is a line, deselects both knots so the player can try again
                    {
                        secondKnot = null;

                        canConnect = true;
                    }
                }
                else
                {
                    CreateLine();

                    firstKnot = secondKnot;
                    secondKnot = null;

                    lineRenderer.SetPosition(0, firstKnot.transform.position);

                    canConnect = true;
                }
            }
        }
    }
    */

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
