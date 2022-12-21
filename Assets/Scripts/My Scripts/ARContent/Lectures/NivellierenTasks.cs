using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivellierenTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
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
               
            }
            else if (index == 1)
            {

            }
            else if (index == 2)
            {

            }
            else if (index == 3)
            {

            }
            else if (index == 4)
            {

            }


            checkCurrTask = false;
        }

    }


    public void resetTScript()
    {

    }
}
