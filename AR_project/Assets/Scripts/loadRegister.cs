using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class loadRegister : MonoBehaviour {

    // Use this for initialization
    public void LoadRegisterScene()
    {
        Debug.Log("loaded");
       Application.LoadLevel("RegistrationScene");
    }
}
