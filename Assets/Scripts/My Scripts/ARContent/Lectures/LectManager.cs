using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectManager : MonoBehaviour
{
    public SelectionManager selectScript;
    public RaycastingAR raycastScript;
    [HideInInspector]
    public List<GameObject> descObjects = new List<GameObject>();
    public GameObject introN, introD;
    List<GameObject> disableScreen = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> taskObjects = new List<GameObject>();
    public ControlNav arrowScript;
    public GameObject studioEnv, player, screenView;
    public List<GameObject> checkMarksCheck = new List<GameObject>();
    bool resetWires, forIntro = false;
    bool resetIndex, start, resetArrows, resetPos, intro, addItems = true;
    [HideInInspector]
    public bool check = true;
    public JibArmValues jibValuesScript;
    List<Vector3> positions = new List<Vector3>();
    List<Quaternion> rotations = new List<Quaternion>();


    public bool raycasting = false;

    private void Start()
    {
        disableScreen = selectScript.screenObjs;
    }

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
        if (resetPos == true)
        {
            jibValuesScript.setTheValues();
            resetPos = false;
        }

        // Jib
        // Arm Tilt
        // Arm Pan
        // Kamera Tilt
        // Kamera Pan



        // TO DO: desc on control panel
        currAR.SetActive(true);
        currCtrl.SetActive(true);
        if (resetIndex)
        {
            start = true;
            resetIndex = false;
        }

        int i = 0;
        if (addItems == true)
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
                else if (selectScript.currLectName != "Allgemein")
                {
                    taskObjects[i].SetActive(false);
                }
                i++;
            }
            addItems = false;
        }

        if (descObjects.Count > 1 && selectScript.currLectName != "Allgemein")
        {
            arrowScript.gameObject.SetActive(true);
            arrowScript.setObjectList();
        }

        if (selectScript.currLectName == "Einschalt")
        {
            player.GetComponent<EinschaltTasks>().enabled = true;
        }
        else
        {
            player.GetComponent<EinschaltTasks>().enabled = false;
        }

        if (selectScript.currLectName != "Allgemein")
        {
            introN.SetActive(false);
            introD.SetActive(false);
        }

        switch (selectScript.currLectName)
        {
            case "Allgemein":
                if (intro == true)
                {
                    introD.SetActive(true);
                    introN.SetActive(true);
                    intro = false;
                }
                if (GameObject.FindGameObjectWithTag("jibarm") == true && GameObject.FindGameObjectWithTag("jibarm").transform.position.y < 0)
                {
                    currAR.GetComponent<DrawLineBetweenTwoObjects>().setLines("all");
                    //currAR.GetComponent<DrawLineBetweenTwoObjects>().setLines("one");
                }
                break;
            case "Einschalt":
                EinschaltTasks einschaltScript = GameObject.Find("Player").GetComponent<EinschaltTasks>();
                einschaltScript.enabled = true;
                einschaltScript.triggerOn = true;
                einschaltScript.startTScript();
                break;
            case "Sicherheit":
                //currAR.GetComponent<SicherheitTasks>().handIcons.SetActive(true);
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
            case "Verschieben":
                studioEnv.SetActive(true);
                break;
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
        if (selectScript.currLectName != "Allgemein")
        {
            if (descObjects.Count > 1)
            {
                arrowScript.currIndex = 0;
                selectScript.arrows.transform.GetChild(0).gameObject.SetActive(false);
                selectScript.arrows.transform.GetChild(1).gameObject.SetActive(true);
                arrowScript.gameObject.SetActive(false);
            }

        }


        switch (selectScript.currLectName)
        {
            case "Allgemein":
                currAR.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();

                //introN.SetActive(true);
                //introD.SetActive(true);
                intro = true;
                foreach (GameObject note in taskObjects)
                {
                    note.GetComponent<ChangeColor>().setColor(false);
                }

                foreach (GameObject child in descObjects)
                {
                    child.SetActive(false);
                }
                break;
            case "Einschalt":
                EinschaltTasks einschaltScript = GameObject.Find("Player").GetComponent<EinschaltTasks>();
                einschaltScript.resetTScript();
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
                resetScreenUI();
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
                resetScreenUI();
                break;
            case "Vermessen":
                currAR.GetComponent<VermessenTasks>().resetTScript();
                studioEnv.SetActive(false);
                resetScreenUI();
                break;
            case "Verschieben":
                studioEnv.SetActive(false);
                var objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
                foreach (GameObject obj in objects)
                {
                    if (obj.name == "Play-bgd")
                    {
                        obj.SetActive(false);
                    }
                }
                currAR.GetComponent<VerschiebenTasks>().resetTScript();
                break;
            case "Nivellieren":
                currAR.GetComponent<NivellierenTasks>().resetTScript();
                break;
        }


        if (resetPos == false && jibValuesScript.start == false)
        {
            jibValuesScript.resetTheValues();
            resetPos = true;
        }

        if (selectScript.currLectName != "Allgemein")
        {
            int h = 0;
            foreach (GameObject obj in descObjects)
            {
                if (h == 0)
                {
                    obj.SetActive(true);
                    taskObjects[h].SetActive(true);
                }
                else
                {
                    obj.SetActive(false);
                    taskObjects[h].SetActive(false);
                }
                h++;
            }
        }
        arrowScript.currIndex = 0;
        resetArrows = true;
        resetPos = true;
    }

    void resetScreenUI()
    {
        foreach (GameObject menu in disableScreen)
        {
            menu.SetActive(false);
        }
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
        }
        else if (type == "all")
        {
            int i = 0;
            foreach (GameObject desc in descObjects)
            {
                if (i != 0)
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
        else if (type == "only-colors")
        {
            int i = 0;
            foreach (GameObject note in taskObjects)
            {

                if (i != 0 && selectScript.currLectName == "Allgemein")
                {
                    note.GetComponent<ChangeColor>().setColor(false);
                }
                i++;
            }
            i = 0;
            foreach (GameObject desc in descObjects)
            {
                if (i != 0 && selectScript.currLectName == "Allgemein")
                {
                    desc.SetActive(false);
                }
                i++;
            }
        }
        else if (type == "draw-lined")
        {
            foreach (GameObject note in taskObjects)
            {
                note.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
            }
        }

        check = true;

    }
}