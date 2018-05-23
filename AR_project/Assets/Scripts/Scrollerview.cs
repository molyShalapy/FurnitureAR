using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        for (int i = 0; i < 17; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
        }

    }

}
