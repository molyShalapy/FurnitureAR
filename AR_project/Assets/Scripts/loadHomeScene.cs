using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadHomeScene : MonoBehaviour {

    public void LoadHomeScene()
    {
        Debug.Log("loaded");
        Application.LoadLevel("SideMenueScrene");
    }
}
