using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public GameObject theBomb;

    private Animator anim;

    private void Start()
    {
        anim = theBomb.GetComponent<Animator>();
    }

    public void ActivatedBomb()
    {
        anim.Play("bombAnim");
        //GetComponent<BoxCollider2D>().enabled = false;

        StartCoroutine(Destroy(1.3f));
    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
