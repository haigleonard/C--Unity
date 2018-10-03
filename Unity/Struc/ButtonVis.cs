using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVis : MonoBehaviour {
    //Class to light Touch buttons up on touch
    public GameObject A;
    public GameObject B;
    public GameObject Rstick;
    public GameObject X;
    public GameObject Y;
    public GameObject Lstick;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("leftAnalogeTouch"))
        {
            Lstick.GetComponent<Renderer>().material.color = Color.white;
        }
        else { Lstick.GetComponent<Renderer>().material.color = Color.gray; }
        if (Input.GetButton("rightAnalogeTouch"))
        {
            Rstick.GetComponent<Renderer>().material.color = Color.white;
        }
        else { Rstick.GetComponent<Renderer>().material.color = Color.gray; }
        if (Input.GetButton("ATouch"))
        {
            A.GetComponent<Renderer>().material.color = Color.white;
        }
        else { A.GetComponent<Renderer>().material.color = Color.gray; }
        if (Input.GetButton("BTouch"))
        {
            B.GetComponent<Renderer>().material.color = Color.white;
        }
        else { B.GetComponent<Renderer>().material.color = Color.gray; }
        if (Input.GetButton("XTouch"))
        {
            X.GetComponent<Renderer>().material.color = Color.white;
        }
        else { X.GetComponent<Renderer>().material.color = Color.gray; }
        if (Input.GetButton("YTouch"))
        {
            Y.GetComponent<Renderer>().material.color = Color.white;
        }
        else { Y.GetComponent<Renderer>().material.color = Color.gray; }
    } 
}
