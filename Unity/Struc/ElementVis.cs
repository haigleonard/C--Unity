using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementVis : MonoBehaviour {

    public string name;
    public Touch touch;
    Renderer rend;
    float duration = 5.0f;
    int[] objs = new int[10];
    int[] objs2 = new int[10];
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        objs = touch.eleobjs; //from touch
        objs2 = touch.eleobjs2; //from touch
        rend.enabled = false; // sets all to render.off

        if (objs[0] == 1)// only renders.true if the script its attaached to is correct one
        {
            if (name == "H")
            {
                rend.enabled = true;
            }
        }
        if (objs[1] == 1)
        {
            if (name == "C")
            {
                rend.enabled = true;
            }
        }
        if (objs[2] == 1)
        {
            if (name == "N")
            {
                rend.enabled = true;
            }
        }
        if (objs[3] == 1)
        {
            if (name == "O")
            {
                rend.enabled = true;
            }
        }
        if (objs[4] == 1)
        {
            if (name == "S")
            {
                rend.enabled = true;
            }
        }
        if (objs[5] == 1)
        {
            if (name == "P")
            {
                rend.enabled = true;
            }
        }
        if (objs[6] == 1)
        {
            if (name == "Mg")
            {
                rend.enabled = true;
            }
        }
        if (objs[7] == 1)
        {
            if (name == "Ti")
            {
                rend.enabled = true;
            }
        }
        if (objs[8] == 1)
        {
            if (name == "Zn")
            {
                rend.enabled = true;
            }
            
        }
        if (objs[9] == 1)
        {
            if (name == "Se")
            {
                rend.enabled = true;
            }
        }
        if (objs2[0] == 1)
        {
            if (name == "I")
            {
                rend.enabled = true;
            }
        }
        if (objs2[1] == 1)
        {
            if (name == "Na")
            {
                rend.enabled = true;
            }
        }
    }
}
