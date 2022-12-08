using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNav : MonoBehaviour
{
    public EinschaltLect einschaltScript;
    public SicherheitLect sicherheitScript;
    public SicherheitTasks sicherheitTaskScript;
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
                currTaskList = einschaltScript.taskObjects;
                break;
            case "Sicherheit":
                currDescList = sicherheitScript.descObjects;
                currTaskList = sicherheitScript.taskObjects;
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
            ArrowL.SetActive(false);
            currIndex--;
        }
        else if (currIndex == currDescList.Count - 1)
        {
            currDescList[currIndex - 1].SetActive(true);
            currTaskList[currIndex - 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex].SetActive(false);
            ArrowR.SetActive(true);
            if (currDescList.Count == 2)
            {
                ArrowL.SetActive(false);
            }
            currIndex--;
        }
        sicherheitTaskScript.checkCurrTask = true;
    }

    public void setArrowR()
    {
        if (currIndex > 0 && currIndex < currDescList.Count - 1)
        {
            currDescList[currIndex + 1].SetActive(true);
            currTaskList[currIndex + 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex].SetActive(false);
            ArrowR.SetActive(false);
            currIndex++;
        }
        else if (currIndex == 0)
        {
            currDescList[currIndex + 1].SetActive(true);
            currTaskList[currIndex + 1].SetActive(true);
            currDescList[currIndex].SetActive(false);
            currTaskList[currIndex].SetActive(false);
            ArrowL.SetActive(true);
            if (currDescList.Count == 2)
            {
                ArrowR.SetActive(false);
            }
            currIndex++;
        }
        sicherheitTaskScript.checkCurrTask = true;
    }
}

