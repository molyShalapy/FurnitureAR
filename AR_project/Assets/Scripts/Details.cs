﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Details : MonoBehaviour {
    
  

    // Use this for initialization
    void Start ()
    {
        GameObject.Find("txtname").GetComponent<Text>().text = Scrollerview.MyProduct.name;
        GameObject.Find("txtcategory").GetComponent<Text>().text = Scrollerview.MyProduct.category;
        GameObject.Find("txtmodel").GetComponent<Text>().text = Scrollerview.MyProduct.model;
        GameObject.Find("txtId").GetComponent<Text>().text = Scrollerview.MyProduct.id;
        GameObject.Find("txtColor").GetComponent<Text>().text = Scrollerview.MyProduct.color;

    }

   
}
