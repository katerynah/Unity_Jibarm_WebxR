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
            if (index == 0)
            {
                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().setLines("all");
            }
            else if (index == 1)
            {
                screenView.SetActive(true);
                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().setLines("all");

            } else if (index == 2)
            {
                tasks[3].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
            }
            else if (index == 3)
            {
                tasks[3].GetComponent<DrawLineBetweenTwoObjects>().setLines("all");
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
        index = 0;

        int i = 0;
        foreach (GameObject note in tasks)
        {
            note.GetComponent<ChangeColor>().setColor(false);
            if (i != 2)
            {
                note.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                i++;
            }
        }
        screenView.SetActive(false);
    }

}
