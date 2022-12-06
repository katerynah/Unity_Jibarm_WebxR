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
    public AllgemeinLect allgemeinScript;
    public EinschaltLect einschaltScript;
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
                if (add == 0)
                {
                    allgemeinScript.addContent(currAR, currCtrl);
                } else if (add == 1)
                {
                    allgemeinScript.removeContent(currAR, currCtrl);
                } else
                {
                    Debug.LogError("Check SelectionManager.cs SwitchAR addARContent-values (should be 0 or 1)");
                }
                break;
            case "Einschalt":
                if (add == 0)
                {
                    einschaltScript.addContent(currAR, currCtrl);
                }
                else if (add == 1)
                {
                    einschaltScript.removeContent(currAR, currCtrl);
                }
                else
                {
                    Debug.LogError("Check SelectionManager.cs SwitchAR addARContent-values (should be 0 or 1)");
                }
                // Task Window in Control View
                // Check-Title -> Task description and arrows to change task
                // Firework in the end
                // 1. StahlSeilen 1, 2
                // 2. Kamera drehen
                // 3. WAK ?
                // 4. When pause Screen off ?
                break;
            case "Sicherheit":
                // 1. Animation with some guy who isn't allowed
                // 2. 4 Points auch Jacks sammeln
                // 3. 
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
                break;
            case "Resposition":
                break;
            case "Koordsys":
                break;
            case "Landmarks":
                break;
            case "Laser":
                break;
            case "Vermessen":
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