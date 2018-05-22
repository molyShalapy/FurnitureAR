using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadScene : MonoBehaviour {

    public void LoadResultScene()
    {
        Debug.Log("loaded");
        Application.LoadLevel("ResultScene");
    }
}
