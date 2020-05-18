using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownSystem : MonoBehaviour
{
    public Text UIText;

    public float mainTimer,
                 timer;

    public bool canCount;

    private bool doOnce;

    private void Start()
    {
        canCount = false;
        doOnce = false;

        timer = mainTimer;
    }

    private void Update()
    {
        if (timer > 1.0f && canCount)
        {
            timer -= Time.deltaTime;
            UIText.text = Mathf.Floor(timer / 60).ToString("0") + ":" + Mathf.FloorToInt(timer % 60).ToString("00");
        }
        else if (timer <= 1.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            UIText.text = "0.00";
            timer = 0.0f;
        }
    }
}
