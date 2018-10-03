﻿using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Update is called once per frame
    void Update () {

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        //move camera

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
}
