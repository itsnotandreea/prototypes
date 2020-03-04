using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultScript : MonoBehaviour
{
    public float power;

    public GameObject bulletOne,
                      bulletTwo,
                      bulletThree;

    public Rigidbody2D rbOne,
                       rbTwo,
                       rbThree;
    
    private Vector2 AngleVector,
                    direction,
                    posOne,
                    posTwo,
                    posThree;

    void Start()
    {
        bulletOne.GetComponent<FauxGravityBody>().enabled = false;
        bulletTwo.GetComponent<FauxGravityBody>().enabled = false;
        bulletThree.GetComponent<FauxGravityBody>().enabled = false;

        bulletOne.GetComponent<CircleCollider2D>().enabled = false;
        bulletTwo.GetComponent<CircleCollider2D>().enabled = false;
        bulletThree.GetComponent<CircleCollider2D>().enabled = false;

        rbOne = bulletOne.GetComponent<Rigidbody2D>();
        rbTwo = bulletTwo.GetComponent<Rigidbody2D>();
        rbThree = bulletThree.GetComponent<Rigidbody2D>();

        posOne = bulletOne.transform.position;
        posTwo = bulletTwo.transform.position;
        posThree = bulletThree.transform.position;
        
        AngleVector = new Vector2 (-0.3f, 0.15f);
        direction = transform.TransformDirection(AngleVector);
    }

    public IEnumerator Catapult()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        rbOne.AddForce(direction * power, ForceMode2D.Impulse);
        bulletOne.GetComponent<FauxGravityBody>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        bulletOne.GetComponent<CircleCollider2D>().enabled = true;

        yield return new WaitForSeconds(0.6f);

        rbTwo.AddForce(direction * power, ForceMode2D.Impulse);
        bulletTwo.GetComponent<FauxGravityBody>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        bulletTwo.GetComponent<CircleCollider2D>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        rbThree.AddForce(direction * power, ForceMode2D.Impulse);
        bulletThree.GetComponent<FauxGravityBody>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        bulletThree.GetComponent<CircleCollider2D>().enabled = true;


        yield return new WaitForSeconds(5.0f);

        bulletOne.transform.position = posOne;
        bulletTwo.transform.position = posTwo;
        bulletThree.transform.position = posThree;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
