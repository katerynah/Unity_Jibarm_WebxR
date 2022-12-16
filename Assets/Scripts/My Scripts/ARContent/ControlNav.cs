using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNav : MonoBehaviour
{
    public SelectionManager selectScript;
    public GameObject ArrowL, ArrowR;
    List<GameObject> currDescList = new List<GameObject>();
    List<GameObject> currTaskList = new List<GameObject>();

    public int currIndex = 0;

    void Start()
    {
        if (ArrowL.activeSelf == true)
            ArrowL.SetActive(false);
    }


    public void setObjectList()
    {
        currDescList = selectScript.currAR.GetComponent<LectManager>().descObjects;
        currTaskList = selectScript.currAR.GetComponent<LectManager>().taskObjects;
    }

    public void setArrowL()
    {
        if (currIndex > 0 && currIndex < currDescList.Count - 1)
        {
            currDescList[currIndex - 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex - 1].SetActive(true);
            currTaskList[currIndex].SetActive(false);
            // when only 2 object elements
            if (currIndex == 1)
            {
                ArrowL.SetActive(false);
            }
            currIndex--;
        }
        else if (currIndex == currDescList.Count - 1)
        {
            currDescList[currIndex - 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex - 1].SetActive(true);
            currTaskList[currIndex].SetActive(false);
            ArrowR.SetActive(true);
            // when only 2 object elements
            if (currDescList.Count == 2)
            {
                ArrowL.SetActive(false);
            }
            currIndex--;
        }

        resetCheck();
    }

    public void setArrowR()
    {
        if (currIndex > 0 && currIndex < currDescList.Count - 1)
        {
            currDescList[currIndex + 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex + 1].SetActive(true);
            currTaskList[currIndex].SetActive(false);
        // when only 2 object elements
            if (currIndex == currDescList.Count - 2)
            {
                ArrowR.SetActive(false);
            }
            currIndex++;

        }
        else if (currIndex == 0)
        {
            currDescList[currIndex + 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex + 1].SetActive(true);
            currTaskList[currIndex].SetActive(false);
            ArrowL.SetActive(true);
            // when only 2 object elements
            if (currDescList.Count == 2)
            {
                ArrowR.SetActive(false);
            }
            currIndex++;
        }
       
        resetCheck();
    }

    void resetCheck()
    {
        switch (selectScript.currLectName)
        {
            case "Sicherheit":
                selectScript.currAR.GetComponent<SicherheitTasks>().checkCurrTask = true;
                break;
            case "Bremsen":
                selectScript.currAR.GetComponent<BremsenTasks>().checkCurrTask = true;
                break;
            case "Tracking":
                selectScript.currAR.GetComponent<TrackingTasks>().checkCurrTask = true;
                break;
            case "Diagnose":
                selectScript.currAR.GetComponent<DiagnoseTasks>().checkCurrTask = true;
                break;
            case "Koordsys":
                selectScript.currAR.GetComponent<KoordsysTasks>().checkCurrTask = true;
                break;
            case "Vermessen":
                selectScript.currAR.GetComponent<VermessenTasks>().checkCurrTask = true;
                break;
            
        }
    }
}

