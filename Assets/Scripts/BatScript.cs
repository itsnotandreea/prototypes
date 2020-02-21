using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public GameObject theBat;

    private Animator anim;

    private void Start()
    {
        anim = theBat.GetComponent<Animator>();
    }

    public void ActivatedBat()
    {
        anim.Play("batAnim");
        GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(Destroy(1.1f));
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);

        anim.Play("batIdle");
    }
}
