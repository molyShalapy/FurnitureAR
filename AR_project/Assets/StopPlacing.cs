using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopPlacing : MonoBehaviour {
    private float dist;
    private bool dragging = false;
    private Vector3 offset;
    private Transform toDrag;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("PlaneFinder").SetActive(false);
    }
    //private void OnMouseDown()
    //{
    //   // this.gameObject.SetActive(false);
    //}
    //void Update()
    //{
    //    Vector3 v3;

    //    if (Input.touchCount != 1)
    //    {
    //        dragging = false;
    //        return;
    //    }

    //    Touch touch = Input.touches[0];
    //    Vector3 pos = touch.position;

    //    if (touch.phase == TouchPhase.Began)
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(pos);
    //        if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Player"))
    //        {
    //            Debug.Log("Here");
    //            toDrag = hit.transform;
    //            dist = hit.transform.position.z - Camera.main.transform.position.z;
    //            v3 = new Vector3(pos.x, pos.y, dist);
    //            v3 = Camera.main.ScreenToWorldPoint(v3);
    //            offset = toDrag.position - v3;
    //            dragging = true;
    //        }
    //    }
    //    if (dragging && touch.phase == TouchPhase.Moved)
    //    {
    //        v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
    //        v3 = Camera.main.ScreenToWorldPoint(v3);
    //        toDrag.position = v3 + offset;
    //    }
    //    if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
    //    {
    //        dragging = false;
    //    }
    //}
    ////private void OnMouseDrag()
    ////{
    ////}

}
