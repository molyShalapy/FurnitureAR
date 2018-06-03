using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadCanvas : MonoBehaviour {

    public GameObject gameObject;
    public GameObject gameObjectPrevious;
    public void loadCertainCanvas()
    {
        Debug.Log("Loading canvas");
            gameObject.GetComponent<Canvas>().enabled = true;
     gameObjectPrevious.GetComponent<Canvas>().enabled = false;


}
}

