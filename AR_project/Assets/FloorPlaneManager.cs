using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlaneManager : MonoBehaviour {
    public LayerMask layerMask;
//<<<<<<< HEAD
   
//=======
//    void Start()
//    {

//    }
//>>>>>>> 3811dd31989c61717040fe07dbe538aab636215b
    Lean.Touch.LeanScale current;
    public void OnHeld()
    {
        Ray ray = new Ray(Camera.main.transform.position,Camera.main.transform.forward);
        RaycastHit  hit;
        if (Physics.Raycast(ray,out hit,200,layerMask)) {
            if (current)
            {
                current.enabled = false;
            }
            current =hit.collider.GetComponent<Lean.Touch.LeanScale>();
            current.enabled = true;

        }
        else
        {
            current.enabled = false;

            current = null;

        }
    }

}
