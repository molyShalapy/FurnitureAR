using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollerview : MonoBehaviour {

    public GameObject prefab;

    // Use this for initialization
    void Start () {
        Populate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Populate()
    {
        GameObject newObj; // Create GameObject instance

        for (int i = 0; i < 12; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
        }

    }

}
