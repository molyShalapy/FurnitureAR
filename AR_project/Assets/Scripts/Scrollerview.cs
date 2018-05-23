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
            // Create new instances of our prefab until we've created as many as we specified
            newObj = (GameObject)Instantiate(prefab, transform);

            // Randomize the color of our image
          //  newObj.GetComponent().color = Random.ColorHSV();
        }

    }

}
