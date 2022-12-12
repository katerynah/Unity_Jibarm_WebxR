using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNav : MonoBehaviour
{
    public EinschaltLect einschaltScript;
    public SicherheitLect sicherheitScript;
    public SicherheitTasks sicherheitTaskScript;
    public DiagnoseLect diagnoseScript;
    public DiagnoseTasks diagnoseTaskScript;
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
        switch (selectScript.currLectName)
        {
            case "Einschalt":
                currDescList = einschaltScript.checkObjects;
                currTaskList = einschaltScript.tasksObjects;
                break;
            case "Sicherheit":
                currDescList = sicherheitScript.descObjects;
                currTaskList = sicherheitScript.taskObjects;
                break;
            case "Diagnose":
                currDescList = diagnoseScript.descObjects;
                currTaskList = diagnoseScript.taskObjects;
                Debug.Log($"Curr -1 is { currDescList.Count - 1}");
                break;
        }
    }

    public void setArrowL()
    {
        if (currIndex > 0 && currIndex < currDescList.Count - 1)
        {
            currDescList[currIndex - 1].SetActive(true);
            currTaskList[currIndex - 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex].SetActive(false);
            if (currIndex == 1)
            {
                ArrowL.SetActive(false);
            }
            //ArrowL.SetActive(false);
            currIndex--;
        }
        else if (currIndex == currDescList.Count - 1)
        {
            currDescList[currIndex - 1].SetActive(true);
            currTaskList[currIndex - 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex].SetActive(false);
            ArrowR.SetActive(true);
            //if (currDescList.Count == 2)
            //{
            //    ArrowL.SetActive(false);
            //}
            currIndex--;

        }

        resetCheck();
    }

    public void setArrowR()
    {
        if (currIndex > 0 && currIndex < currDescList.Count - 1)
        {
            currDescList[currIndex + 1].SetActive(true);
            currTaskList[currIndex + 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex].SetActive(false);
            if (currIndex == currDescList.Count - 2)
            {
                ArrowR.SetActive(false);
            }
            currIndex++;

        }
        else if (currIndex == 0)
        {
            currDescList[currIndex + 1].SetActive(true);
            currTaskList[currIndex + 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex].SetActive(false);
            ArrowL.SetActive(true);
            //if (currDescList.Count == 2)
            //{
            //    ArrowR.SetActive(false);
            //}
            currIndex++;

        }
        resetCheck();
    }

    void resetCheck()
    {
        switch (selectScript.currLectName)
        {
            case "Sicherheit":
                sicherheitTaskScript.checkCurrTask = true;
                break;
            case "Diagnose":
                diagnoseTaskScript.checkCurrTask = true;
                break;
        }
    }
}

