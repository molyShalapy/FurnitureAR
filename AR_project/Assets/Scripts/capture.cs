using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;

public class capture : MonoBehaviour {


    public static string imageName = "screenshot.png";

    public void capturePic()
    {
        Debug.Log("Captured");
        ScreenCapture.CaptureScreenshot(imageName);
        SceneManager.LoadScene("share");


    }
}
