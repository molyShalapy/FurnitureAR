using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Auth : MonoBehaviour {

    private FirebaseAuth auth;
    public InputField F_name, L_name, Email, Password;
    public Button Create_User, Loginbtn;
    public Text ErrorText;
    // Use this for initialization
    void Start()
    {
        Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
        auth = FirebaseAuth.DefaultInstance;
   

        //////Just an example to save typing in the login form
        //F_name.text = "chris";
        //L_name.text = "essam";
        //Email.text = "omaressam96770@gmail.com";
        //Password.text = "123456789";

        //Create_User.onClick.AddListener(() => Signup(F_name.text, L_name.text, Email.text, Password.text));
        //Loginbtn.onClick.AddListener(() => Login(Email.text, Password.text));



    }
   
   

    
  
}
