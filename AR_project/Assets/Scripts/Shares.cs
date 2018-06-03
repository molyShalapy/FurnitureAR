using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System;
using Firebase.Auth;
using Firebase;
//using Firebase.Auth.FacebookAuthProvider;
public class Shares : MonoBehaviour {

    public Text userIdText;
    public Button Login_btn ,Share_btn ;

    void Awake()
    {
    Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	
       // userIdText.Text = "";
        Login_btn.onClick.AddListener(() => LogIn());
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
   

    public void LogIn()
    {
        FB.LogInWithReadPermissions(callback:OnLogIn); 
    }
    private void OnLogIn(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
    Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
		
            AccessToken token = AccessToken.CurrentAccessToken;
 
            Debug.LogError("User sign tmam");

        }
    }

    public void ShareBtn()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback);
        }
        FB.ShareLink(new System.Uri("https://developers.facebook.com/"),"Good porgram","check it out");
    }
 
}
