using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class finaltoggle : MonoBehaviour {

    public ToggleGroup tg;
    public GameObject obj;
    // Use this for initialization
  public  void Start () {
        Toggle toggle = tg.ActiveToggles().First();
        obj.GetComponent<Renderer>().material.color = ToColor(toggle.tag);
    }

  

    public Color ToColor(string color)
    {
        return (Color)typeof(Color).GetProperty(color.ToLowerInvariant()).GetValue(null, null);
    }
}
