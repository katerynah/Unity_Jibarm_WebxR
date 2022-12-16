using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
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

            //if (index == 0)
            //{
            //    tasks[1].GetComponent<ChangeColor>().setColor(false);
            //    tasks[0].GetComponent<ChangeColor>().setColor(true);
            //}
            //else if (index == 1)
            //{
            //    tasks[0].GetComponent<ChangeColor>().setColor(false);
            //    tasks[2].GetComponent<ChangeColor>().setColor(false);
            //    tasks[1].GetComponent<ChangeColor>().setColor(true);
            //}
            //else if (index == 2)
            //{
            //    tasks[1].GetComponent<ChangeColor>().setColor(false);
            //    tasks[3].GetComponent<ChangeColor>().setColor(false);
            //    tasks[2].GetComponent<ChangeColor>().setColor(true);
            //}
            //else if (index == 3)
            //{
            //    tasks[2].GetComponent<ChangeColor>().setColor(false);
            //    tasks[3].GetComponent<ChangeColor>().setColor(true);
            //}

            eachOfThem(index);

            manageLScript.check = false;
            checkCurrTask = false;
        }

    }

    void eachOfThem(int nr)
    {
        foreach (GameObject obj in tasks)
        {
           obj.GetComponent<ChangeColor>().setColor(false);
        }

        tasks[nr].GetComponent<ChangeColor>().setColor(true);
        Debug.Log($"Now color {tasks[nr].name}");
    }

}
