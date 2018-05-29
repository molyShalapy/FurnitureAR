//using System.Collections;

//using System.Collections.Generic;
//using UnityEngine;
//using Firebase.Auth;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using System;

//using Firebase;
//using Firebase.Database;
//using Firebase.Unity.Editor;

//public class Firebase_script : MonoBehaviour {

//    private FirebaseAuth auth;
//    public InputField F_name,L_name, Email, Password;
//    public Button Create_User, Loginbtn;
//    public Text ErrorText;
//    // Use this for initialization
//    void Start () {
//        Debug.LogError("SignInWithEmailAndPasswordAsync canceled."); 
//        auth = FirebaseAuth.DefaultInstance;
//        FirebaseApp app = FirebaseApp.DefaultInstance;
//        // NOTE: You'll need to replace this url with your Firebase App's database
//        // path in order for the database connection to work correctly in editor.
//        // firbase initialization
//        app.SetEditorDatabaseUrl("https://omar-81d7e.firebaseio.com/");
//        if (app.Options.DatabaseUrl != null)
//        {
//            Debug.LogError("Initialize Success.");

//            // app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
//            // StartListener();
//            // AddUser();
//         //   GetUsers();
//        }
//        else
//        {
//            Debug.LogError("Initialize DataBase error.");

//        }

//        ////Just an example to save typing in the login form
//        F_name.text = "chris";
//        L_name.text = "essam";
//        Email.text = "omaressam96770@gmail.com";
//        Password.text = "123456789";
        
//        Create_User.onClick.AddListener(() => Signup(F_name.text ,L_name.text,Email.text, Password.text ));
//        //Loginbtn.onClick.AddListener(() => Login(Email.text, Password.text));
//        Loginbtn.onClick.AddListener(() => LoginFB());



//    }



//    public void GetUsers()
//    {
//        Firebase.Database.FirebaseDatabase dbInstance = Firebase.Database.FirebaseDatabase.DefaultInstance;
//        dbInstance.GetReference("Leaders").ValueChanged += HandleValueChanged;
//    }

//    void HandleValueChanged(object sender, ValueChangedEventArgs args)
//    {
//        if (args.DatabaseError != null)
//        {
//            Debug.LogError(args.DatabaseError.Message);
//            return;
//        }
//        Debug.LogError(args.Snapshot.Child("name").Value);
//    }
//    //protected virtual void InitializeFirebase()
//    //{
//    //    //FirebaseApp app = FirebaseApp.DefaultInstance;
//    //    //// NOTE: You'll need to replace this url with your Firebase App's database
//    //    //// path in order for the database connection to work correctly in editor.
//    //    //app.SetEditorDatabaseUrl/*("https://omar-81d7e.firebaseio.com*//");
//    //    //if (app.Options.DatabaseUrl != null)
//    //    //{
//    //    //    Debug.LogError("Initialize Success.");

//    //    //    // app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
//    //    //    // StartListener();
//    //    //    // AddUser();
//    //    //    //GetUsers();
//    //    //}
//    //    //else
//    //    //{
//    //    //    Debug.LogError("Initialize DataBase error.");

//    //    //}
//    //}
//    public class User
//    {

//        public string F_name;
//        public string L_name;
//        public string email;
//        public string password;

//        public User(string f_name,string l_name,string email, string password)
//        {
//            this.F_name = f_name;
//            this.L_name = l_name;
//            this.email = email;
//            this.password = password;
//        }
//    }

//    // Update is called once per frame
//    void Update () {
		
//	}


//    public void Signup(string f_name,string l_name,string email, string password)
//    {
//        Debug.LogError("sign up nw.");


//        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
//        {
//            //Error handling
//            return;
//        }


//        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
//        {
//            if (task.IsCanceled)
//            {
//                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
//                return;
//            }
//            if (task.IsFaulted)
//            {
//                Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
//                if (task.Exception.InnerExceptions.Count > 0)
//                    //   UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
//                    return;
//            }

//            FirebaseUser newUser = task.Result; // Firebase user has been created.
//            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
//                newUser.DisplayName, newUser.UserId);
//            Debug.LogError( newUser.UserId);
                
//            // User Create in db
//                Debug.LogError("user added start");

//                User user = new User(f_name,l_name,email, password);
//                string json = JsonUtility.ToJson(user);
//                //Firebase.Database.DatabaseReference dbRef;
//                //DatabaseReference reference;//= FirebaseDatabase.DefaultInstance.GetReference("Leaders");
//                DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");

//                reference.Child(newUser.UserId).SetRawJsonValueAsync(json);
//                Debug.LogError("user added");

            

//            //  UpdateErrorMessage("Signup Success");
//        });
//    }



//    public void Login(string email, string password)
//    {
//        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
//        {
//            if (task.IsCanceled)
//            {
//                Debug.LogError("Sign IN now.");
//                return;
//            }
//            if (task.IsFaulted)
//            {
//                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
//                if (task.Exception.InnerExceptions.Count > 0)
//                  //  UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
//                return;
//            }

//            FirebaseUser user = task.Result;
//            Debug.LogFormat("User signed in successfully: {0} ({1})",
//                user.DisplayName, user.UserId);

//            SceneManager.LoadScene("LoginResults");
//        });
//    }
//}
