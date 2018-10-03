using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRotation : MonoBehaviour {
    public GameObject cam;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 playerPos = cam.transform.position;
        transform.localPosition = playerPos;
        
	}
}
