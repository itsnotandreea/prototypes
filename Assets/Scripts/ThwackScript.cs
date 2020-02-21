using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwackScript : MonoBehaviour
{
    public GameObject theThwack;

    private Animator anim;

    private void Start()
    {
        anim = theThwack.GetComponent<Animator>();
    }

    public void ActivatedThwack()
    {
        anim.Play("thwackAnim");
        GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(Destroy(1.0f));
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);

        anim.Play("thwackIdle");
    }
}
