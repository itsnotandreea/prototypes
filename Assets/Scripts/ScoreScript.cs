using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score,
               previousScore,
               limit;

    public GameObject previousScoreGO;

    public bool scoreMode;

    private string savedScore;

    private Text scoreText,
                 previousScoreText;
    
    private PlayerOneScript pOneScript;

    void Awake()
    {
        pOneScript = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerOneScript>();

        scoreText = GetComponent<Text>();
        previousScoreText = previousScoreGO.GetComponent<Text>();
        
        savedScore = "savedScore";
        
        score = 0;
        previousScore = PlayerPrefs.GetInt(savedScore, 0);
        previousScoreText.text = "Best: " + previousScore.ToString();
    }
    
    void Update()
    {
        if (scoreMode)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void IncreaseScore()
    {
        if (scoreMode)
        {
            score += 1;

            if (score > previousScore)
            {
                previousScore = score;
                PlayerPrefs.SetInt(savedScore, previousScore);
            }
        }
        
        if(pOneScript.menuMode == false)
        {
            if(pOneScript.lineLength <= limit)
            {
                pOneScript.lineLength += pOneScript.extraLength;
            }
        }
    }
}
