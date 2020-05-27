using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimationScript : MonoBehaviour
{
    private Animator animator;

    private Camera cam;

    void Start()
    {
        animator = GetComponent<Animator>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    void Update()
    {
        if (OnScreen())
        {
            animator.SetBool("playIdle", true);
        }
        else
        {
            animator.SetBool("playIdle", false);
        }
    }

    private bool OnScreen()
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

        if (screenPoint.x > -0.2f && screenPoint.x < 1.2f && screenPoint.y > -0.2f && screenPoint.y < 1.2f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
