using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNav : MonoBehaviour
{
    public EinschaltLect einschaltScript;
    public GameObject ArrowL, ArrowR;

    int i = 0;

    void Start()
    {
        if (ArrowL.activeSelf == true)
        ArrowL.SetActive(false);
    }

    public void setArrowL()
    {
        if (i > 0 && i < einschaltScript.checkObjects.Count - 1)
        {
            einschaltScript.checkObjects[i - 1].SetActive(true);
            einschaltScript.checkObjects[i].SetActive(false);
            ArrowL.SetActive(false);
            i--;
        }
        else if (i == einschaltScript.checkObjects.Count - 1)
        {
            einschaltScript.checkObjects[i - 1].SetActive(true);
            einschaltScript.checkObjects[i].SetActive(false);
            ArrowR.SetActive(true);
            i--;
        }
    }

    public void setArrowR()
    {
        if (i > 0 && i < einschaltScript.checkObjects.Count - 1)
        {
            einschaltScript.checkObjects[i + 1].SetActive(true);
            einschaltScript.checkObjects[i].SetActive(false);
            ArrowR.SetActive(false);
            i++;
        }
        else if (i == 0)
        {
            einschaltScript.checkObjects[i + 1].SetActive(true);
            einschaltScript.checkObjects[i].SetActive(false);
            ArrowL.SetActive(true);
            Debug.Log($"Arrow L to enable");
            i++;
        }
    }
}

