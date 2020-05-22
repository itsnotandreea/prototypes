﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public int gallerySize;

    public Text UIWinner;

    public GameObject countdown,
                      timeUI,
                      scoreUI,
                      bestUI,
                      restartUI,
                      collectablesZone,
                      knotsZone,
                      floor,
                      pictureHolder;

    private bool takePicture,
                 scoreMode,
                 composeMode,
                 menuMode,
                 galleryMode,
                 finishOnce;

    private CountdownSystem cdSystem;
    private PlayerOneScript pOneScript;
    private PlayerTwoScript pTwoScript;
    private CamScript camScript;
    private MenuScript menuScript;
    private MusicSequence musicSeq;
    private RecorderScript recorderScript;
    private MusicPlayerScript musicPlayerScript;
    private ScoreScript scoreScript;

    private string noOfArtworks;

    void Awake()
    {
        noOfArtworks = "noOfArtworks";
        gallerySize = PlayerPrefs.GetInt(noOfArtworks, 100);

        Cursor.visible = false;

        cdSystem = countdown.GetComponent<CountdownSystem>();

        pOneScript = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerOneScript>();
        pTwoScript = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<PlayerTwoScript>();

        camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamScript>();

        menuScript = GameObject.FindGameObjectWithTag("startingArea").GetComponent<MenuScript>();

        musicSeq = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicSequence>();

        recorderScript = GameObject.FindGameObjectWithTag("Recorder").GetComponent<RecorderScript>();

        musicPlayerScript = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayerScript>();

        scoreScript = scoreUI.GetComponent<ScoreScript>();

        UIWinner.enabled = false;

        takePicture = true;

        scoreMode = false;
        composeMode = false;
        menuMode = true;
        galleryMode = false;

        pOneScript.menuMode = true;
        pOneScript.lineLength = 60;

        pTwoScript.menuMode = true;

        camScript.menuMode = true;

        finishOnce = true;
    }

    void Update()
    {
        if (menuMode)
        {
            GetMode();
        }

        //quit game in built
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
        if (cdSystem.timer <= 0.0f)
        {
            if (finishOnce)
            {
                pOneScript.enabled = false;
                pTwoScript.enabled = false;
                UIWinner.enabled = true;
                musicSeq.musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                musicSeq.enabled = false;
                StartCoroutine(WaitMusic(5.0f));

                floor.SetActive(false);
                scoreUI.SetActive(false);
                bestUI.SetActive(false);
                timeUI.SetActive(false);
                knotsZone.SetActive(false);
                collectablesZone.SetActive(false);

                finishOnce = false;

                camScript.menuCurrentPos = camScript.finalPicturePos;
                camScript.finishedMode = true;
            }
            
            camScript.gameObject.transform.position = camScript.finalPicturePos;
            camScript.cam.orthographicSize = Mathf.Lerp(camScript.cam.orthographicSize, 700, Time.deltaTime * 0.1f);
            camScript.cam.transform.rotation = Quaternion.Lerp(camScript.cam.transform.rotation, Quaternion.identity, Time.time * 0.3f);
            
            if (takePicture)
            {
                gallerySize++;
                PlayerPrefs.SetInt(noOfArtworks, gallerySize);
                TakePicture.TakeScreenshot_Static(2000, 2000);
                takePicture = false;
            }
        }
    }

    private void GetMode()
    {
        if (menuScript.playButton)
        {
            camScript.menuCurrentPos = camScript.menuPosTwo;
        }
        else if (menuScript.scoreButton)
        {
            scoreMode = true;
            composeMode = false;
            scoreScript.scoreMode = true;

            camScript.menuCurrentPos = camScript.menuPosThree;
            StartGame();
        }
        else if (menuScript.composeButton)
        {
            composeMode = true;
            scoreMode = false;
            scoreScript.scoreMode = false;

            camScript.menuCurrentPos = camScript.menuPosThree;
            StartGame();
        }
        else if (menuScript.galleryButton)
        {
            camScript.menuCurrentPos = camScript.galleryPos;
        }
        else
        {
            if (menuMode)
            {
                camScript.menuCurrentPos = camScript.menuPosOne;
            }
        }
    }

    private void StartGame()
    {
        pOneScript.lineLength = 25.0f;

        float smoothness = Mathf.Lerp(camScript.cam.orthographicSize, 40, Time.deltaTime);
        camScript.cam.orthographicSize = smoothness;

        if (camScript.gameObject.transform.position == camScript.menuPosThree)
        {
            menuMode = false;
            pOneScript.menuMode = false;
            pTwoScript.menuMode = false;
            camScript.menuMode = false;

            cdSystem.canCount = true;

            collectablesZone.SetActive(true);
            knotsZone.SetActive(true);

            timeUI.SetActive(true);
            //restartUI.SetActive(true);

            if (scoreMode)
            {
                scoreUI.SetActive(true);
                bestUI.SetActive(true);

                menuScript.gameObject.transform.Find("ScoreMode").transform.parent = null;
                Destroy(menuScript.gameObject);
            }
            if (composeMode)
            {
                scoreUI.SetActive(true);
                scoreUI.GetComponent<Text>().enabled = false;
                bestUI.SetActive(false);

                menuScript.gameObject.transform.Find("Compose").transform.parent = null;
                Destroy(menuScript.gameObject);
            }
        }
    }

    IEnumerator WaitMusic(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, "Art" + (gallerySize) + ".png");
        
        TextAsset song = LoadText(filePath);

        musicPlayerScript.songFile = song;
        musicPlayerScript.enabled = true;
    }  
    
    private TextAsset LoadText(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return null;
        }

        if (System.IO.File.Exists(path))
        {
            TextAsset newText = new TextAsset(System.IO.File.ReadAllText(path));
            return newText;
        }

        return null;
    }
}
