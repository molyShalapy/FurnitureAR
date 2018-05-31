using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class share : MonoBehaviour {
    Texture2D screenshotTexture;
    byte[] data;
    public   GameObject screenshotPreview;
    // Use this for initialization
    void Start () {

        data = File.ReadAllBytes(capture.imageName);
        Debug.Log("image" + data);
        screenshotTexture = new Texture2D(Screen.width, Screen.height);
        Debug.Log(data);
        screenshotTexture.LoadImage(data);

        // Create a sprite
        Sprite screenshotSprite = Sprite.Create(screenshotTexture, new Rect(0, 0, Screen.width, Screen.height), new Vector2(0.5f, 0.5f));

        // Set the sprite to the screenshotPreview
        screenshotPreview.GetComponent<Image>().sprite = screenshotSprite;
    }
	
}
