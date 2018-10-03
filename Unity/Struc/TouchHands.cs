using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHands : MonoBehaviour {
    Vector3 vec;
    int count = 0;
    public OVRInput.Controller Controller;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
            transform.localPosition = OVRInput.GetLocalControllerPosition(Controller);
            transform.localRotation = OVRInput.GetLocalControllerRotation(Controller);
        
    }
}
