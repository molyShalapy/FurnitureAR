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

            //var perms = new List<string>() { "public_profile", "email" };
            //FB.LogInWithReadPermissions(perms, AuthCallback);
            //if (FB.IsLoggedIn)
            //{
            //    Debug.LogError("da5al tmam");

            //    // AccessToken class will have session details
            //    var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            //    // Print current access token's User ID
            //    Debug.Log(aToken.UserId);
            //    // Print current access token's granted permissions
            //    foreach (string perm in aToken.Permissions)
            //    {
            //        Debug.Log(perm);
            //    }
            //}
            //else
            //{
            //    Debug.LogError("User cancelled login");
            //}
        }
        else
        {
            Debug.LogError("Failed to Initialize the Facebook SDK");
        }
    }
   

//public void AuthCallback(ILoginResult result)
//    {
//        if (FB.IsLoggedIn)
//        {
//            Debug.LogError("da5al tmam");

//            // AccessToken class will have session details
//            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
//            // Print current access token's User ID
//            Debug.Log(aToken.UserId);
//            // Print current access token's granted permissions
//            foreach (string perm in aToken.Permissions)
//            {
//                Debug.Log(perm);
//            }
//        }
//        else
//        {
//            Debug.Log("User cancelled login");
//        }
//    }

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
    //        Firebase.Auth.Credential credential =
    //Firebase.Auth.FacebookAuthProvider.GetCredential(token+"");
    //        auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
    //            if (task.IsCanceled)
    //            {
    //                Debug.LogError("SignInWithCredentialAsync was canceled.");
    //                return;
    //            }
    //            if (task.IsFaulted)
    //            {
    //                Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
    //                return;
    //            }

    //            Firebase.Auth.FirebaseUser newUser = task.Result;
    //            Debug.LogFormat("User signed in successfully: {0} ({1})",
    //                newUser.DisplayName, newUser.UserId);
    //        userIdText.text =  newUser.UserId;
					
    //        });
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
        FB.ShareLink(
 new System.Uri("https://developers.facebook.com/"),"Good porgram","check it out"

);
    }
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
