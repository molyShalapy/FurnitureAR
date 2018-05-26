using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getEmailRegister : MonoBehaviour {

    [SerializeField] Text text;
    public void get_email(string email)
    {
        text.text = email;
        Debug.Log(text.text);
    }
}
