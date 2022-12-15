using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectManager : MonoBehaviour
{
    public SelectionManager selectScript;
    public RaycastingAR raycastScript;
    [HideInInspector]
    public List<GameObject> descObjects = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> taskObjects = new List<GameObject>();
    public ControlNav arrowScript;
    public GameObject studioEnv, player;
    public List<GameObject> checkMarksCheck = new List<GameObject>();
    bool resetWires = false;
    bool start = true;

    public bool raycasting = false;

    public void setLectureValues(int add, GameObject currAR, GameObject currCtrl)
    {
        if (add == 0)
        {
            addContent(currAR, currCtrl);
        }
        else if (add == 1)
        {
            removeContent(currAR, currCtrl);
        }
        else
        {
            Debug.LogError("Check SelectionManager.cs SwitchAR addARContent-values (should be 0 or 1)");
        }
    }

    void addContent(GameObject currAR, GameObject currCtrl)
    {
        // TO DO: desc on control panel
        currAR.SetActive(true);
        currCtrl.SetActive(true);
        if (start == true)
        {
            foreach (Transform child in currCtrl.GetComponent<Transform>())
            {
                descObjects.Add(child.gameObject);
            }

            foreach (Transform child in currAR.GetComponent<Transform>())
            {
                taskObjects.Add(child.gameObject);
            }
            start = false;
        }

        if (descObjects.Count > 1 && selectScript.currLectName != "Allgemein")
        {
            arrowScript.gameObject.SetActive(true);
            arrowScript.setObjectList();
        }

        if (selectScript.currLectName == "Einschalt")
        {
            player.GetComponent<EinschaltTasks>().enabled = true;
        } else
        {
            player.GetComponent<EinschaltTasks>().enabled = false;
        }

        switch (selectScript.currLectName)
        {
            case "Allgemein":
                 currAR.GetComponent<DrawLineBetweenTwoObjects>().setLines("all");
                break;
            case "Bremsen":
                //foreach (GameObject obj in currAR.GetComponent<BremsenTasks>().spheres)
                //{
                //    obj.SetActive(false);
                //}
                break;
            //case "Verzerrung":
            //    break;
            //case "Tracking":
            //    break;
            //case "Homing":
            //    break;
            case "Diagnose":
                break;
            //case "Resposition":
            //    break;
            case "Koordsys":
                studioEnv.SetActive(true);
                break;
            //case "Landmarks":
            //    break;
            //case "Laser":
            //    break;
            case "Vermessen":
                studioEnv.SetActive(true);
                break;
                //case "Verschieben":
                //    break;
                //case "Nivellieren":
                //    break;
        }
    }

    void removeContent(GameObject currAR, GameObject currCtrl)
    {
      
        currAR.SetActive(false);
        currCtrl.SetActive(false);
        if (descObjects.Count > 1 && selectScript.currLectName != "Allgemein")
        {
            arrowScript.gameObject.SetActive(false);
        }

        switch (selectScript.currLectName)
        {
           case "Allgemein":
                currAR.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                disableDesc("all");
                break;
            case "Bremsen":
                currAR.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                break;
            //case "Verzerrung":
            //    break;
            //case "Tracking":
            //    break;
            //case "Homing":
            //    break;
            case "Diagnose":
                gameObject.GetComponent<DiagnoseTasks>().switchBtn.tag = "Untagged";
                raycastScript.raycasting = false;
                break;
            //case "Resposition":
            //    break;
            case "Koordsys":
                studioEnv.SetActive(false);
                break;
            //case "Landmarks":
            //    break;
            //case "Laser":
            //    break;
            case "Vermessen":
                studioEnv.SetActive(false);
                break;
                //case "Verschieben":
                //    break;
                //case "Nivellieren":
                //    break;
        }
    }


    public void disableDesc(string amount)
    {
        if (amount == "one")
        {
            foreach (GameObject desc in descObjects)
            {
                desc.SetActive(false);
            }

            foreach (GameObject note in taskObjects)
            {
                note.GetComponent<ChangeColor>().setColor(false);
            }
        } else if (amount == "all")
        {
            int i = 0;
            foreach (GameObject desc in descObjects)
            {
                if (i!=0)
                {
                    desc.SetActive(false);
                }
                i++;
            }
            i = 0;
            foreach (GameObject note in taskObjects)
            {
                if (i != 0)
                {
                    note.GetComponent<ChangeColor>().setColor(false);
                }
                i++;
            }
        } 
        
    }
}
