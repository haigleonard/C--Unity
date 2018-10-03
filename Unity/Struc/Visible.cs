using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible : MonoBehaviour
{
    public string name;
    bool cartoonVis = false;
    bool sphereVis = true;
    bool lineVis = false;
    public Touch touch;
    Renderer rend;
    int count = 1;
    float duration = 5.0f;
    int[] repobjs = new int[3];


    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        string named = this.gameObject.name;
        count = touch.count;
        repobjs = touch.repobjs;
            rend.enabled = false;
            if (repobjs[0] == 1)
            {
                if (name == "sphere")
                {
                    rend.enabled = true;
                }
            }
            if (repobjs[1] == 1)
            {
                if (name == "cartoon")
                {
                    rend.enabled = true;
                }
            }

            if (repobjs[2] == 1)
            {
                if (name == "line")
                {
                    rend.enabled = true;

                }
            }
            
        
    }


    
}


