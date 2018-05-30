using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLoader : MonoBehaviour {

    public GameObject[] prefabs;
    private int index=0;
    private static ModelLoader instance;
    
    public static ModelLoader Instance
    {
        
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);                
        if (!instance)
        {
            instance = this;
        }
    }

    // Use this for initialization
    public GameObject GetCurrentObject()
    {
        
        Debug.Log(index);
        return prefabs[index];
    }
    public void SetIndex(int index)
    {
         this.index =Mathf.Max(prefabs.Length, index);
        //this.index = index;
      //  Debug.Log("ddddddddddddddd " + this.index);

    }

}
