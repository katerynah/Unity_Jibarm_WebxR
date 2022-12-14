using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    //public enum Lectures
    //{
    //    Allgemein, Einschalt, Sicherheit, Bremsen, Verzerrung,
    //    Tracking, Homing, Diagnose, Resposition, Koordsys, Landmarks, Laser, Vermessen, Verschieben, Nivellieren
    //}
    // public Lectures UseAs;

    [HideInInspector]
    public GameObject currLect, currAR, currCtrl;
    [HideInInspector]
    public AllgemeinLect allgemeinScript;
    [HideInInspector]
    public EinschaltLect einschaltScript;
    [HideInInspector]
    public DiagnoseLect diagnoseScript;
    [HideInInspector]
    public KoordsysLect koordsysScript;
    [HideInInspector]
    public KoordsysLect vermessenScript;
    public string currLectName;
    int add;

    public void selectLecture(int assignARContent)
    {
        add = assignARContent;
        // Find Lecture Section
        currLect = GameObject.FindGameObjectWithTag("text-on") != null ? GameObject.FindGameObjectWithTag("text-on") : GameObject.FindGameObjectWithTag("off");
        var btnName = currLect.name;
        var adaptString = btnName.Replace("-tbox", "");
        currLectName = adaptString;

        // Find AR Section for this Lecture
        chooseAR();

        // Find Control Section for this Lecture
        chooseControl();

        // direct to Section script
        switchAR();
    }


    public void switchAR()
    {
        switch (currLectName)
        {
            case "Allgemein":
                // go to Section Script and give important infos
                currAR.GetComponent<AllgemeinLect>().setLectureValues(add, currAR, currCtrl);
                break;
            case "Einschalt":
                currAR.GetComponent<EinschaltLect>().setLectureValues(add, currAR, currCtrl);
                // 4. WAK ?
                break;
            case "Sicherheit":
                // Drag rotation 
                currAR.GetComponent<SicherheitLect>().setLectureValues(add, currAR, currCtrl);
                break;
            case "Bremsen":
                //
                //
                break;
            case "Verzerrung":
                break;
            case "Tracking":
                break;
            case "Homing":
                // Dreiecks 1, 2, 3
                //
                break;
            case "Diagnose":
                currAR.GetComponent<DiagnoseLect>().setLectureValues(add, currAR, currCtrl);
                break;
            case "Resposition":
                break;
            case "Koordsys":
                currAR.GetComponent<KoordsysLect>().setLectureValues(add, currAR, currCtrl);
                break;
            case "Landmarks":
                break;
            case "Laser":
                break;
            case "Vermessen":
                currAR.GetComponent<VermessenLect>().setLectureValues(add, currAR, currCtrl);
                break;
            case "Verschieben":
                break;
            case "Nivellieren":
                break;
        }
    }

    public void chooseAR()
    {
        var name = currLectName.Insert(currLectName.Length, "-ar");
        var objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject obj in objects)
        {
            if (obj.name == name)
            {
                currAR = obj;
            }
        }
    }

    public void chooseControl()
    {
        var name = currLectName.Insert(currLectName.Length, "-ctrl");
        var objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject obj in objects)
        {
            if (obj.name == name)
            {
                currCtrl = obj;
            }
        }
    }

}