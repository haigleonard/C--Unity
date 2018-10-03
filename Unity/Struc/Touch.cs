using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour {

    public GameObject title1;
    public GameObject title2;
    public GameObject title3;

    public GameObject element1;
    public GameObject element2;
    public GameObject element3;
    public GameObject element4;
    public GameObject element5;
    public GameObject element6;
    public GameObject element7;
    public GameObject element8;
    public GameObject element9;
    public GameObject element10;
    public GameObject element11;
    public GameObject element12;

    public GameObject Sphere;
    public GameObject Cartoon;
    public GameObject Line;

    public GameObject AGS;
    public GameObject ARG;
    public GameObject ALA;
    public GameObject ASN;
    public GameObject ASP;
    public GameObject CYS;
    public GameObject GLN;
    public GameObject GLU;
    public GameObject GLY;
    public GameObject LEU;
    public GameObject ILE;
    public GameObject HIS;
    public GameObject LYS;
    public GameObject MET;
    public GameObject MG;
    public GameObject PHE;
    public GameObject PRO;
    public GameObject SER;

    public GameObject THR;
    public GameObject TL;
    public GameObject TYR;
    public GameObject VAL;

    public GameObject TourGui;
    public GameObject Tour;
    public GameObject Next;

    public int[] resobjs = new int[10];
    public int[] resobjs2 = new int[10];
    public int[] resobjs3 = new int[2];
    bool tourBegin = false;
    public int[] eleobjs = new int[10];
    public int[] eleobjs2 = new int[10];
    public int[] repobjs = new int[3];
    public int count = 1;
    public int Elcount = 0;
    public int Rescount = 0;
    int element = 0;
    int Reps = 0;
    int Resno = 0;

    Renderer rend;

    float X;
    float Y;
    float Z;

    float distance1;
    float distance2;
    float distance3;
    float distance4;
    float distance5;
    float distance6;

    public bool visb = false;

    int page = 2;
    int paper = 1;

    public PathMov pathTour;

    // Use this for initialization
    void Start () {
        
        for (int e = 0; e < 9; e++)
        {
            resobjs[e] = 0;
        }
        for (int f = 0; f < 9; f++)
        {
            resobjs2[f] = 0;
        }
        for (int f = 0; f < 3; f++)
        {
            repobjs[f] = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            eleobjs[i] = 0;
        }
        for (int i = 0; i < 10; i++)
        {
            eleobjs2[i] = 0;
        }

    }
	
	// Update is called once per frame
	void Update () {

        bool unlock = false;

        X = transform.position.x;
        Y = transform.position.y;
        Z = transform.position.z;
        if (page == 1)
        {
            TourG();
        }
        if (page == 2 && paper == 1) {
            Elements();
        }
        if (page == 2 && paper == 2)
        {
            Elements2();
        }
        if (page == 3)
        {
            Rep();
        }
        if (page == 4 && paper == 1)
        {
            Res();
        }
        if (page == 4 && paper == 2)
        {
            Res2();
        }
        if (page == 4 && paper == 3)
        {
            Res3();
        }
        if (page == 4 && paper == 4)
        {
            Res4();
        }

        if (Input.GetButtonUp("Fire2") && page == 4)
        {
            eleVis(false);
            Tourguide(true);
            Tourguide2(true);
            tourTitle(true);
            resVis(false);
            resVis2(false);
            resVis3(false);
            resVis4(false);
            resTitle(false);

            unlock = true;
            paper = 1;
        }
        if (Input.GetButtonUp("Fire2") && page == 1)
        {
            eleVis(true);
            resVis(false);
            eleVis2(false);
            repVis(false);
            Tourguide(false);
            Tourguide2(false);
            resTitle(false);
            eleTitle(true);
            tourTitle(false);
            unlock = true;
            paper = 1;
        }
        if (Input.GetButtonUp("Fire2") && page == 3)
        {
            eleVis(false);
            resVis(true);
            resTitle(true);
            repVis(false);
            Tourguide(false);
            Tourguide2(false);
            tourTitle(false);
            unlock = true;
            paper = 1;
        }
        if (Input.GetButtonUp("Fire2") && page == 2) {
            eleVis(false);
            resVis(false);
            eleVis2(false);
            repVis(true);
            Tourguide(false);
            Tourguide2(false);
            eleTitle(false);
            tourTitle(false);
            unlock = true;
            paper = 1;
        }
        if (Input.GetButtonUp("vis") && page == 2)
        {

            paper++;
            if (paper == 3)
            {
                paper = 1;
            }
            if (paper == 2)
            {
                eleVis(false);
                eleVis2(true);
            }
            else if (paper == 1)
            {
                eleVis(true);
                eleVis2(false);
            }
        }

        if (Input.GetButtonUp("vis") && page == 4)
        {
            paper++;
            if (paper == 5)
            {
                paper = 1;
            }
            if (paper == 4)
            {
                resVis3(false);
                resVis4(true);
            }
            else if (paper == 3)
            {
                resVis2(false);
                resVis3(true);
            }
            else if (paper == 2)
            {
                resVis(false);
                resVis2(true);
            }
            else if (paper == 1)
            {
                resVis(true);
                resVis4(false);
            }
        }

        if (unlock)
        {
            page++;
            if (page == 5) { page = 1; }
            unlock = false;
        }
    }

    void Tourguide(bool B)
    {
        if (!tourBegin)
        {
            rend = Tour.GetComponent<Renderer>();
            rend.enabled = B;
        }
    }
    void Tourguide2(bool B)
    {
        if (tourBegin)
        {
            rend = Next.GetComponent<Renderer>();
            rend.enabled = B;
        }
    }
    void TourG()
    {
        if (!tourBegin)
        {
            distance1 = (Mathf.Sqrt(
               Mathf.Pow((X - Tour.transform.position.x), 2) +
               Mathf.Pow((Y - Tour.transform.position.y), 2) +
               Mathf.Pow((Z - Tour.transform.position.z), 2)));

            if (distance1 < 0.08) { Tour.GetComponent<Renderer>().material.color = Color.green; Reps = 1; }
            else { Tour.GetComponent<Renderer>().material.color = Color.white; }

            if (Input.GetButtonUp("Fire1") && distance1 < 0.08)
            {
                pathTour.move = true;
                tourBegin = true;
                rend = Next.GetComponent<Renderer>();
                rend.enabled = true;
                rend = Tour.GetComponent<Renderer>();
                rend.enabled = false; ;
            }
            else { pathTour.move = false; }
        }
        if (tourBegin)
        {
            distance1 = (Mathf.Sqrt(
               Mathf.Pow((X - Next.transform.position.x), 2) +
               Mathf.Pow((Y - Next.transform.position.y), 2) +
               Mathf.Pow((Z - Next.transform.position.z), 2)));

            if (distance1 < 0.08) { Next.GetComponent<Renderer>().material.color = Color.green; Reps = 1; }
            else { Next.GetComponent<Renderer>().material.color = Color.white; }

            if (Input.GetButtonUp("Fire1") && distance1 < 0.08)
            {
                pathTour.move = true;
            }
            else { pathTour.move = false; }
        }
    }
    void tourTitle(bool B)
    {
        rend = TourGui.GetComponent<Renderer>();
        rend.enabled = B;
    }
    void eleTitle(bool B)
    {
        rend = title1.GetComponent<Renderer>();
        rend.enabled = B;
    }
    void eleVis(bool B)
    {
        rend = element1.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element2.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element3.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element4.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element5.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element6.GetComponent<Renderer>();
        rend.enabled = B;
    }
    void eleVis2(bool B)
    {
        
        rend = element7.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element8.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element9.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element10.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element11.GetComponent<Renderer>();
        rend.enabled = B;
        rend = element12.GetComponent<Renderer>();
        rend.enabled = B;
    }

    void resTitle(bool B)
    {
        rend = title2.GetComponent<Renderer>();
        rend.enabled = B;
    }

    void resVis(bool B)
    {
        rend = ARG.GetComponent<Renderer>();
        rend.enabled = B;
        rend = AGS.GetComponent<Renderer>();
        rend.enabled = B;
        rend = ALA.GetComponent<Renderer>();
        rend.enabled = B;
        rend = ASN.GetComponent<Renderer>();
        rend.enabled = B;
        rend = ASP.GetComponent<Renderer>();
        rend.enabled = B;
        rend = CYS.GetComponent<Renderer>();
        rend.enabled = B;
    }

    void resVis2(bool B)
    {
        rend = GLN.GetComponent<Renderer>();
        rend.enabled = B;
        rend = GLY.GetComponent<Renderer>();
        rend.enabled = B;
        rend = LEU.GetComponent<Renderer>();
        rend.enabled = B;
        rend = ILE.GetComponent<Renderer>();
        rend.enabled = B;
        rend = GLU.GetComponent<Renderer>();
        rend.enabled = B;
        rend = HIS.GetComponent<Renderer>();
        rend.enabled = B;
    }
    void resVis3(bool B)
    {
        rend = LYS.GetComponent<Renderer>();
        rend.enabled = B;
        rend = MET.GetComponent<Renderer>();
        rend.enabled = B;
        rend = MG.GetComponent<Renderer>();
        rend.enabled = B;
        rend = PHE.GetComponent<Renderer>();
        rend.enabled = B;
        rend = PRO.GetComponent<Renderer>();
        rend.enabled = B;
        rend = SER.GetComponent<Renderer>();
        rend.enabled = B;
    }
    void resVis4(bool B)
    {
        rend = THR.GetComponent<Renderer>();
        rend.enabled = B;
        rend = TL.GetComponent<Renderer>();
        rend.enabled = B;
        rend = TYR.GetComponent<Renderer>();
        rend.enabled = B;
        rend = VAL.GetComponent<Renderer>();
        rend.enabled = B;
    }

    void repVis(bool B)
    {
        rend = title3.GetComponent<Renderer>();
        rend.enabled = B;
        rend = Sphere.GetComponent<Renderer>();
        rend.enabled = B;
        rend = Cartoon.GetComponent<Renderer>();
        rend.enabled = B;
        rend = Line.GetComponent<Renderer>();
        rend.enabled = B;
    }

    void Rep()
    {
        distance1 = (Mathf.Sqrt(
            Mathf.Pow((X - Sphere.transform.position.x), 2) +
            Mathf.Pow((Y - Sphere.transform.position.y), 2) +
            Mathf.Pow((Z - Sphere.transform.position.z), 2)));
        distance2 = (Mathf.Sqrt(
            Mathf.Pow((X - Cartoon.transform.position.x), 2) +
            Mathf.Pow((Y - Cartoon.transform.position.y), 2) +
            Mathf.Pow((Z - Cartoon.transform.position.z), 2)));
        distance3 = (Mathf.Sqrt(
            Mathf.Pow((X - Line.transform.position.x), 2) +
            Mathf.Pow((Y - Line.transform.position.y), 2) +
            Mathf.Pow((Z - Line.transform.position.z), 2)));

        if (distance1 < distance2 && distance1 < distance3 &&
            distance1 < 0.08) { Sphere.GetComponent<Renderer>().material.color = Color.green; Reps = 1; }
        else { if (repobjs[0] == 0) { Sphere.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance2 < distance1 && distance2 < distance3 &&
            distance2 < 0.08) { Cartoon.GetComponent<Renderer>().material.color = Color.green; Reps = 2; }
        else { if (repobjs[1] == 0) { Cartoon.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance3 < distance1 && distance3 < distance1 &&
            distance3 < 0.08) { Line.GetComponent<Renderer>().material.color = Color.green; Reps = 3; }
        else { if (repobjs[2] == 0) { Line.GetComponent<Renderer>().material.color = Color.white; } }

        if (Reps == 1 && Input.GetButtonUp("Fire1")) { count = 1; Elcount = 0; Rescount = 0; if (repobjs[0] == 0) { repobjs[0] = 1; } else if (repobjs[0] == 1) { repobjs[0] = 0; } }
        if (Reps == 2 && Input.GetButtonUp("Fire1")) { count = 2; Elcount = 0; Rescount = 0; if (repobjs[1] == 0) { repobjs[1] = 1; } else if (repobjs[1] == 1) { repobjs[1] = 0; } }
        if (Reps == 3 && Input.GetButtonUp("Fire1")) { count = 3; Elcount = 0; Rescount = 0; if (repobjs[2] == 0) { repobjs[2] = 1; } else if (repobjs[2] == 1) { repobjs[2] = 0; } }
    }

    void Res()
    {
        distance1 = (Mathf.Sqrt(
            Mathf.Pow((X - AGS.transform.position.x), 2) +
            Mathf.Pow((Y - AGS.transform.position.y), 2) +
            Mathf.Pow((Z - AGS.transform.position.z), 2)));
        distance2 = (Mathf.Sqrt(
            Mathf.Pow((X - ARG.transform.position.x), 2) +
            Mathf.Pow((Y - ARG.transform.position.y), 2) +
            Mathf.Pow((Z - ARG.transform.position.z), 2)));
        distance3 = (Mathf.Sqrt(
            Mathf.Pow((X - ALA.transform.position.x), 2) +
            Mathf.Pow((Y - ALA.transform.position.y), 2) +
            Mathf.Pow((Z - ALA.transform.position.z), 2)));
        distance4 = (Mathf.Sqrt(
            Mathf.Pow((X - ASN.transform.position.x), 2) +
            Mathf.Pow((Y - ASN.transform.position.y), 2) +
            Mathf.Pow((Z - ASN.transform.position.z), 2)));
        distance5 = (Mathf.Sqrt(
            Mathf.Pow((X - ASP.transform.position.x), 2) +
            Mathf.Pow((Y - ASP.transform.position.y), 2) +
            Mathf.Pow((Z - ASP.transform.position.z), 2)));
        distance6 = (Mathf.Sqrt(
            Mathf.Pow((X - CYS.transform.position.x), 2) +
            Mathf.Pow((Y - CYS.transform.position.y), 2) +
            Mathf.Pow((Z - CYS.transform.position.z), 2)));

        if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4 && distance1 < distance5 && distance1 < distance6 &&
            distance1 < 0.08) { AGS.GetComponent<Renderer>().material.color = Color.green; Resno = 1; }
        else { if (resobjs[0] == 0) { AGS.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4 && distance2 < distance5 && distance2 < distance6
            && distance2 < 0.08) { ARG.GetComponent<Renderer>().material.color = Color.green; Resno = 2; }
        else { if (resobjs[1] == 0) { ARG.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4 && distance3 < distance5 && distance3 < distance6 &&
            distance3 < 0.08) { ALA.GetComponent<Renderer>().material.color = Color.green; Resno = 3; }
        else { if (resobjs[2] == 0) { ALA.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && distance4 < distance5 && distance4 < distance6 &&
           distance4 < 0.08) { ASN.GetComponent<Renderer>().material.color = Color.green; Resno = 4; }
        else { if (resobjs[3] == 0) { ASN.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance5 < distance1 && distance5 < distance2 && distance5 < distance3 && distance5 < distance4 && distance5 < distance6 &&
            distance5 < 0.08) { ASP.GetComponent<Renderer>().material.color = Color.green; Resno = 5; }
        else { if (resobjs[4] == 0) { ASP.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance6 < distance1 && distance6 < distance2 && distance6 < distance3 && distance6 < distance4 && distance6 < distance5 &&
            distance6 < 0.08) { CYS.GetComponent<Renderer>().material.color = Color.green; Resno = 6; }
        else { if (resobjs[5] == 0) { CYS.GetComponent<Renderer>().material.color = Color.white; } }
        
        Debug.Log(Resno);

        if (Resno == 1 && Input.GetButtonUp("Fire1")) { if (resobjs[0] == 0) { resobjs[0] = 1; } else if (resobjs[0] == 1) { resobjs[0] = 0; } }
        if (Resno == 2 && Input.GetButtonUp("Fire1")) {  if (resobjs[1] == 0) { resobjs[1] = 1; } else if (resobjs[1] == 1) { resobjs[1] = 0; } }
        if (Resno == 3 && Input.GetButtonUp("Fire1")) { if (resobjs[2] == 0) { resobjs[2] = 1; } else if (resobjs[2] == 1) { resobjs[2] = 0; } }
        if (Resno == 4 && Input.GetButtonUp("Fire1")) {  if (resobjs[3] == 0) { resobjs[3] = 1; } else if (resobjs[3] == 1) { resobjs[3] = 0; } }
        if (Resno == 5 && Input.GetButtonUp("Fire1")) {  if (resobjs[4] == 0) { resobjs[4] = 1; } else if (resobjs[4] == 1) { resobjs[4] = 0; } }
        if (Resno == 6 && Input.GetButtonUp("Fire1")) {  if (resobjs[5] == 0) { resobjs[5] = 1; } else if (resobjs[5] == 1) { resobjs[5] = 0; } }
    }

    void Res2()
    {
        distance1 = (Mathf.Sqrt(
            Mathf.Pow((X - GLN.transform.position.x), 2) +
            Mathf.Pow((Y - GLN.transform.position.y), 2) +
            Mathf.Pow((Z - GLN.transform.position.z), 2)));
        distance2 = (Mathf.Sqrt(
            Mathf.Pow((X - GLU.transform.position.x), 2) +
            Mathf.Pow((Y - GLU.transform.position.y), 2) +
            Mathf.Pow((Z - GLU.transform.position.z), 2)));
        distance3 = (Mathf.Sqrt(
            Mathf.Pow((X - GLY.transform.position.x), 2) +
            Mathf.Pow((Y - GLY.transform.position.y), 2) +
            Mathf.Pow((Z - GLY.transform.position.z), 2)));
        distance4 = (Mathf.Sqrt(
            Mathf.Pow((X - HIS.transform.position.x), 2) +
            Mathf.Pow((Y - HIS.transform.position.y), 2) +
            Mathf.Pow((Z - HIS.transform.position.z), 2)));
        distance5 = (Mathf.Sqrt(
            Mathf.Pow((X - ILE.transform.position.x), 2) +
            Mathf.Pow((Y - ILE.transform.position.y), 2) +
            Mathf.Pow((Z - ILE.transform.position.z), 2)));
        distance6 = (Mathf.Sqrt(
            Mathf.Pow((X - LEU.transform.position.x), 2) +
            Mathf.Pow((Y - LEU.transform.position.y), 2) +
            Mathf.Pow((Z - LEU.transform.position.z), 2)));

        if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4 && distance1 < distance5 && distance1 < distance6 &&
            distance1 < 0.08) { GLN.GetComponent<Renderer>().material.color = Color.green; Resno = 1; }
        else { if (resobjs[6] == 0) { GLN.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4 && distance2 < distance5 && distance2 < distance6
            && distance2 < 0.08) { GLU.GetComponent<Renderer>().material.color = Color.green; Resno = 2; }
        else { if (resobjs[7] == 0) { GLU.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4 && distance3 < distance5 && distance3 < distance6 &&
            distance3 < 0.08) { GLY.GetComponent<Renderer>().material.color = Color.green; Resno = 3; }
        else { if (resobjs[8] == 0) { GLY.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && distance4 < distance5 && distance4 < distance6 &&
           distance4 < 0.08) { HIS.GetComponent<Renderer>().material.color = Color.green; Resno = 4; }
        else { if (resobjs[9] == 0) { HIS.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance5 < distance1 && distance5 < distance2 && distance5 < distance3 && distance5 < distance4 && distance5 < distance6 &&
            distance5 < 0.08) { ILE.GetComponent<Renderer>().material.color = Color.green; Resno = 5; }
        else { if (resobjs2[0] == 0) { ILE.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance6 < distance1 && distance6 < distance2 && distance6 < distance3 && distance6 < distance4 && distance6 < distance5 &&
            distance6 < 0.08) { LEU.GetComponent<Renderer>().material.color = Color.green; Resno = 6; }
        else { if (resobjs2[1] == 0) { LEU.GetComponent<Renderer>().material.color = Color.white; } }
        

        if (Resno == 1 && Input.GetButtonUp("Fire1")) {  if (resobjs[6] == 0) { resobjs[6] = 1; } else if (resobjs[6] == 1) { resobjs[6] = 0; } }
        if (Resno == 2 && Input.GetButtonUp("Fire1")) {  if (resobjs[7] == 0) { resobjs[7] = 1; } else if (resobjs[7] == 1) { resobjs[7] = 0; } }
        if (Resno == 3 && Input.GetButtonUp("Fire1")) {  if (resobjs[8] == 0) { resobjs[8] = 1; } else if (resobjs[8] == 1) { resobjs[8] = 0; } }
        if (Resno == 4 && Input.GetButtonUp("Fire1")) {  if (resobjs[9] == 0) { resobjs[9] = 1; } else if (resobjs[9] == 1) { resobjs[9] = 0; } }
        if (Resno == 5 && Input.GetButtonUp("Fire1")) {  if (resobjs2[0] == 0) { resobjs2[0] = 1; } else if (resobjs2[0] == 1) { resobjs2[0] = 0; } }
        if (Resno == 6 && Input.GetButtonUp("Fire1")) {  if (resobjs2[1] == 0) { resobjs2[1] = 1; } else if (resobjs2[1] == 1) { resobjs2[1] = 0; } }
    }
    void Res3()
    {
        distance1 = (Mathf.Sqrt(
            Mathf.Pow((X - LYS.transform.position.x), 2) +
            Mathf.Pow((Y - LYS.transform.position.y), 2) +
            Mathf.Pow((Z - LYS.transform.position.z), 2)));
        distance2 = (Mathf.Sqrt(
            Mathf.Pow((X - MET.transform.position.x), 2) +
            Mathf.Pow((Y - MET.transform.position.y), 2) +
            Mathf.Pow((Z - MET.transform.position.z), 2)));
        distance3 = (Mathf.Sqrt(
            Mathf.Pow((X - MG.transform.position.x), 2) +
            Mathf.Pow((Y - MG.transform.position.y), 2) +
            Mathf.Pow((Z - MG.transform.position.z), 2)));
        distance4 = (Mathf.Sqrt(
            Mathf.Pow((X - PHE.transform.position.x), 2) +
            Mathf.Pow((Y - PHE.transform.position.y), 2) +
            Mathf.Pow((Z - PHE.transform.position.z), 2)));
        distance5 = (Mathf.Sqrt(
            Mathf.Pow((X - PRO.transform.position.x), 2) +
            Mathf.Pow((Y - PRO.transform.position.y), 2) +
            Mathf.Pow((Z - PRO.transform.position.z), 2)));
        distance6 = (Mathf.Sqrt(
            Mathf.Pow((X - SER.transform.position.x), 2) +
            Mathf.Pow((Y - SER.transform.position.y), 2) +
            Mathf.Pow((Z - SER.transform.position.z), 2)));

        if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4 && distance1 < distance5 && distance1 < distance6 &&
            distance1 < 0.08) { LYS.GetComponent<Renderer>().material.color = Color.green; Resno = 1; }
        else { if (resobjs2[2] == 0) { LYS.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4 && distance2 < distance5 && distance2 < distance6
            && distance2 < 0.08) { MET.GetComponent<Renderer>().material.color = Color.green; Resno = 2; }
        else { if (resobjs2[3] == 0) { MET.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4 && distance3 < distance5 && distance3 < distance6 &&
            distance3 < 0.08) { MG.GetComponent<Renderer>().material.color = Color.green; Resno = 3; }
        else { if (resobjs2[4] == 0) { MG.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && distance4 < distance5 && distance4 < distance6 &&
           distance4 < 0.08) { PHE.GetComponent<Renderer>().material.color = Color.green; Resno = 4; }
        else { if (resobjs2[5] == 0) { PHE.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance5 < distance1 && distance5 < distance2 && distance5 < distance3 && distance5 < distance4 && distance5 < distance6 &&
            distance5 < 0.08) { PRO.GetComponent<Renderer>().material.color = Color.green; Resno = 5; }
        else { if (resobjs2[6] == 0) { PRO.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance6 < distance1 && distance6 < distance2 && distance6 < distance3 && distance6 < distance4 && distance6 < distance5 &&
            distance6 < 0.08) { SER.GetComponent<Renderer>().material.color = Color.green; Resno = 6; }
        else { if (resobjs2[7] == 0) { SER.GetComponent<Renderer>().material.color = Color.white; } }
        
        if (Resno == 1 && Input.GetButtonUp("Fire1")) {  if (resobjs2[2] == 0) { resobjs2[2] = 1; } else if (resobjs2[2] == 1) { resobjs2[2] = 0; } }
        if (Resno == 2 && Input.GetButtonUp("Fire1")) {  if (resobjs2[3] == 0) { resobjs2[3] = 1; } else if (resobjs2[3] == 1) { resobjs2[3] = 0; } }
        if (Resno == 3 && Input.GetButtonUp("Fire1")) { if (resobjs2[4] == 0) { resobjs2[4] = 1; } else if (resobjs2[4] == 1) { resobjs2[4] = 0; } }
        if (Resno == 4 && Input.GetButtonUp("Fire1")) {  if (resobjs2[5] == 0) { resobjs2[5] = 1; } else if (resobjs2[5] == 1) { resobjs2[5] = 0; } }
        if (Resno == 5 && Input.GetButtonUp("Fire1")) { if (resobjs2[6] == 0) { resobjs2[6] = 1; } else if (resobjs2[6] == 1) { resobjs2[6] = 0; } }
        if (Resno == 6 && Input.GetButtonUp("Fire1")) {  if (resobjs2[7] == 0) { resobjs2[7] = 1; } else if (resobjs2[7] == 1) { resobjs2[7] = 0; } }
    }

    void Res4()
    {
        distance1 = (Mathf.Sqrt(
            Mathf.Pow((X - THR.transform.position.x), 2) +
            Mathf.Pow((Y - THR.transform.position.y), 2) +
            Mathf.Pow((Z - THR.transform.position.z), 2)));
        distance2 = (Mathf.Sqrt(
            Mathf.Pow((X - TL.transform.position.x), 2) +
            Mathf.Pow((Y - TL.transform.position.y), 2) +
            Mathf.Pow((Z - TL.transform.position.z), 2)));
        distance3 = (Mathf.Sqrt(
            Mathf.Pow((X - TYR.transform.position.x), 2) +
            Mathf.Pow((Y - TYR.transform.position.y), 2) +
            Mathf.Pow((Z - TYR.transform.position.z), 2)));
        distance4 = (Mathf.Sqrt(
            Mathf.Pow((X - VAL.transform.position.x), 2) +
            Mathf.Pow((Y - VAL.transform.position.y), 2) +
            Mathf.Pow((Z - VAL.transform.position.z), 2)));

        if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4 &&
            distance1 < 0.08) { THR.GetComponent<Renderer>().material.color = Color.green; Resno = 1; }
        else { if (resobjs2[8] == 0) { THR.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4 &&
            distance2 < 0.08) { TL.GetComponent<Renderer>().material.color = Color.green; Resno = 2; }
        else { if (resobjs2[9] == 0) { TL.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance3 < distance2 && distance3 < distance1 && distance3 < distance4 &&
            distance3 < 0.08) { TYR.GetComponent<Renderer>().material.color = Color.green; Resno = 3; }
        else { if (resobjs3[0] == 0) { TYR.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance4 < distance2 && distance4 < distance3 && distance4 < distance1 &&
            distance4 < 0.08) { VAL.GetComponent<Renderer>().material.color = Color.green; Resno = 4; }
        else { if (resobjs3[1] == 0) { VAL.GetComponent<Renderer>().material.color = Color.white; } }



        if (Resno == 1 && Input.GetButtonUp("Fire1")) {  if (resobjs2[8] == 0) { resobjs2[8] = 1; } else if (resobjs2[8] == 1) { resobjs2[8] = 0; } }
        if (Resno == 2 && Input.GetButtonUp("Fire1")) { if (resobjs2[9] == 0) { resobjs2[9] = 1; } else if (resobjs2[9] == 1) { resobjs2[9] = 0; } }
        if (Resno == 3 && Input.GetButtonUp("Fire1")) {  if (resobjs3[0] == 0) { resobjs3[0] = 1; } else if (resobjs3[0] == 1) { resobjs3[0] = 0; } }
        if (Resno == 4 && Input.GetButtonUp("Fire1")) {  if (resobjs3[1] == 0) { resobjs3[1] = 1; } else if (resobjs3[1] == 1) { resobjs3[1] = 0; } }
        }


    void Elements()
    {
        distance1 = (Mathf.Sqrt(
            Mathf.Pow((X - element1.transform.position.x), 2) +
            Mathf.Pow((Y - element1.transform.position.y), 2) +
            Mathf.Pow((Z - element1.transform.position.z), 2)));
        distance2 = (Mathf.Sqrt(
            Mathf.Pow((X - element2.transform.position.x), 2) +
            Mathf.Pow((Y - element2.transform.position.y), 2) +
            Mathf.Pow((Z - element2.transform.position.z), 2)));
        distance3 = (Mathf.Sqrt(
            Mathf.Pow((X - element3.transform.position.x), 2) +
            Mathf.Pow((Y - element3.transform.position.y), 2) +
            Mathf.Pow((Z - element3.transform.position.z), 2)));
        distance4 = (Mathf.Sqrt(
            Mathf.Pow((X - element4.transform.position.x), 2) +
            Mathf.Pow((Y - element4.transform.position.y), 2) +
            Mathf.Pow((Z - element4.transform.position.z), 2)));
        distance5 = (Mathf.Sqrt(
            Mathf.Pow((X - element5.transform.position.x), 2) +
            Mathf.Pow((Y - element5.transform.position.y), 2) +
            Mathf.Pow((Z - element5.transform.position.z), 2)));
        distance6 = (Mathf.Sqrt(
            Mathf.Pow((X - element6.transform.position.x), 2) +
            Mathf.Pow((Y - element6.transform.position.y), 2) +
            Mathf.Pow((Z - element6.transform.position.z), 2)));

        if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4 && distance1 < distance5 && distance1 < distance6 &&
            distance1 < 0.08) { element1.GetComponent<Renderer>().material.color = Color.green; element = 1; }
            else { if (eleobjs[1] == 0) { element1.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4 && distance2 < distance5 && distance2 < distance6
            && distance2 < 0.08) { element2.GetComponent<Renderer>().material.color = Color.green; element = 2;  }
                else { if (eleobjs[0] == 0) { element2.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4 && distance3 < distance5 && distance3 < distance6 &&
            distance3 < 0.08) { element3.GetComponent<Renderer>().material.color = Color.green; element = 3;  }
                    else { if (eleobjs[2] == 0) { element3.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && distance4 < distance5 && distance4 < distance6 &&
            distance4 < 0.08) { element4.GetComponent<Renderer>().material.color = Color.green; element = 4; }
                        else { if (eleobjs[3] == 0) { element4.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance5 < distance1 && distance5 < distance2 && distance5 < distance3 && distance5 < distance4 && distance5 < distance6 &&
            distance5 < 0.08) { element5.GetComponent<Renderer>().material.color = Color.green; element = 5;  }
                            else { if (eleobjs[5] == 0) { element5.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance6 < distance1 && distance6 < distance2 && distance6 < distance3 && distance6 < distance4 && distance6 < distance5 &&
            distance6 < 0.08) { element6.GetComponent<Renderer>().material.color = Color.green; element = 6;  }
                                else { if (eleobjs[4] == 0) { element6.GetComponent<Renderer>().material.color = Color.white; } }



        if (element == 1 && Input.GetButtonUp("Fire1")) {  if (eleobjs[1] == 0) { eleobjs[1] = 1;  } else if (eleobjs[1] == 1) { eleobjs[1] = 0;  } }
        if (element == 2 && Input.GetButtonUp("Fire1")) {  if (eleobjs[0] == 0) { eleobjs[0] = 1;  } else if(eleobjs[0] == 1) { eleobjs[0] = 0;  } }
        if (element == 3 && Input.GetButtonUp("Fire1")) { if (eleobjs[2] == 0) { eleobjs[2] = 1; } else if(eleobjs[2] == 1) { eleobjs[2] = 0; } }
        if (element == 4 && Input.GetButtonUp("Fire1")) {  if (eleobjs[3] == 0) { eleobjs[3] = 1; } else if(eleobjs[3] == 1) { eleobjs[3] = 0; } }
        if (element == 5 && Input.GetButtonUp("Fire1")) {  if (eleobjs[5] == 0) { eleobjs[5] = 1; } else if(eleobjs[5] == 1) { eleobjs[5] = 0; } }
        if (element == 6 && Input.GetButtonUp("Fire1")) {  if (eleobjs[4] == 0) { eleobjs[4] = 1; } else if(eleobjs[4] == 1) { eleobjs[4] = 0; } }
    }

    void Elements2()
    {
        distance1 = (Mathf.Sqrt(
            Mathf.Pow((X - element7.transform.position.x), 2) +
            Mathf.Pow((Y - element7.transform.position.y), 2) +
            Mathf.Pow((Z - element7.transform.position.z), 2)));
        distance2 = (Mathf.Sqrt(
            Mathf.Pow((X - element8.transform.position.x), 2) +
            Mathf.Pow((Y - element8.transform.position.y), 2) +
            Mathf.Pow((Z - element8.transform.position.z), 2)));
        distance3 = (Mathf.Sqrt(
            Mathf.Pow((X - element9.transform.position.x), 2) +
            Mathf.Pow((Y - element9.transform.position.y), 2) +
            Mathf.Pow((Z - element9.transform.position.z), 2)));
        distance4 = (Mathf.Sqrt(
            Mathf.Pow((X - element10.transform.position.x), 2) +
            Mathf.Pow((Y - element10.transform.position.y), 2) +
            Mathf.Pow((Z - element10.transform.position.z), 2)));
        distance5 = (Mathf.Sqrt(
            Mathf.Pow((X - element11.transform.position.x), 2) +
            Mathf.Pow((Y - element11.transform.position.y), 2) +
            Mathf.Pow((Z - element11.transform.position.z), 2)));
        distance6 = (Mathf.Sqrt(
            Mathf.Pow((X - element12.transform.position.x), 2) +
            Mathf.Pow((Y - element12.transform.position.y), 2) +
            Mathf.Pow((Z - element12.transform.position.z), 2)));



        if (distance1 < distance2 && distance1 < distance3 && distance1 < distance4 && distance1 < distance5 && distance1 < distance6 &&
           distance1 < 0.08) { element7.GetComponent<Renderer>().material.color = Color.green; element = 1; }
        else { if (eleobjs[6] == 0) { element7.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance2 < distance1 && distance2 < distance3 && distance2 < distance4 && distance2 < distance5 && distance2 < distance6
            && distance2 < 0.08) { element8.GetComponent<Renderer>().material.color = Color.green; element = 2; }
        else { if (eleobjs[7] == 0) { element8.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance3 < distance1 && distance3 < distance2 && distance3 < distance4 && distance3 < distance5 && distance3 < distance6 &&
            distance3 < 0.08) { element9.GetComponent<Renderer>().material.color = Color.green; element = 3; }
        else { if (eleobjs[8] == 0) { element9.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && distance4 < distance5 && distance4 < distance6 &&
            distance4 < 0.08) { element10.GetComponent<Renderer>().material.color = Color.green; element = 4; }
        else { if (eleobjs[9] == 0) { element10.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance5 < distance1 && distance5 < distance2 && distance5 < distance3 && distance5 < distance4 && distance5 < distance6 &&
            distance5 < 0.08) { element11.GetComponent<Renderer>().material.color = Color.green; element = 5; }
        else { if (eleobjs2[0] == 0) { element11.GetComponent<Renderer>().material.color = Color.white; } }
        if (distance6 < distance1 && distance6 < distance2 && distance6 < distance3 && distance6 < distance4 && distance6 < distance5 &&
            distance6 < 0.08) { element12.GetComponent<Renderer>().material.color = Color.green; element = 6; }
        else { if (eleobjs2[1] == 0) { element12.GetComponent<Renderer>().material.color = Color.white; } }


        if (element == 1 && Input.GetButtonUp("Fire1")) {  if (eleobjs[6] == 0) { eleobjs[6] = 1;  } else if (eleobjs[6] == 1) { eleobjs[6] = 0;  } }
        if (element == 2 && Input.GetButtonUp("Fire1")) {  if (eleobjs[7] == 0) { eleobjs[7] = 1; } else if (eleobjs[7] == 1) { eleobjs[7] = 0; } }
        if (element == 3 && Input.GetButtonUp("Fire1")) {  if (eleobjs[8] == 0) { eleobjs[8] = 1; } else if (eleobjs[8] == 1) { eleobjs[8] = 0; } }
        if (element == 4 && Input.GetButtonUp("Fire1")) {  if (eleobjs[9] == 0) { eleobjs[9] = 1; } else if (eleobjs[9] == 1) { eleobjs[9] = 0; } }
        if (element == 5 && Input.GetButtonUp("Fire1")) {  if (eleobjs2[0] == 0) { eleobjs2[0] = 1; } else if (eleobjs2[0] == 1) { eleobjs2[0] = 0; } }
        if (element == 6 && Input.GetButtonUp("Fire1")) {  if (eleobjs2[1] == 0) { eleobjs2[1] = 1; } else if (eleobjs2[1] == 1) { eleobjs2[1] = 0; } }
    }
    

}
