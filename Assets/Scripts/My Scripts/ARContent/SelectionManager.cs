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
    public List<GameObject> screenObjs = new List<GameObject>();
    [HideInInspector]
    public LectManager manageLScript;
    public string currLectName;
    int add;
    [HideInInspector]
    public GameObject arrows;


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
        currAR.GetComponent<LectManager>().setLectureValues(add, currAR, currCtrl);
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