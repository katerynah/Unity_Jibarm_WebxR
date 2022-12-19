using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerschiebenTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
    public GameObject sphere;
    //bool start = true;
    [HideInInspector]
    public bool checkCurrTask = true;
    public SelectionManager selectScript;
    LectManager manageLScript;

    void Start()
    {
        manageLScript = gameObject.GetComponent<LectManager>();
        descs = manageLScript.descObjects;
        tasks = manageLScript.taskObjects;
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

            if (index == 0)
            {
                //setZeroScript.option = "verschieben";
                //setZeroScript.enabled = true;
                sphere.SetActive(true);
            }

            eachOfThem(index);

            checkCurrTask = false;
        }

    }

    void eachOfThem(int nr)
    {
        //foreach (GameObject obj in objToRotate)
        //{
        //    obj.GetComponent<BremsenControl>().enabled = false;
        //}
    }

    public void resetTScript()
    {
            sphere.SetActive(false);
        
        //gameObject.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
        //int i = 0;
        //foreach (GameObject obj in gameObject.GetComponent<BremsenTasks>().objToRotate)
        //{
        //    if (i < 4)
        //    {
        //        obj.GetComponent<BremsenControl>().enabled = false;
        //        obj.GetComponent<BremsenControl>().isActive = false;
        //    }
        //    i++;
        //}
    }
}
