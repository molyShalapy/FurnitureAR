using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scrollerview : MonoBehaviour {

    public GameObject prefab;

    void Start () {
        Populate();
    }
	
	void Update () {
		
	}

    void Populate()
    {
        GameObject newObj;

        List<GameObject> obs = new List<GameObject>();
        for (int t = 0; t < 17; t++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
           var button=newObj.transform.GetComponentInChildren<Button>();
            button.onClick.AddListener(OnPointerClick);
        }
    }
    public void OnPointerClick( )
    {

        Debug.Log("loaded");
        // Application.LoadLevel("ProductDetailsScreen");

        SceneManager.LoadScene("ProductDetailsScreen");//, LoadSceneMode.Additive);

        //SceneManager.UnloadSceneAsync("ResultScene");

    }

}
