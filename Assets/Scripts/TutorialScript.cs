using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public bool collectedTheOne;

    private int playerOneInput,
                playerTwoInput;

    private bool doOnce;

    private Color colour;

    private GameObject playerTwo,
                       playerOne;

    private MainManager mainManager;
    
    void Awake()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<MainManager>();

        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");

        collectedTheOne = false;

        playerOneInput = 0;
        playerTwoInput = 0;

        colour = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        doOnce = true;
    }
    
    void Update()
    {
        if (doOnce)
        {
            if (playerOne.GetComponent<PlayerOneScript>().connectedOne == true)
            {
                if (playerTwo.GetComponent<SpriteRenderer>().enabled == false)
                {
                    transform.GetChild(2).transform.position = new Vector3(playerTwo.transform.position.x - 8.0f, playerTwo.transform.position.y + 10.0f, playerTwo.transform.position.z);
                    transform.GetChild(3).transform.position = new Vector3(playerTwo.transform.position.x + 9.0f, playerTwo.transform.position.y + 10.0f, playerTwo.transform.position.z);
                
                    gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    gameObject.transform.GetChild(3).gameObject.SetActive(true);

                    StartCoroutine(CreateNewKnots());

                    playerTwo.transform.position = new Vector3(-37.0f, 250.0f, 0.0f);
                    playerTwo.GetComponent<SpriteRenderer>().enabled = true;
                }
            
                if (playerTwoInput == 0)
                {
                    transform.GetChild(2).transform.position = new Vector3(playerTwo.transform.position.x - 8.0f, playerTwo.transform.position.y + 8.0f, playerTwo.transform.position.z);
                    transform.GetChild(3).transform.position = new Vector3(playerTwo.transform.position.x + 9.0f, playerTwo.transform.position.y + 8.0f, playerTwo.transform.position.z);
                }
                else if (playerTwoInput == 1)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(2).transform.position = new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y + 8.0f, playerTwo.transform.position.z);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
                else if (playerTwoInput == 2)
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                    transform.GetChild(3).transform.position = new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y + 8.0f, playerTwo.transform.position.z);
                    transform.GetChild(2).gameObject.SetActive(false);
                }
            }
            else
            {
                if (playerTwo.GetComponent<SpriteRenderer>().enabled == true)
                {
                    playerTwo.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        
            if (playerOneInput == 0)
            {
                transform.GetChild(0).transform.position = new Vector3(playerOne.transform.position.x - 8.0f, playerOne.transform.position.y + 15.0f, playerOne.transform.position.z);
                transform.GetChild(1).transform.position = new Vector3(playerOne.transform.position.x + 5.0f, playerOne.transform.position.y + 15.0f, playerOne.transform.position.z);
            }
            else if (playerOneInput == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).transform.position = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y + 15.0f, playerOne.transform.position.z);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (playerOneInput == 2)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).transform.position = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y + 15.0f, playerOne.transform.position.z);
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
 
        if (collectedTheOne || PlayerPrefs.GetInt("noOfArtworks", 100) > 100)
        {
            //fade out / fade in screen

            if (doOnce)
            {
                playerTwo.GetComponent<SpriteRenderer>().enabled = true;

                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                
                if (PlayerPrefs.GetInt("noOfArtworks", 100) > 100)
                {
                    colour = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                    gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                }
                else
                {
                    StartCoroutine(WaitASec(true, 1.0f));
                }

                doOnce = false;
            }

            gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetComponent<SpriteRenderer>().color =
            Color.Lerp(gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetComponent<SpriteRenderer>().color, colour, Time.deltaTime);

            if (gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.GetComponent<SpriteRenderer>().color.a >= 0.98f)
            {
                if (colour != new Color(0.000f, 0.000f, 0.000f, 0.000f))
                {
                    StartCoroutine(WaitASec(false, 1.4f));
                }
            }
        }
    }

    private IEnumerator WaitASec(bool firstChange, float time)
    {
        yield return new WaitForSeconds(time);
        
        if (firstChange)
        {
            colour = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else
        {
            colour = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            mainManager.tutorialMode = false;
        }
    }

    private IEnumerator CreateNewKnots()
    {
        yield return new WaitForSeconds(1.0f);

        for (int i = 4; i < gameObject.transform.childCount - 2; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);

            yield return new WaitForSeconds(0.15f);
        }

        yield return new WaitForSeconds(0.60f);

        gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject.SetActive(true);
    }

    public void GetControllerType(int index, string type)
    {
        if (index == 0)
        {
            if (type == "Mouse:/Mouse")
            {
                playerOneInput = 1;
            }
            else
            {
                playerOneInput = 2;
            }
        }
        else if (index == 1)
        {
            if (type == "Keyboard:/Keyboard")
            {
                playerTwoInput = 1;
            }
            else
            {
                playerTwoInput = 2;
            }
        }
    }
}
