using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StructureMaker : MonoBehaviour {
    //reads file and prodcues sphere at each coordinant, too computaionally heavy, alternative approach required
    //either down res spheres, or join meshes
    int count = 0;
    string txtContents;
    float X;
    float Y;
    float Z;
    float rad;
    float colorX;
    float colorY;
    float colorZ;
    float maxZ = 0;
    float minZ = 0;
    float maxX = 0;
    float minX = 0;
    int count2 = 0;

    ArrayList x = new ArrayList();
    ArrayList y = new ArrayList();
    ArrayList z = new ArrayList();
    ArrayList col1 = new ArrayList();
    ArrayList col2 = new ArrayList();
    ArrayList col3 = new ArrayList();

    public bool render = false;
    bool render2 = true;
    MeshFilter[] meshFilters = new MeshFilter[33698];
    GameObject sphere;
    
    public GameObject bluey;
    public GameObject red;
    public GameObject grey;
    public GameObject lightgrey;
    public GameObject yellow;
    public GameObject lightblue;
    public GameObject green;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (render && render2)
        {
            //TextAsset txtAssets = (TextAsset)Resources.Load("1ADG(7046)4");
            TextAsset txtAssets = (TextAsset)Resources.Load("3E76");
            //TextAsset txtAssets = (TextAsset)Resources.Load("1CRN(327)");
            //TextAsset txtAssets = (TextAsset)Resources.Load("1BKS(5231)");

            txtContents = txtAssets.text;

            string[] bits = txtContents.Split('\n');
            foreach (string bit in bits) //going through the lines
            {
                // Debug.Log(bit + " \n");
                string[] bits2 = bit.Split(',');
                foreach (string temp in bits2) //going through the lines
                {
                    float temp2 = float.Parse(temp);
                    if (count == 0) { X = temp2; if (X > maxX) { maxX = X; } if (X < minX) { minX = X; } }
                    if (count == 1) { Y = temp2; }
                    if (count == 2) { Z = temp2; }
                    if (count == 3) { rad = temp2; }
                    if (count == 4) { colorX = temp2; }
                    if (count == 5) { colorY = temp2; }
                    if (count == 6)
                    {
                        colorZ = temp2; if (Z > maxZ) { maxZ = Z; }
                        if (Z < minZ) { minX = Z; }
                        x.Add(X);
                        y.Add(Y);
                        z.Add(Z);
                        col1.Add(colorX);
                        col2.Add(colorY);
                        col3.Add(colorZ);
                        /*
                        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        sphere.transform.position = new Vector3((X / 10.0f)-10, (Y / 10.0f) + 80, (Z / 10.0f)+30);
                        sphere.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);
                        sphere.GetComponent<Renderer>().material.color = new Color32((byte)(colorX * 255), (byte)(colorY * 255), (byte)(colorZ * 255), 1);
                        */
                        
                        if (colorX == 0.560784f && colorY == 0.560784f && colorZ == 1f)
                        {
                            GameObject sphe = (GameObject)Instantiate(bluey, new Vector3((X / 10.0f) - 1.5f, (Y / 10.0f) + 74, (Z / 10.0f) + 263.5f), transform.rotation);
                            sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);

                        }
                        if (colorX == 0.784314f && colorY == 0.784314f && colorZ == 0.784314f)
                        {
                            GameObject sphe = (GameObject)Instantiate(grey, new Vector3((X / 10.0f) - 1.5f, (Y / 10.0f) + 74, (Z / 10.0f) + 263.5f), transform.rotation);
                            sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f); sphe.AddComponent<MeshRenderer>();
                            sphe.AddComponent<MeshFilter>(); meshFilters[count2] = sphe.GetComponent<MeshFilter>(); count2++;
                        }
                        if (colorX == 0.941176f && colorY == 0f && colorZ == 0f)
                        {
                            GameObject sphe = (GameObject)Instantiate(red, new Vector3((X / 10.0f) - 1.5f, (Y / 10.0f) + 74, (Z / 10.0f) + 263.5f), transform.rotation);
                            sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);
                        }
                        if (colorX == 1f && colorY == 0.784314f && colorZ == 0.196078f)
                        {
                            GameObject sphe = (GameObject)Instantiate(yellow, new Vector3((X / 10.0f) - 1.5f, (Y / 10.0f) + 74, (Z / 10.0f) + 263.5f), transform.rotation);
                            sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);
                        }
                        if (colorX == 1f && colorY == 0.647059f && colorZ == 0f)
                        {
                            GameObject sphe = (GameObject)Instantiate(lightblue, new Vector3((X / 10.0f) - 1.5f, (Y / 10.0f) + 74, (Z / 10.0f) + 263.5f), transform.rotation);
                            sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);
                        }
                        if (colorX == 0.5f && colorY == 0.5f && colorZ == 0.5f)
                        {
                            GameObject sphe = (GameObject)Instantiate(lightgrey, new Vector3((X / 10.0f) - 1.5f, (Y / 10.0f) + 74, (Z / 10.0f) + 263.5f), transform.rotation);
                            sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);
                        }
                        if (colorX == 0.164706f && colorY == 0.501961f && colorZ == 0.164706f)
                        {
                            GameObject sphe = (GameObject)Instantiate(green, new Vector3((X / 10.0f) - 1.5f, (Y / 10.0f) + 74, (Z / 10.0f) + 263.5f), transform.rotation);
                            sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);
                        }

                        //GameObject sphe = (GameObject)Instantiate(sp, new Vector3((X / 10.0f) - 10, (Y / 10.0f) + 80, (Z / 10.0f) + 30), transform.rotation);
                        //sphe.transform.localScale = new Vector3(rad / 7.0f, rad / 7.0f, rad / 7.0f);
                        //sphe.GetComponent<Renderer>().material.color = Color.red;
                        //sphe.AddComponent<MeshRenderer>();
                        //sphe.AddComponent<MeshFilter>();
                        //sphe.GetComponent<Renderer>().material.color = Color.black;
                        //DestroyImmediate(sp, true);
                        //Destroy(sphere);

                    }
                    count++;
                    if (count == 7) { count = 0; }
                }

            }
            
            CombineInstance[] combine = new CombineInstance[meshFilters.Length];
            int i = 0;
            while (i < meshFilters.Length)
            {
                combine[i].mesh = meshFilters[i].sharedMesh;
                combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
                meshFilters[i].gameObject.active = false;
                i++;
            }
            transform.GetComponent<MeshFilter>().mesh = new Mesh();
            transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            transform.gameObject.active = true;
            render2 = false;
        }
    }


}
