using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropBelow : MonoBehaviour {
    //Class to reset grabable objects after dropping off table

    public string cube;
    public int choice = 0; 
    private GameObject GrabbedObject;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < 80)
        {
            if (cube == "mid") { transform.position = new Vector3(-0.03f, 80.95f, -14.45f); choice = 1; }
            if (cube == "left") { transform.position = new Vector3(-0.359f, 80.95f, -14.45f); choice = 2; }
            if (cube == "right") { transform.position = new Vector3(0.275f, 80.95f, -14.45f); choice = 3; }
            if (cube == "sphere") { transform.position = new Vector3(0.009f, 80.921f, -14.656f); choice = 4; }
        }
    }

    
}
