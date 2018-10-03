using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PathMov : MonoBehaviour {

    public GameObject camera;
    public GameObject player;
    
    private int count = 0;
    
    bool started = false;
    bool started2 = false;
    bool check = false;
    float speed = 10;
    bool freeroamval = false;
    bool lockVal = false;
    private bool old = false;
    private bool newRoute = false;
    public bool move = false;

    Renderer rend;
    Renderer rend2;
    Renderer rend3;
    Renderer rend4;

    // Use this for initialization
    void Start ()
    {
        rend = Info.GetComponent<Renderer>();
        rend.enabled = false;
        rend2 = Info1.GetComponent<Renderer>();
        rend2.enabled = false;
        rend3 = Info2.GetComponent<Renderer>();
        rend3.enabled = false;
        rend4 = Info3.GetComponent<Renderer>();
        rend4.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (!started) {
                StructurePath();
            }
                started = true;
            iTween.Resume(player);
            //fades info baords
            iTween.FadeTo(Info, 0f, 0.5f);
            iTween.FadeTo(Info1, 0f, 0.5f);
            iTween.FadeTo(Info2, 0f, 0.5f);
            iTween.FadeTo(Info3, 0f, 0.5f);
            move = false;
        }
        freeRoam();
    }
    void freeRoam()
    {
        // move method
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = transform.position + Camera.main.transform.right * -speed * Time.deltaTime * -Input.GetAxis("Horizontal");check = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position = transform.position + Camera.main.transform.right * -speed * Time.deltaTime * -Input.GetAxis("Horizontal"); check = true;
        }
        if (Input.GetAxis("Horizontalleft") > 0)
        {
            transform.position = transform.position + Camera.main.transform.right * -speed * Time.deltaTime * -Input.GetAxis("Horizontalleft"); check = true;
        }
        if (Input.GetAxis("Horizontalleft") < 0)
        {
            transform.position = transform.position + Camera.main.transform.right * -speed * Time.deltaTime * -Input.GetAxis("Horizontalleft"); check = true;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position = transform.position + Camera.main.transform.forward * -speed * Time.deltaTime; check = true;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime; check = true;
        }
        if (Input.GetAxis("Verticalright") < 0)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime * Input.GetAxis("Verticalright"), 0)); check = true;
        }
        if (Input.GetAxis("Verticalright") > 0)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime * -Input.GetAxis("Verticalright"), 0)); check = true;
        }
        if (check)
        {
            speed += 0.05f;
        }
        else
        {
            speed = 20;
        }
        check = false;
    }
   
    
   
    void StructurePath()
    {
        //move to structure
        rend.enabled = true;
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("StructurePath1"),
                                         "time", 10,
                                         "easetype", iTween.EaseType.easeInOutSine,
                                         "oncomplete", "StructurePath1"));
        iTween.Pause(player);
    }
    public GameObject Info;
    void StructurePath1()
    {
        //move to first
        rend2.enabled = true;
        rend3.enabled = true;
        rend4.enabled = true;
        iTween.FadeTo(Info, 1f, 1f);
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("StructurePath2"),
                                         "time", 10,
                                         "easetype", iTween.EaseType.easeInOutSine,
                                         "oncomplete", "StructurePath2"));
        iTween.Pause(player);
    }
    public GameObject Info1;
    void StructurePath2()
    {
        //move to second
        iTween.FadeTo(Info1, 1f, 1f);
        
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("StructurePath3"),
                                         "time", 10,
                                         "easetype", iTween.EaseType.easeInOutSine,
                                         "oncomplete", "StructurePath3"));
        iTween.Pause(player);
    }
    public GameObject Info2;
    void StructurePath3()
    {
        //move to third
        iTween.FadeTo(Info2, 1f, 1f); 
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("StructurePath4"),
                                         "time", 10,
                                         "easetype", iTween.EaseType.easeInOutSine,
                                         "oncomplete", "StructurePath4"));
        iTween.Pause(player);
    }
    public GameObject Info3;
    void StructurePath4()
    {
        //move back to start
        iTween.FadeTo(Info3, 1f, 1f);
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("StructurePath5"),
                                         "time", 10,
                                         "easetype", iTween.EaseType.easeInOutSine
                                        ));
        iTween.Pause(player);
    }
}
