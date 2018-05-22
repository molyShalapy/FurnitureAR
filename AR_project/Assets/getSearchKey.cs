using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getSearchKey : MonoBehaviour {

    [SerializeField] Text text;
    public void get_word(string searchKW)
    {
        text.text = searchKW;
        Debug.Log(text.text);
    }
}
