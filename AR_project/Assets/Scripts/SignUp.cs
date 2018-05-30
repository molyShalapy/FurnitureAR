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

public class SignUp : MonoBehaviour {

    private FirebaseAuth auth;
    public InputField username, Email, Password;
    public Button btnRegister;
    public Text ErrorText;

    // Use this for initialization
    void Start () {
        auth = FirebaseAuth.DefaultInstance;
        FirebaseApp app = FirebaseApp.DefaultInstance;
       
        app.SetEditorDatabaseUrl("https://ar-v1-ce36f.firebaseio.com/");
        if (app.Options.DatabaseUrl != null)
            Debug.LogError("Initialize Success.");
        else
            Debug.LogError("Initialize DataBase error.");

        btnRegister.onClick.AddListener(() => Signup(username.text, Email.text, Password.text));

    }

    public class User
    {

        public string username;
        public string email;
        public string password;

        public User(string f_name,string email, string password)
        {
            this.username = f_name;
            this.email = email;
            this.password = password;
        }
    }


    public void Signup(string username,string email, string password)
    {
        Debug.LogError("sign up nw.");


        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            //Error handling
            return;
        }


        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                ErrorText.enabled = true;
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                ErrorText.enabled = true;
                Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    //   UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                    return;
            }

            FirebaseUser newUser = task.Result; // Firebase user has been created.
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            Debug.LogError(newUser.UserId);

            // User Create in db
            Debug.LogError("user added start");

            User user = new User(username, email, password);
            string json = JsonUtility.ToJson(user);
          
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");

            reference.Child(newUser.UserId).SetRawJsonValueAsync(json);
            Debug.LogError("user added");
            ErrorText.enabled = false;


            SceneManager.LoadScene("ResultScene");


            //  UpdateErrorMessage("Signup Success");
        });
    }



}
