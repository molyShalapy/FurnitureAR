using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    private FirebaseAuth auth;
    public InputField Email, Password;
    public Button btnLogin, fbLogin;
    public Text ErrorText;
    // Use this for initialization
    void Start () {
        auth = FirebaseAuth.DefaultInstance;
        btnLogin.onClick.AddListener(() => LoginAuth( Email.text, Password.text));

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void LoginAuth(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("Sign IN now.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    //  UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                    return;
            }

            FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);

            SceneManager.LoadScene("ResultScene");
        });
    }
}
