using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMenuState : MonoBehaviour {

    Animator m_Animator;
    bool MenuIsShown;

    // Use this for initialization
    void Start () {
        m_Animator = gameObject.GetComponent<Animator>();
        MenuIsShown = false;
    }
	
	// Update is called once per frame
	void Update () {

    }
    public void Show()
    {
        MenuIsShown = !MenuIsShown;
        if (MenuIsShown == false)
            m_Animator.SetBool("MenuIsShown", false);

        if (MenuIsShown == true)
            m_Animator.SetBool("MenuIsShown", true);

    }
}
