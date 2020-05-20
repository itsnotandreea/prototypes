using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
    private static TakePicture instance;

    private Camera cam;

    private bool takeScreenshotOnNextFrame;

    private MainManager mainManager;

    private void Awake()
    {
        mainManager = GameObject.FindGameObjectWithTag("MainManager").GetComponent<MainManager>();

        instance = this;
        cam = GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = cam.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            string path = Application.dataPath + "/Resources/Artwork/Art" + mainManager.gallerySize + ".png";
            System.IO.File.WriteAllBytes(path, byteArray);
            Debug.Log("Saved CameraScreenshot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            cam.targetTexture = null;
        }
    }
    
    private void TakeScreenshot(int width, int height)
    {
        cam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }
}
