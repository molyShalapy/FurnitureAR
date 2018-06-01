using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
public class share : MonoBehaviour {
    Texture2D screenshotTexture;
    byte[] data;
    public   GameObject screenshotPreview;
    public Button Share_btn;
    // Use this for initialization
    private void Awake()
    {
        //Login_btn.onClick.AddListener(() => LogIn());
        Share_btn.onClick.AddListener(() => ShareBtn());

        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }
    public void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
            Debug.LogError("Succedd");
            
        }
        else
        {
            Debug.LogError("Failed to Initialize the Facebook SDK");
        }
    }
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
    public void ShareBtn()
    {
        FB.ShareLink(
 new System.Uri("https://developers.facebook.com/"), "Good porgram", "check it out"

);
    }
}
