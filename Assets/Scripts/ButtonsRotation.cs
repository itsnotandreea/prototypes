using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsRotation : MonoBehaviour
{
    private GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    
    private void Update()
    {
        transform.rotation = cam.transform.rotation;
    }
}
