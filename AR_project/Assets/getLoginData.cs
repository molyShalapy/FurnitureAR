using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getLoginData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    InputField data;

    string username, password;

   public void getData()
    {
        Debug.Log(data.text);
        username = data.text;

        Debug.Log(username);
    }
}
