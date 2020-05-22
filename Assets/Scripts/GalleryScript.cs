using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GalleryScript : MonoBehaviour
{
    public float moveSpeed,
                 formatSpeed,
                 time;

    public GameObject[] placeholder = new GameObject[6];

    public GameObject obj0,
                      objMinus50,
                      objPlus50,
                      obj180;

    public bool next,
                prev,
                moving;
    
    private Vector3[] positions = new Vector3[6];

    private List<Sprite> spritesList = new List<Sprite>();

    private Dictionary<string, TextAsset> songsDict = new Dictionary<string, TextAsset>();

    private bool doOnce;
    
    private int rotations,
                gallerySize,
                lastVisible,
                firstVisible;

    private Vector3 smallScale,
                    bigScale;

    private Color bigPictureCol,
                  smallPictureCol;

    private MusicPlayerScript musicPlayerScript;
    
    void Awake()
    {
        string filePath = Application.persistentDataPath;

        int l = 0;

        DirectoryInfo dir = new DirectoryInfo(@filePath);
        FileInfo[] imageFiles = dir.GetFiles("*.png");

        Sprite[] sprites = new Sprite[imageFiles.Length];

        foreach (FileInfo f in imageFiles)
        {
            string fileFPath = Path.Combine(Application.persistentDataPath, f.Name);
            sprites[l] = LoadSprite(fileFPath, f.Name.Substring(0, f.Name.IndexOf(".")));
            
            l++;
        }
        
        int m = 0;

        DirectoryInfo songDir = new DirectoryInfo(@filePath);
        FileInfo[] songFiles = dir.GetFiles("*.txt");

        TextAsset[] songs = new TextAsset[songFiles.Length];

        foreach (FileInfo s in songFiles)
        {
            string fileSPath = Path.Combine(Application.persistentDataPath, s.Name);
            songs[m] = LoadText(fileSPath);
            
            m++;
        }
        
        gallerySize = sprites.Length;

        int differenceToAdd = 7 - gallerySize;

        if (differenceToAdd > 0)
        {
            Sprite[] backUpSprites = new Sprite[6];
            backUpSprites = Resources.LoadAll<Sprite>("BackUp");

            int j = 0;

            while (differenceToAdd > 0)
            {
                spritesList.Add(backUpSprites[j] as Sprite);
                j++;
                differenceToAdd--;
            }
            
            gallerySize = sprites.Length;
        }
        else if (gallerySize % 2 == 0)
        {
            Sprite[] backUpSprites = new Sprite[6];
            backUpSprites = Resources.LoadAll<Sprite>("BackUp");

            spritesList.Add(backUpSprites[1] as Sprite);
        }
        
        for (int k = 0; k < sprites.Length; k++)
        {
            spritesList.Add(sprites[k]);
            songsDict.Add(sprites[k].name, songs[k]);
        }
        
        gallerySize = spritesList.Count;

        placeholder[0].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[gallerySize - (gallerySize - 1)];
        placeholder[1].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[gallerySize - (gallerySize)];
        placeholder[2].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[gallerySize - 1];
        placeholder[3].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[gallerySize - 2];
        placeholder[4].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[gallerySize - 3];
        placeholder[5].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[gallerySize - 4];

        firstVisible = gallerySize - (gallerySize);
        lastVisible = gallerySize - 4;
        
        for (int i = 0; i < 6; i++)
        {
            positions[i] = placeholder[i].transform.position;
        }

        rotations = 0;

        smallScale = new Vector3(3.0f, 3.0f, 1.0f);
        bigScale = new Vector3(4.0f, 4.0f, 1.0f);
        
        smallPictureCol = new Color(0.6f, 0.6f, 0.6f, 1.0f);
        bigPictureCol = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        
        for (int i = 0; i < 6; i++)
        {
            ArrangePictureFormat(i, placeholder[i].transform.position);
        }

        doOnce = true;
        next = false;
        prev = false;
        moving = false;

        musicPlayerScript = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<MusicPlayerScript>();
    }

    private Sprite LoadSprite(string path, string name)
    {
        if (string.IsNullOrEmpty(path))
        {
            return null;
        }
        
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            newSprite.name = name;
            return newSprite;
        }
        
        return null;
    }

    private TextAsset LoadText(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return null;
        }

        if (File.Exists(path))
        {
            TextAsset newText = new TextAsset(File.ReadAllText(path));
            return newText;
        }

        return null;
    }

    void Update()
    {
        if (doOnce)
        {
            for (int i = 0; i < 6; i++)
            {
                Move(i);
                ArrangePictureFormat(i, positions[(i + rotations) % 6]);

                StartCoroutine(FirstArrangement());
            }
        }

        if (next)
        {
            next = false;
            moving = true;

            if (rotations <= 0)
            {
                rotations = 6;
            }

            rotations += -1;
            StartCoroutine(Double(-1));
            
            //THE INDEX OF THE SPRITE ON THE LAST POSITION (5)
            if (lastVisible >= 0)
            {
                lastVisible = lastVisible - 2;
            }

            if (lastVisible == -2)
            {
                lastVisible = gallerySize - 2;
            }

            //THE INDEX OF THE SPRITE ON THE FIRST POSITION (0)
            if (firstVisible >= 0)
            {
                firstVisible = firstVisible - 2;
            }

            if (gallerySize % 2 == 0)
            {
                if (firstVisible < 0)
                {
                    firstVisible = gallerySize - 1;
                }
            }
            else
            {
                if (firstVisible == -1)
                {
                    firstVisible = gallerySize - 1;
                }

                if (firstVisible == -2)
                {
                    firstVisible = gallerySize - 2;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (placeholder[i].transform.position == positions[0])
                {
                    placeholder[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[lastVisible + 1];

                    if (lastVisible < 0)
                    {
                        lastVisible = gallerySize - 1;

                        if(lastVisible < -1)
                        {
                            firstVisible = firstVisible - 1;
                        }
                    }

                    placeholder[(i + 1) % 6].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[lastVisible];

                    break;
                }
            }
        }

        if (prev)
        {
            prev = false;
            moving = true;

            rotations += 1;
            StartCoroutine(Double(+1));

            //THE INDEX OF THE SPRITE ON THE FIRST POSITION (0)
            if (firstVisible <= gallerySize - 1)
            {
                firstVisible = firstVisible + 2;
            }
            
            if (firstVisible == gallerySize + 1)
            {
                firstVisible = 1;
            }

            if (firstVisible == gallerySize)
            {
                firstVisible = 0;
            }

            //THE INDEX OF THE SPRITE ON THE LAST POSITION (5)
            if (lastVisible <= gallerySize - 1)
            {
                lastVisible = lastVisible + 2;
            }

            if (gallerySize % 2 == 0)
            {
                if (lastVisible > gallerySize - 1)
                {
                    lastVisible = 0;
                }
            }
            else
            {
                if (lastVisible == gallerySize)
                {
                    lastVisible = 0;
                }

                if (lastVisible == gallerySize + 1)
                {
                    lastVisible = 1;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                if (placeholder[i].transform.position == positions[5])
                {
                    placeholder[i % 6].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[firstVisible];

                    if (firstVisible > gallerySize - 2)
                    {
                        firstVisible = -1;

                        if (firstVisible > gallerySize - 1)
                        {
                            lastVisible = lastVisible + 1;
                        }
                    }

                    placeholder[(i - 1) % 6].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = spritesList[firstVisible + 1];

                    break;
                }
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (placeholder[i].transform.position != positions[(i + rotations) % 6])
            {
                Move(i);
                ArrangePictureFormat(i, positions[(i + rotations) % 6]);
            }
            else
            {
                if (i == 5)
                {
                    moving = false;
                }
            }
        }
    }

    private void ArrangePictureFormat(int i, Vector3 nextPos)
    {
        if (nextPos == positions[0] || nextPos == positions[1] || nextPos == positions[4] || nextPos == positions[5])
        {
            placeholder[i].transform.localScale = Vector3.Lerp(placeholder[i].transform.localScale, smallScale, Time.deltaTime * formatSpeed);
            placeholder[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(placeholder[i].GetComponent<SpriteRenderer>().color, smallPictureCol, Time.deltaTime * formatSpeed * 10);

            if (nextPos == positions[0])
            {
                Vector3 targetDirection = obj180.transform.position - placeholder[i].transform.position;
                Vector3 newDirection = Vector3.RotateTowards(placeholder[i].transform.forward, targetDirection, Time.deltaTime * formatSpeed / 4.0f, 0.0f);
                placeholder[i].transform.rotation = Quaternion.LookRotation(newDirection);
                placeholder[i].layer = 0;
            }
            else if (nextPos == positions[1])
            {
                Vector3 targetDirection = objPlus50.transform.position - placeholder[i].transform.position;
                Vector3 newDirection = Vector3.RotateTowards(placeholder[i].transform.forward, targetDirection, Time.deltaTime * formatSpeed / 4.0f, 0.0f);
                placeholder[i].transform.rotation = Quaternion.LookRotation(newDirection);
                placeholder[i].layer = 0;
            }
            else if (nextPos == positions[4])
            {
                Vector3 targetDirection = objMinus50.transform.position - placeholder[i].transform.position;
                Vector3 newDirection = Vector3.RotateTowards(placeholder[i].transform.forward, targetDirection, Time.deltaTime * formatSpeed / 4.0f, 0.0f);
                placeholder[i].transform.rotation = Quaternion.LookRotation(newDirection);
                placeholder[i].layer = 0;
            }
            else if (nextPos == positions[5])
            {
                Vector3 targetDirection = obj180.transform.position - placeholder[i].transform.position;
                Vector3 newDirection = Vector3.RotateTowards(placeholder[i].transform.forward, targetDirection, Time.deltaTime * formatSpeed / 4.0f, 0.0f);
                placeholder[i].transform.rotation = Quaternion.LookRotation(newDirection);
                placeholder[i].layer = 0;
            }
        }

        else if (nextPos == positions[2] || nextPos == positions[3])
        {
            placeholder[i].transform.localScale = Vector3.Lerp(placeholder[i].transform.localScale, bigScale, Time.deltaTime * formatSpeed);
            placeholder[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(placeholder[i].GetComponent<SpriteRenderer>().color, bigPictureCol, Time.deltaTime * formatSpeed * 10);

            if (nextPos == positions[2])
            {
                Vector3 targetDirection = obj0.transform.position - placeholder[i].transform.position;
                Vector3 newDirection = Vector3.RotateTowards(placeholder[i].transform.forward, targetDirection, Time.deltaTime * formatSpeed / 4.0f, 0.0f);
                placeholder[i].transform.rotation = Quaternion.LookRotation(newDirection);
                placeholder[i].layer = 8;
            }
            else if (nextPos == positions[3])
            {
                Vector3 targetDirection = obj0.transform.position - placeholder[i].transform.position;
                Vector3 newDirection = Vector3.RotateTowards(placeholder[i].transform.forward, targetDirection, Time.deltaTime * formatSpeed / 4.0f, 0.0f);
                placeholder[i].transform.rotation = Quaternion.LookRotation(newDirection);
                placeholder[i].layer = 8;
            }
        }
    }
    
    public void Move(int i)
    {
        placeholder[i].transform.position = Vector3.MoveTowards(placeholder[i].transform.position, positions[(i + rotations) % 6], Time.deltaTime * moveSpeed);
    }

    public void PlayThisSong(GameObject song)
    {
        musicPlayerScript.musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musicPlayerScript.enabled = false;

        string artwork = song.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.name;

        //string songPath = Application.dataPath + "/Resources/Artwork/" + artwork + ".txt";

        musicPlayerScript.songFile = songsDict[artwork];

        //musicPlayerScript.path = songPath;
        StartCoroutine(Wait());
    }

    private IEnumerator Double(int x)
    {
        yield return new WaitForSeconds(time);

        rotations += x;
    }

    private IEnumerator FirstArrangement()
    {
        yield return new WaitForSeconds(1.0f);

        doOnce = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        
        musicPlayerScript.enabled = true;
    }
}
