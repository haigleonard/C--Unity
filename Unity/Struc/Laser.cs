using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    //class to render beam, simply a very long object
    Renderer rend;
    bool laser = false;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire3") && laser == false)
        {
            rend.enabled = true;
            laser = true;
        }
        else if (Input.GetButtonUp("Fire3") && laser == true)
        {
            rend.enabled = false;
            laser = false;
        }
    }
}
