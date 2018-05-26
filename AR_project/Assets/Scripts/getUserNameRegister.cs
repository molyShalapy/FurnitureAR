using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getUserNameRegister : MonoBehaviour {

    [SerializeField] Text text;
    public void get_username(string usrname)
    {
        text.text = usrname;
        Debug.Log(text.text);
    }
}
