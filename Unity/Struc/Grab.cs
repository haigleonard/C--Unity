using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {
    // grab, drop class for objects, just assign to the object itself
    public float grabRadius;
    public LayerMask grabMask;
    public OVRInput.Controller controller;
    public string buttonName;
    private GameObject GrabbedObject;
    private bool grabbing;
    
	// Use this for initialization
	void Start () {
		
	}

    void GrabObject()
    {
        grabbing = true;
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);

        if(hits.Length > 0)
        {
            int closestHit = 0;
            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i].distance > hits[closestHit].distance) closestHit = 1;
            }

            GrabbedObject = hits[closestHit].transform.gameObject;
            GrabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            GrabbedObject.transform.position = transform.position;
            GrabbedObject.transform.parent = transform;
        }

    }
	void DropObject()
    {
        grabbing = false;

        if(GrabbedObject != null)
        {
            GrabbedObject.transform.parent = null;
            GrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            GrabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(controller);
            GrabbedObject = null;
        }
    }

	// Update is called once per frame
	void Update () {
		if(!grabbing && Input.GetAxis(buttonName) == 1)
        {
            GrabObject();
        }
        if(grabbing && Input.GetAxis(buttonName) < 1)
        {
            DropObject();
        }

    }
}
