using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStarsScript : MonoBehaviour
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

        if (cam.orthographicSize < 100)
        {
            if (screenPoint.x > -1.0f && screenPoint.x < 2.0f && screenPoint.y > -1.0f && screenPoint.y < 2.0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
