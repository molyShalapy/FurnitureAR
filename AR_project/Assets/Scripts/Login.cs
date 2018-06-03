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
    public GameObject loadingprefab;
    public GameObject gameObject;
    public GameObject gameObjectPrevious;

    // Use this for initialization
    void Start () {
        loadingprefab.SetActive(false);
        auth = FirebaseAuth.DefaultInstance;
        btnLogin.onClick.AddListener(() => LoginAuth( Email.text, Password.text));

    }
    public void LoginAuth(string email, string password)
    {
        loadingprefab.SetActive(true);
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                ErrorText.enabled = true;
                Debug.LogError("Sign IN now.");
                ErrorText.text = "You can't sign in with this email or password!";
                return;
            }
            if (task.IsFaulted)
            {
                ErrorText.enabled = true;
                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    ErrorText.text = "You can't sign in with this email or password!";

                return;
            }

            FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);
            ErrorText.enabled = false;
            loadingprefab.SetActive(false);
            gameObject.GetComponent<Canvas>().enabled = true;
            gameObjectPrevious.GetComponent<Canvas>().enabled = false;

        });
    }
}
