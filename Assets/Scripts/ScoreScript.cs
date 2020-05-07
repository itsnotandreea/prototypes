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

    private string savedScore;

    private Text scoreText,
                 previousScoreText;

    private GameObject playerOne;

    private PlayerOneScript pOneScript;

    void Start()
    {
        scoreText = GetComponent<Text>();
        previousScoreText = previousScoreGO.GetComponent<Text>();

        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");

        pOneScript = playerOne.GetComponent<PlayerOneScript>();

        savedScore = "savedScore";
        
        score = 0;
        previousScore = PlayerPrefs.GetInt(savedScore);
        previousScoreText.text = "Best: " + previousScore.ToString();
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

        //does this if not in menu/compose mode
        if(pOneScript.lineLength <= limit)
        {
            pOneScript.lineLength += pOneScript.extraLength;
        }
    }
}
