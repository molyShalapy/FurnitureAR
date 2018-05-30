using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capture : MonoBehaviour {

	
    public void capturePic()
    {
        Debug.Log("Captured");
        ScreenCapture.CaptureScreenshot( "$screenShote{DateTime.Now}.png",3);
        //SceneManager.LoadSceneAsync();
    }
}
