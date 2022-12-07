using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNav : MonoBehaviour
{
    public EinschaltLect einschaltScript;
    public GameObject ArrowL, ArrowR;

    public int taskIndex = 0;

    void Start()
    {
        if (ArrowL.activeSelf == true)
        ArrowL.SetActive(false);
    }

    public void setArrowL()
    {
        if (taskIndex > 0 && taskIndex < einschaltScript.checkObjects.Count - 1)
        {
            einschaltScript.checkObjects[taskIndex - 1].SetActive(true);
            einschaltScript.taskObjects[taskIndex - 1].SetActive(true);
            einschaltScript.checkObjects[taskIndex].SetActive(false);
            einschaltScript.taskObjects[taskIndex].SetActive(false);
            ArrowL.SetActive(false);
            taskIndex--;
        }
        else if (taskIndex == einschaltScript.checkObjects.Count - 1)
        {
            einschaltScript.checkObjects[taskIndex - 1].SetActive(true);
            einschaltScript.taskObjects[taskIndex - 1].SetActive(true);
            einschaltScript.checkObjects[taskIndex].SetActive(false);
            einschaltScript.taskObjects[taskIndex].SetActive(false);
            ArrowR.SetActive(true);
            taskIndex--;
        }
    }

    public void setArrowR()
    {
        if (taskIndex > 0 && taskIndex < einschaltScript.checkObjects.Count - 1)
        {
            einschaltScript.checkObjects[taskIndex + 1].SetActive(true);
            einschaltScript.taskObjects[taskIndex + 1].SetActive(true);
            einschaltScript.checkObjects[taskIndex].SetActive(false);
            einschaltScript.taskObjects[taskIndex].SetActive(false);
            ArrowR.SetActive(false);
            taskIndex++;
        }
        else if (taskIndex == 0)
        {
            einschaltScript.checkObjects[taskIndex + 1].SetActive(true);
            einschaltScript.taskObjects[taskIndex + 1].SetActive(true);
            einschaltScript.checkObjects[taskIndex].SetActive(false);
            einschaltScript.taskObjects[taskIndex].SetActive(false);
            ArrowL.SetActive(true);
            taskIndex++;
        }
    }
}

