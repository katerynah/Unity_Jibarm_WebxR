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
    public GameObject screenView;
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

            if(index == 1)
            {
                screenView.SetActive(true);

            }
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

    public void resetTScript()
    {
        foreach (GameObject note in tasks)
        {
            note.GetComponent<ChangeColor>().setColor(false);
        }
        screenView.SetActive(false);
    }

}
