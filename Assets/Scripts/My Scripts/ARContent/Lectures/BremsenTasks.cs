using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BremsenTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    public SetBremsen[] bremsenArmTilt;
    List<GameObject> tasks = new List<GameObject>();
    public List<GameObject> objToRotate = new List<GameObject>();
    public GameObject[] checkboxes;
    public List<GameObject> spheres = new List<GameObject>();
    [HideInInspector]
    public bool checkCurrTask = true;
    public SelectionManager selectScript;
    LectManager manageLScript;

    void Start()
    {
        manageLScript = gameObject.GetComponent<LectManager>();
        descs = manageLScript.descObjects;
        tasks = manageLScript.taskObjects;

        foreach (GameObject obj in spheres)
        {
            obj.SetActive(true);
        }
    }

    void Update()
    {
        if (checkCurrTask == true)
        {
            for (int i = 0; i < descs.Count; i++)
            {
                if (descs[i].activeSelf == true)
                {
                    index = i;
                }
            }

            eachOfThem(index);       

            checkCurrTask = false;
        }

    }

    void eachOfThem(int nr)
    {
        foreach (GameObject obj in objToRotate)
        {
            obj.GetComponent<BremsenControl>().enabled = false;
            obj.GetComponent<BremsenControl>().isActive = false;
        }

        if (nr < 4)
        {
            foreach (var obj in spheres)
            {
                obj.gameObject.SetActive(true);
            }
            objToRotate[nr].GetComponent<BremsenControl>().enabled = true;
            objToRotate[nr].GetComponent<BremsenControl>().isActive = true;
            foreach (var obj in bremsenArmTilt)
            {
                obj.gameObject.SetActive(true);
            }

        }

        selectScript.currAR.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
        selectScript.currAR.GetComponent<DrawLineBetweenTwoObjects>().currIndex = nr;
        selectScript.currAR.GetComponent<DrawLineBetweenTwoObjects>().setLines("one");
    }

    public void resetTScript()
    {
        gameObject.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
        int i = 0;
        foreach (GameObject obj in gameObject.GetComponent<BremsenTasks>().objToRotate)
        {
            if (i < 4)
            {
                obj.GetComponent<BremsenControl>().enabled = false;
                obj.GetComponent<BremsenControl>().isActive = false;
            }
            i++;
        }
        index = 0;
        foreach (var obj in bremsenArmTilt)
        {
            obj.gameObject.SetActive(false);
        }

        foreach (var obj in spheres)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
