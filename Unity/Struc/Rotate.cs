using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    //rotates structure assigned
    public float turnSpeed = 50f;
    float scale = 0;
    float shrinkSpeed = 0.05f;
    // Use this for initialization
    void Start () {
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;
    }
	
	// Update is called once per frame
	void Update () {
        

        if (Input.GetAxis("leftTrigger") == 1)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("rightTrigger") == 1)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("leftTrigger2") == 1)
        {
            transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("rightTrigger2") == 1)
        {
            transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);
        }
        
        // beta
        if (Input.GetButton("leftAnalogeBut"))
        {
            scale-= 0.0005f;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.05f, 0.05f, 0.05f), Time.deltaTime * 1.0f);
        }
        if (Input.GetButton("rightAnalogeBut"))
        {
            scale+=0.0005f;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(5.0f, 5.0f, 5.0f), Time.deltaTime * shrinkSpeed);
        }
        //
    }

    void HandleTouchHandler(object sender, System.EventArgs e)
    {

        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Down)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        }
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Up)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        }
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Right)
        {
            transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);

        }
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Left)
        {
            transform.Rotate(Vector3.right, -turnSpeed * Time.deltaTime);

        }
    }
}
