using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedVis : MonoBehaviour {
    //
    public string name;
    public Touch touch;
    Renderer rend;
    float duration = 5.0f;
    int[] resobjs = new int[10];
    int[] resobjs2 = new int[10];
    int[] resobjs3 = new int[2];
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        resobjs = touch.resobjs;//from touch
        resobjs2 = touch.resobjs2;//from touch
        resobjs3 = touch.resobjs3;//from touch
        rend.enabled = false;// sets all to render.off

        if (resobjs[0] == 1)// only renders.true if the script its attaached to is correct one
        {
            if (name == "AGS")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[1] == 1)
        {
            if (name == "ARG")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[2] == 1)
        {
            if (name == "ALA")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[3] == 1)
        {
            if (name == "ASN")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[4] == 1)
        {
            if (name == "ASP")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[5] == 1)
        {
            if (name == "CYS")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[6] == 1)
        {
            if (name == "GLN")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[7] == 1)
        {
            if (name == "GLU")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[8] == 1)
        {
            if (name == "GLY")
            {
                rend.enabled = true;
            }
        }
        if (resobjs[9] == 1)
        {
            if (name == "HIS")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[0] == 1)
        {
            if (name == "ILE")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[1] == 1)
        {
            if (name == "LEU")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[2] == 1)
        {
            if (name == "LYS")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[3] == 1)
        {
            if (name == "MET")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[4] == 1)
        {
            if (name == "MG")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[5] == 1)
        {
            if (name == "PHE")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[6] == 1)
        {
            if (name == "PRO")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[7] == 1)
        {
            if (name == "SER")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[8] == 1)
        {
            if (name == "THR")
            {
                rend.enabled = true;
            }
        }
        if (resobjs2[9] == 1)
        {
            if (name == "TL")
            {
                rend.enabled = true;
            }
        }
        if (resobjs3[0] == 1)
        {
            if (name == "TYR")
            {
                rend.enabled = true;
            }
        }
        if (resobjs3[1] == 1)
        {
            if (name == "VAL")
            {
                rend.enabled = true;
            }
        }
    }
}
