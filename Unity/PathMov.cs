using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PathMov : MonoBehaviour {

    public GameObject player;
    public GameObject membTop;
    public GameObject membBot;
    private int count = 0;

    public GameObject elec2;
    public GameObject elec3;
    public GameObject elec4;

    public GameObject hone;
    public GameObject htwo;

    public Text HowLook;
    public Text FirstPer;

    // Use this for initialization
    void Start ()
    {

        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("toShew"),
                                          "time", 3, 
                                          "easetype", iTween.EaseType.easeInOutSine, 
                                          "oncomplete", "showShewInfo"));
        iTween.Pause(player);
        HowLook.CrossFadeAlpha(0.0f, 0.0f, false);
        FirstPer.CrossFadeAlpha(0.0f, 0.0f, false);
        Fin.CrossFadeAlpha(0.0f, 0.0f, false);
        count++;
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetButton("Tap"))
        {
            iTween.Resume(player);
            iTween.Resume(electron);
            iTween.Resume(STC);
            iTween.Resume(elec2);
            iTween.Resume(elec3);
            iTween.Resume(elec4);
            iTween.Resume(hone);
            iTween.Resume(htwo);
            iTween.FadeTo(membInfo, 0f, 0.5f);
            iTween.FadeTo(mtrcabInfo, 0f, 0.5f);
            iTween.FadeTo(STCinfo, 0f, 0.5f);
            iTween.FadeTo(CYMAInfo, 0f, 0.5f);
            iTween.FadeTo(QUINOLInfo, 0f, 0.5f);
            iTween.FadeTo(HInfo, 0f, 0.5f);
            if (count >= 2)
            {
                HowLook.CrossFadeAlpha(1.0f, 1.0f, false);
            }
            if (count >= 7)
            {
                FirstPer.CrossFadeAlpha(1.0f, 1.0f, false);
            }
            if (count >= 8)
            {
                Fin.CrossFadeAlpha(1.0f, 1.0f, false);
            }

        }
	}

    public GameObject shewInfo;

    void showShewInfo()
    {
        iTween.FadeTo(shewInfo, 1f, 1f);
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("toMemb"), 
                                          "time", 10, 
                                          "easetype", iTween.EaseType.easeInOutSine, 
                                          "oncomplete", "startHToSpace"));
        iTween.Pause(player);
        count++;
    }

    public GameObject shew;
    public GameObject membInfo;
    public GameObject mtrcabInfo;
    public GameObject electron;
    public GameObject STC;

    void startMemb()
    {
        
        Destroy(shewInfo);
        Destroy(shew);

        iTween.FadeTo(membInfo, 1f, 1f);
        iTween.FadeTo(mtrcabInfo, 1f, 1f);
        iTween.MoveTo(electron, iTween.Hash("path", iTweenPath.GetPath("electron_path_four"),
                                          "time", 6,
                                          "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(STC, iTween.Hash("path", iTweenPath.GetPath("stc_path_three"),
                                          "time", 6,
                                          "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("track"),
                                          "time", 6,
                                          "easetype", iTween.EaseType.easeInOutSine,
                                          "oncomplete", "startFirstPerson"));

        iTween.Pause(electron);
        iTween.Pause(STC);
        iTween.Pause(player);
        count++;
    }

    public GameObject STCinfo;

    void startSTC()
    {
        iTween.FadeTo(STCinfo, 1f, 1f);

        iTween.MoveTo(electron, iTween.Hash("path", iTweenPath.GetPath("stc_path_two"),
                                          "time", 6,
                                          "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(STC, iTween.Hash("path", iTweenPath.GetPath("electron_path_three"),
                                          "time", 6,
                                          "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("track2"),
                                          "time", 6,
                                          "easetype", iTween.EaseType.easeInOutSine,
                                          "oncomplete", "startMemb"));

        iTween.Pause(player);
        iTween.Pause(electron);
        iTween.Pause(STC);
        count++;
    }

    public GameObject CYMAInfo;

    void startCYMA()
    {
        iTween.FadeTo(CYMAInfo, 1f, 1f);
        iTween.MoveTo(electron, iTween.Hash("path", iTweenPath.GetPath("stc_path"),
                                          "time", 7,
                                          "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(STC, iTween.Hash("path", iTweenPath.GetPath("electron_path_two"),
                                          "time", 3,
                                          "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("track3"),
                                          "time", 6,
                                          "easetype", iTween.EaseType.easeInOutSine,
                                          "oncomplete", "startSTC"));
        iTween.MoveTo(elec2, iTween.Hash("path", iTweenPath.GetPath("electwo2"),
                                          "time", 7,
                                          "easetype", iTween.EaseType.easeInOutSine,
                                          "oncomplete", "startSTC"));
        iTween.MoveTo(elec3, iTween.Hash("path", iTweenPath.GetPath("electhree2"),
                                          "time", 7,
                                          "easetype", iTween.EaseType.easeInOutSine,
                                          "oncomplete", "startSTC"));
        iTween.MoveTo(elec4, iTween.Hash("path", iTweenPath.GetPath("elecfour2"),
                                          "time", 7,
                                          "easetype", iTween.EaseType.easeInOutSine,
                                          "oncomplete", "startSTC"));

        iTween.Pause(player);
        iTween.Pause(electron);
        iTween.Pause(STC);
        iTween.Pause(elec2);
        iTween.Pause(elec3);
        iTween.Pause(elec4);
        count++;
    }

    public GameObject QUINOLInfo;

    void startQUINOL()
    {
        iTween.FadeTo(QUINOLInfo, 1f, 1f);
        iTween.MoveTo(elec2, iTween.Hash("path", iTweenPath.GetPath("electwo"),
                                         "time", 3,
                                         "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(elec3, iTween.Hash("path", iTweenPath.GetPath("electhree"),
                                         "time", 3,
                                         "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(elec4, iTween.Hash("path", iTweenPath.GetPath("elecfour"),
                                         "time", 3,
                                         "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(electron, iTween.Hash("path", iTweenPath.GetPath("electron_path"),
                                         "time", 3,
                                         "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(hone, iTween.Hash("path", iTweenPath.GetPath("hone_two"),
                                         "time", 3,
                                         "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(htwo, iTween.Hash("path", iTweenPath.GetPath("htwo_two"),
                                         "time", 3,
                                         "easetype", iTween.EaseType.easeInOutSine));
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("track4"),
                                          "time", 3,
                                          "easetype", iTween.EaseType.easeInOutSine,
                                          "oncomplete", "startCYMA"));
        iTween.Pause(player);
        iTween.Pause(elec2);
        iTween.Pause(elec3);
        iTween.Pause(elec4);
        iTween.Pause(electron);
        iTween.Pause(hone);
        iTween.Pause(htwo);
        count++;
    }

    public GameObject HInfo;

    void startHToSpace()//not working????
    {
        iTween.FadeTo(HInfo, 1f, 1f);

        iTween.MoveTo(hone, iTween.Hash("path", iTweenPath.GetPath("hone_one"),
                                         "time", 3,
                                         "easetype", iTween.EaseType.easeInQuart));
        iTween.MoveTo(htwo, iTween.Hash("path", iTweenPath.GetPath("htwo_one"),
                                        "time", 3,
                                        "easetype", iTween.EaseType.easeInQuart));
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("track5"),
                                        "time", 3,
                                        "easetype", iTween.EaseType.easeInQuart,
                                         "oncomplete", "startQUINOL"));

        iTween.Pause(hone);
        iTween.Pause(htwo);
        iTween.Pause(player);
        count++;
    }

    void startFirstPerson()
    {
        iTween.MoveTo(player, iTween.Hash("path", iTweenPath.GetPath("track6"),
                                         "time", 110,
                                         "easetype", iTween.EaseType.easeInOutSine,
                                         "oncomplete","showFin"));
        iTween.Pause(player);
        count++;
    }

    public Text Fin;

    void showFin()
    {
        count++;
    }
}
