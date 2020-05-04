using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsAnimations : MonoBehaviour
{
    public bool idle,
                glow,
                selected;
    
    private Animator anim;

    private GameObject playerOne;

    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");

        anim = GetComponent<Animator>();

        idle = true;
        glow = false;
        selected = false;
    }
    
    void Update()
    {
        if (playerOne.transform.position == transform.position)
        {
            selected = true;

            anim.SetBool("selected", true);
            anim.SetBool("glow", false);
            anim.SetBool("idle", false);
        }
        else if (glow)
        {
            anim.SetBool("glow", true);
            anim.SetBool("idle", false);
            anim.SetBool("selected", false);
        }
        else
        {
            anim.SetBool("idle", true);
            anim.SetBool("glow", false);
            anim.SetBool("selected", false);
        }
    }
}
