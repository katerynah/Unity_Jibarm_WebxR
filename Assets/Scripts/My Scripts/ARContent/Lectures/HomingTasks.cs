using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
    public List<GameObject> objToRotate = new List<GameObject>();
    public GameObject[] checkboxes;
    public List<GameObject> spheres = new List<GameObject>();
    [HideInInspector]
    public bool checkCurrTask = true;
    public SelectionManager selectScript;
    LectManager manageLScript;
    public SetZeroPoints[] zeroScripts;
    bool start = true;

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
                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().currIndex = 0;
                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().setLines("all");
            } else if (index == 1)
            {
                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().currIndex = 0;
                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().setLines("all");
                zeroScripts[0].enabled = false;
                zeroScripts[1].enabled = false;
            }
            else if (index == 2)
            {

                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                zeroScripts[0].enabled = true;
                zeroScripts[0].isActive = true;

                if (start)
                {
                    //setStartRotation();
                }

            }

            //eachOfThem(index);

            checkCurrTask = false;
        }

    }

    void eachOfThem(int nr)
    {
        //foreach (GameObject obj in objToRotate)
        //{
        //    obj.GetComponent<BremsenControl>().enabled = false;
        //}

        //if (nr < 4)
        //    objToRotate[nr].GetComponent<BremsenControl>().enabled = true;
        //    objToRotate[nr].GetComponent<BremsenControl>().isActive = true;

        //}
        
    }

    void setStartRotation()
    {
        var hBoomRot = zeroScripts[0].horRotation.transform.rotation.eulerAngles;
        hBoomRot.y = -25f;
        zeroScripts[0].horRotation.transform.rotation = Quaternion.Euler(hBoomRot);

        var vBoomRot = zeroScripts[0].vertRotation.transform.rotation.eulerAngles;
        vBoomRot.z = -15f;
        zeroScripts[0].vertRotation.transform.rotation = Quaternion.Euler(vBoomRot);

        var hHeadRot = zeroScripts[1].horRotation.transform.rotation.eulerAngles;
        hHeadRot.z = -120f;
        zeroScripts[1].horRotation.transform.rotation = Quaternion.Euler(hHeadRot);

        var vHeadRot = zeroScripts[1].vertRotation.transform.rotation.eulerAngles;
        vHeadRot.y = 45f;
        zeroScripts[1].vertRotation.transform.rotation = Quaternion.Euler(vHeadRot);

        start = false;
    }
}
