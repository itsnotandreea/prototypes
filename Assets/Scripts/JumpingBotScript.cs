using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBotScript : MonoBehaviour
{
    public float force;
    
    public GameObject botOne,
                      botTwo,
                      botThree;

    public Rigidbody2D rbOne,
                       rbTwo,
                       rbThree;

    public IEnumerator Fire()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        
        //botOne.GetComponent<CapsuleCollider2D>().enabled = true;
        botOne.SetActive(true);
        rbOne = botOne.GetComponent<Rigidbody2D>();
        Vector2 upOne = rbOne.transform.TransformDirection(Vector2.up);
        rbOne.AddForce(upOne * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.20f);
        
        //botTwo.GetComponent<CapsuleCollider2D>().enabled = true;
        botTwo.SetActive(true);
        rbTwo = botTwo.GetComponent<Rigidbody2D>();
        Vector2 upTwo = rbTwo.transform.TransformDirection(Vector2.up);
        rbTwo.AddForce(upTwo * force, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.50f);

        //botThree.GetComponent<CapsuleCollider2D>().enabled = true;
        botThree.SetActive(true);
        rbThree = botThree.GetComponent<Rigidbody2D>();
        Vector2 upThree = rbThree.transform.TransformDirection(Vector2.up);
        rbThree.AddForce(upThree * force, ForceMode2D.Impulse);
    }
}
