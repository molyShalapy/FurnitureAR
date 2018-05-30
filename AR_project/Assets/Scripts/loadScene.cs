using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public string openScene;
    public void LoadResultScene( )
    {
        Debug.Log(openScene);
        SceneManager.LoadSceneAsync(openScene);
        

    }
}
