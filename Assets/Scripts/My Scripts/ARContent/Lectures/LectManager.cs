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
    bool resetIndex = true;
    bool start, resetArrows = true;
    [HideInInspector]
    public bool check = true;

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

    /**  ADD  **/

    public void addContent(GameObject currAR, GameObject currCtrl)
    {
        // TO DO: desc on control panel
        currAR.SetActive(true);
        currCtrl.SetActive(true);
        if (resetIndex)
        {
            start = true;
            resetIndex = false;
        }
        
        int i = 0;
        if (start == true)
        {
            foreach (Transform child in currCtrl.GetComponent<Transform>())
            {
                descObjects.Add(child.gameObject);
                if (i == 0 && selectScript.currLectName != "Allgemein")
                {
                    descObjects[i].SetActive(true);
                }
                else if (selectScript.currLectName != "Allgemein")
                    {
                    descObjects[i].SetActive(false);
                }
                i++;
              
            }
            i = 0;
            foreach (Transform child in currAR.GetComponent<Transform>())
            {
                taskObjects.Add(child.gameObject);
                if (i == 0 && selectScript.currLectName != "Allgemein")
                {
                    taskObjects[i].SetActive(true);
                }
                else if(selectScript.currLectName != "Allgemein")
                {
                    taskObjects[i].SetActive(false);
                }
                i++;
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
            case "Sicherheit":
                currAR.GetComponent<SicherheitTasks>().handIcons.SetActive(true);
                break;
            case "Bremsen":
                break;
            //case "Verzerrung":
            //    break;
            case "Tracking":
                if (check == true)
                {
                    var script = currAR.GetComponent<TrackingTasks>();
                    script.checkCurrTask = true;
                }
                break;
            //case "Homing":
            //    break;
            case "Diagnose":
                break;
            //case "Resposition":
            //    break;
            case "Koordsys":
                studioEnv.SetActive(true);
                break;
            case "Laser":
                break;
            case "Vermessen":
                studioEnv.SetActive(true);
                break;
                //case "Verschieben":
                //    break;
                //case "Nivellieren":
                //    break;
        }

    }

    /**  REMOVE  **/

    public void removeContent(GameObject currAR, GameObject currCtrl)
    {
      
        currAR.SetActive(false);
        currCtrl.SetActive(false);
        resetIndex = true;
        if (descObjects.Count > 1 && selectScript.currLectName != "Allgemein")
        {
            arrowScript.currIndex = 0;
            selectScript.arrows.transform.GetChild(0).gameObject.SetActive(false);
            selectScript.arrows.transform.GetChild(1).gameObject.SetActive(true);
            arrowScript.gameObject.SetActive(false);
        }

        switch (selectScript.currLectName)
        {
           case "Allgemein":
                currAR.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                disableDesc("all");
                break;
            case "Einschalt":
                EinschaltTasks einschaltScript = GameObject.Find("Player").GetComponent<EinschaltTasks>();
                einschaltScript.enabled = false;
                break;
            case "Sicherheit":
                currAR.GetComponent<SicherheitTasks>().resetTScript();
                break;
            case "Bremsen":
                currAR.GetComponent<BremsenTasks>().resetTScript();
                //currAR.GetComponent<TrackingTasks>().checkCurrTask = false;
                break;
            //case "Verzerrung":
            //    break;
            case "Tracking":
                currAR.GetComponent<TrackingTasks>().resetTScript();
                //disableDesc("only-colors");
                break;
            case "Homing":
                currAR.GetComponent<HomingTasks>().resetTScript();
                break;
            case "Diagnose":
                currAR.GetComponent<DiagnoseTasks>().resetTScript();
                //gameObject.GetComponent<DiagnoseTasks>().switchBtn.tag = "Untagged";
                //raycastScript.raycasting = false;
                break;
            //case "Resposition":
            //    break;
            case "Koordsys":
                currAR.GetComponent<KoordsysTasks>().resetTScript();
                studioEnv.SetActive(false);
                break;
            case "Laser":
                currAR.GetComponent<LaserTasks>().resetTScript();
                break;
            case "Vermessen":
                currAR.GetComponent<VermessenTasks>().resetTScript();
                studioEnv.SetActive(false);
                break;
                //case "Verschieben":
                //    break;
                //case "Nivellieren":
                //    break;
        }

        resetArrows = true;
    }


    public void disableDesc(string type)
    {
        if (type == "one")
        {
            foreach (GameObject desc in descObjects)
            {
                desc.SetActive(false);
            }

            foreach (GameObject note in taskObjects)
            {
                note.GetComponent<ChangeColor>().setColor(false);
            }
        } else if (type == "all")
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
        } else if (type == "only-colors")
        {
            foreach (GameObject note in taskObjects)
            {
                note.GetComponent<ChangeColor>().setColor(false);
            }
        } else if (type == "draw-lined")
        {
            foreach (GameObject note in taskObjects)
            {
                note.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
            }
        }

        check = true;
        
    }
}
