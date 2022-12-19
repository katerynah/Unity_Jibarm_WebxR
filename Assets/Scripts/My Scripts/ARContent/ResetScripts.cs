using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScripts : MonoBehaviour
{
    public int savedArrowIndex;
    SelectionManager selectScript;
    int[] arrowIndex;

    void Start()
    {
        selectScript = GameObject.Find("SelectionManager").GetComponent<SelectionManager>();
    }

    public void setValuesBack()
    {
        switch (selectScript.currLectName)
        {
            case "Allgemein":
                break;
            case "Bremsen":
                break;
            case "Sicherheit":
                break;
            //case "Verzerrung":
            //    break;
            case "Tracking":
                break;
            //case "Homing":
            //    break;
            case "Diagnose":
                break;
            //case "Resposition":
            //    break;
            case "Koordsys":
                break;
            //case "Laser":
            //    break;
            case "Vermessen":
                break;
                //case "Verschieben":
                //    break;
                //case "Nivellieren":
                //    break;
        }
    }
}
