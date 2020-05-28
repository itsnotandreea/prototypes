using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public bool collectedTheOne;

    public GameObject firstScreen,
                      secondScreen;

    private int playerOneInput,
                playerTwoInput;

    private bool doOnce,
                 firstScreensDone,
                 changeScale,
                 changeColour,
                 changeHeadphonesColour,
                 headphonesFadeIn,
                 headphonesFadeOut,
                 headphonesBackgroundFadeOut;

    private float speed;

    private Color colour;

    private GameObject playerTwo,
                       playerOne,
                       cam;

    private MainManager mainManager;

    private PlayerOneScript pOneScript;
    
    void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");

        mainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<MainManager>();

        pOneScript = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<PlayerOneScript>();

        playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");

        collectedTheOne = false;

        playerOneInput = 0;
        playerTwoInput = 0;

        colour = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        doOnce = true;

        firstScreensDone = false;

        headphonesBackgroundFadeOut = false;
        headphonesFadeIn = false;
        headphonesFadeOut = false;
        changeHeadphonesColour = false;
        changeScale = false;
        changeColour = false;
        StartCoroutine(FirstScreens());
    }
    
    void Update()
    {
        if (firstScreen != null)
        {
            firstScreen.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, firstScreen.transform.position.z);
            firstScreen.transform.rotation = cam.transform.rotation;
        }

        if (secondScreen != null)
        {
            secondScreen.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, secondScreen.transform.position.z);
            secondScreen.transform.rotation = cam.transform.rotation;
        }

        if (pOneScript.canTakeInput && !firstScreensDone)
        {
            pOneScript.canTakeInput = false;
        }
        else if (!pOneScript.canTakeInput && firstScreensDone)
        {
            pOneScript.canTakeInput = true;
        }

        if (doOnce)
        {
            if (playerOne.GetComponent<PlayerOneScript>().connectedOne == true)
            {
                if (playerTwo.GetComponent<SpriteRenderer>().enabled == false)
                {
                    transform.GetChild(2).transform.position = new Vector3(playerTwo.transform.position.x - 5.0f, playerTwo.transform.position.y + 8.0f, playerTwo.transform.position.z);
                    transform.GetChild(3).transform.position = new Vector3(playerTwo.transform.position.x + 5.0f, playerTwo.transform.position.y + 8.0f, playerTwo.transform.position.z);

                    StartCoroutine(CreateNewKnots());

                    playerTwo.transform.position = new Vector3(-37.0f, 250.0f, 0.0f);
                    playerTwo.GetComponent<SpriteRenderer>().enabled = true;
                }
            
                if (playerTwoInput == 0)
                {
                    transform.GetChild(2).transform.position = new Vector3(playerTwo.transform.position.x - 5.0f, playerTwo.transform.position.y + 10.0f, -1.0f);
                    transform.GetChild(3).transform.position = new Vector3(playerTwo.transform.position.x + 5.0f, playerTwo.transform.position.y + 10.0f, -1.0f);
                }
                else if (playerTwoInput == 1)
                {
                    transform.GetChild(2).gameObject.SetActive(true);
                    transform.GetChild(2).transform.position = new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y + 10.0f, -1.0f);
                    transform.GetChild(3).gameObject.SetActive(false);
                }
                else if (playerTwoInput == 2)
                {
                    transform.GetChild(3).gameObject.SetActive(true);
                    transform.GetChild(3).transform.position = new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y + 10.0f, -1.0f);
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
                transform.GetChild(0).transform.position = new Vector3(playerOne.transform.position.x - 5.0f, playerOne.transform.position.y + 10.0f, -1.0f);
                transform.GetChild(1).transform.position = new Vector3(playerOne.transform.position.x + 3.0f, playerOne.transform.position.y + 10.0f, -1.0f);
            }
            else if (playerOneInput == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(0).transform.position = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y + 10.0f, -1.0f);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else if (playerOneInput == 2)
            {
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(1).transform.position = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y + 10.0f, -1.0f);
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
 
        if (collectedTheOne)
        {
            //fade out / fade in screen

            if (doOnce)
            {
                playerTwo.GetComponent<SpriteRenderer>().enabled = true;

                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                
                if (mainManager.tutorial != 0)
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

        if (headphonesBackgroundFadeOut)
        {
            SpriteRenderer spriteRen0 = secondScreen.GetComponent<SpriteRenderer>();

            spriteRen0.color = Color.Lerp(spriteRen0.color, new Color(spriteRen0.color.r, spriteRen0.color.g, spriteRen0.color.b, 0.0f), Time.deltaTime * 4f);
        }

        if (headphonesFadeIn)
        {
            SpriteRenderer spriteRen2 = secondScreen.transform.GetChild(0).gameObject.transform.GetComponent<SpriteRenderer>();
            
            spriteRen2.color = Color.Lerp(spriteRen2.color, new Color(spriteRen2.color.r, spriteRen2.color.g, spriteRen2.color.b, 1.0f), Time.deltaTime * 0.5f);
            
            if (spriteRen2.color.a > 0.98f || headphonesFadeOut)
            {
                headphonesFadeIn = false;
            }
        }

        if (headphonesFadeOut)
        {
            SpriteRenderer spriteRen2 = secondScreen.transform.GetChild(0).gameObject.transform.GetComponent<SpriteRenderer>();
            
            spriteRen2.color = Color.Lerp(spriteRen2.color, new Color(spriteRen2.color.r, spriteRen2.color.g, spriteRen2.color.b, 0.0f), Time.deltaTime * 4.0f);

            if (spriteRen2.color.a <= 0.05f)
            {
                secondScreen.transform.GetChild(0).gameObject.transform.GetComponent<SpriteRenderer>().color = new Color(spriteRen2.color.r, spriteRen2.color.g, spriteRen2.color.b, 0.0f);
                headphonesFadeOut = false;
            }
        }

        if (changeHeadphonesColour)
        {
            SpriteRenderer spriteRen = secondScreen.GetComponent<SpriteRenderer>();

            spriteRen.color = Color.Lerp(spriteRen.color, new Color(0.1607843f, 0.2196079f, 0.2392157f, 1.0f), Time.deltaTime * 1.0f);
        }

        if (changeScale)
        {
            firstScreen.transform.localScale = Vector3.Lerp(firstScreen.transform.localScale, new Vector3(270.0f, 270.0f, 1.0f), Time.deltaTime * speed);
            
            if (speed < 0.2)
            {
                speed = speed + Time.deltaTime * 0.025f;
            }
            
            if (firstScreen.transform.localScale.x > 250.0f)
            {
                changeScale = false;
            }
        }

        if (changeColour)
        {
            SpriteRenderer spriteRen = firstScreen.GetComponent<SpriteRenderer>();
            
            spriteRen.color = Color.Lerp(spriteRen.color, new Color(spriteRen.color.r, spriteRen.color.g, spriteRen.color.b, 0.0f), Time.deltaTime * 0.5f);
            
            if (spriteRen.color.a < 0.4f && !firstScreensDone)
            {
                firstScreensDone = true;
            }

            if (spriteRen.color.a < 0.01f)
            {
                changeColour = false;
                changeScale = false;
                
                Destroy(firstScreen);
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

            if (i > 5)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
            }
            
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

    private IEnumerator FirstScreens()
    {
        headphonesFadeIn = true;
        changeHeadphonesColour = true;

        yield return new WaitForSeconds(4.0f);

        headphonesFadeOut = true;

        yield return new WaitForSeconds(0.5f);

        headphonesBackgroundFadeOut = true;

        yield return new WaitForSeconds(0.5f);

        headphonesBackgroundFadeOut = false;
        changeHeadphonesColour = false;
        Destroy(secondScreen);

        yield return new WaitForSeconds(1.5f);
        
        if (mainManager.tutorial != 0)
        {
            collectedTheOne = true;
        }

        speed = 0.01f;

        changeScale = true;
        
        yield return new WaitForSeconds(1.0f);
        
        changeColour = true;
    }
}
