using System.Collections;
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
                      pictureHolder,
                      galleryArea;

    private bool takePicture,
                 scoreMode,
                 composeMode,
                 menuMode,
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

        pOneScript.menuMode = true;
        pOneScript.lineLength = 60;

        pTwoScript.menuMode = true;

        camScript.menuMode = true;

        finishOnce = true;
    }

    private void Start()
    {
        StartCoroutine(DeactivateGalleryArea(false));
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
                musicSeq.enabled = false;
                StartCoroutine(WaitMusic(2.0f));

                floor.SetActive(false);
                scoreUI.SetActive(false);
                bestUI.SetActive(false);
                timeUI.SetActive(false);
                knotsZone.SetActive(false);
                collectablesZone.SetActive(false);

                finishOnce = false;
            }
            
            if (takePicture)
            {
                Vector3 tempPosition = camScript.gameObject.transform.position;
                camScript.gameObject.transform.position = camScript.finalPicturePos;

                float tempSize = camScript.cam.orthographicSize;
                camScript.cam.orthographicSize = 700.0f;

                Quaternion tempRotation = camScript.cam.transform.rotation;
                camScript.cam.transform.rotation = Quaternion.identity;


                gallerySize++;
                recorderScript.WriteTxtFile();
                PlayerPrefs.SetInt(noOfArtworks, gallerySize);
                TakePicture.TakeScreenshot_Static(2000, 2000);
                takePicture = false;

                StartCoroutine(WaitPicture(tempPosition, tempSize, tempRotation));
            }
            else
            {
                //camScript.gameObject.transform.position = camScript.finalPicturePos;
                camScript.cam.orthographicSize = Mathf.Lerp(camScript.cam.orthographicSize, 700, Time.deltaTime * 0.1f);
                camScript.cam.transform.rotation = Quaternion.Lerp(camScript.cam.transform.rotation, Quaternion.identity, Time.time * 0.3f);
            }
        }
    }

    private void GetMode()
    {
        if (menuScript.playButton)
        {
            camScript.menuCurrentPos = camScript.menuPosTwo;

            if (galleryArea.activeSelf)
            {
                StartCoroutine(DeactivateGalleryArea(true));
            }
        }
        else if (menuScript.scoreButton)
        {
            scoreMode = true;
            composeMode = false;
            scoreScript.scoreMode = true;

            camScript.menuCurrentPos = camScript.menuPosThree;
            StartGame();

            if (galleryArea.activeSelf)
            {
                StartCoroutine(DeactivateGalleryArea(true));
            }
        }
        else if (menuScript.composeButton)
        {
            composeMode = true;
            scoreMode = false;
            scoreScript.scoreMode = false;

            camScript.menuCurrentPos = camScript.menuPosThree;
            StartGame();

            if (galleryArea.activeSelf)
            {
                StartCoroutine(DeactivateGalleryArea(true));
            }
        }
        else if (menuScript.galleryButton)
        {
            camScript.menuCurrentPos = camScript.galleryPos;
            StartCoroutine(ActivateGalleryArea());
        }
        else
        {
            if (menuMode)
            {
                camScript.menuCurrentPos = camScript.menuPosOne;

                if (galleryArea.activeSelf)
                {
                    StartCoroutine(DeactivateGalleryArea(true));
                }
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
        
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, "Art" + (gallerySize) + ".txt");
        
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
    
    IEnumerator WaitPicture(Vector3 tempPosition, float tempSize, Quaternion tempRotation)
    {
        yield return new WaitForSeconds(0.0f);
        
        camScript.gameObject.transform.position = tempPosition;
        camScript.cam.orthographicSize = tempSize;
        camScript.cam.transform.rotation = tempRotation;

        camScript.menuCurrentPos = camScript.finalPicturePos;
        camScript.finishedMode = true;

        takePicture = false;
    }

    private IEnumerator DeactivateGalleryArea(bool wait)
    {
        if (wait)
        {
            yield return new WaitForSeconds(4.0f);
        }

        musicPlayerScript.enabled = false;

        galleryArea.SetActive(false);

        for (int i = 0; i < galleryArea.transform.childCount; i++)
        {
            galleryArea.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private IEnumerator ActivateGalleryArea()
    {
        galleryArea.SetActive(true);

        yield return new WaitForSeconds(3.5f);

        galleryArea.transform.GetChild(5).gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.3f);
        
        galleryArea.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        galleryArea.transform.GetChild(1).gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.3f);

        galleryArea.transform.GetChild(2).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        galleryArea.transform.GetChild(3).gameObject.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        galleryArea.transform.GetChild(4).gameObject.SetActive(true);


        yield return new WaitForSeconds(0.9f);

        for (int i = 6; i < galleryArea.transform.childCount; i++)
        {
            galleryArea.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
