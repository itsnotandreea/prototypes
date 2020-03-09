using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject playerTwo,
                      fillArea;

    private PlayerTwoController pTwoController;

    private Slider slider;

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        pTwoController = playerTwo.GetComponent<PlayerTwoController>();        
    }
    
    void Update()
    {
        slider.value = pTwoController.total;
    }
}
