using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getPwdRegister : MonoBehaviour {

    [SerializeField] Text text;
    public void get_pwd(string pwd)
    {
        text.text = pwd;
        Debug.Log(text.text);
    }
}
