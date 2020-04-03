using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score,
               previousScore;

    public GameObject previousScoreGO;

    private string savedScore;

    private Text scoreText,
                 previousScoreText;

    private GameObject playerOne;

    private PlayerOneScript pOneScript;

    void Start()
    {
        scoreText = GetComponent<Text>();
        previousScoreText = previousScoreGO.GetComponent<Text>();

        playerOne = GameObject.FindWithTag("PlayerOne");

        pOneScript = playerOne.GetComponent<PlayerOneScript>();

        score = 0;
        previousScore = PlayerPrefs.GetInt(savedScore);
        previousScoreText.text = "Prev. score: " + previousScore.ToString();
    }
    
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore()
    {
        score += 1;
        
        if(score > previousScore)
        {
            previousScore = score;
            PlayerPrefs.SetInt(savedScore, previousScore);
        }

        pOneScript.lineLength += pOneScript.extraLength;
    }
}
