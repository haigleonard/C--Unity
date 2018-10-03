using UnityEngine;
using System.Collections;

public class MenuSelection : MonoBehaviour {
    //??????
	// Use this for initialization
	void Start () {
	
	}

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,transform.forward*1000);

        Ray ray = new Ray(transform.position, transform.forward*1000);

        if(Physics.Raycast(ray, out hit, 5f))
        {
            if(hit.collider.tag == "start")
            {
                print("asd");
            }
        }
    }
}
