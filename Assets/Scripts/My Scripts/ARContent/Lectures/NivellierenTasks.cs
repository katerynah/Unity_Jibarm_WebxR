using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivellierenTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
    public GameObject checkNivel;
    public ChangeAxis changeAxisScript;
    public AdaptJacks adaptJScript;
    public GameObject[] nivelPoint;
    public GameObject[] circles;

    //bool start = true;
    public Vector3 resetLibPos;
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
                foreach (GameObject niv in nivelPoint)
                {
                    if (niv == nivelPoint[1])
                    {
                        niv.SetActive(true);
                    }
                    else
                    {
                        niv.SetActive(false);
                    }
                }
            }
            else if (index == 1)
            {
                //libellePoint.transform = 
                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().currIndex = 0;
                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().setLines("one");
                tasks[1].GetComponent<ChangeColor>().setColor(true);
                adaptJScript.checkCollision = false;
                adaptJScript.enabled = false;
            }
            else if (index == 2 || index == 3)
            {
                checkNivel.GetComponent<BoxCollider>().enabled = true;

                tasks[1].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                tasks[1].GetComponent<ChangeColor>().setColor(false);


                circles[0].transform.GetChild(0).gameObject.tag = "raycast";
                circles[0].transform.GetChild(1).gameObject.tag = "raycast";
                circles[1].transform.GetChild(0).gameObject.tag = "raycast";
                circles[1].transform.GetChild(1).gameObject.tag = "raycast";

                adaptJScript.checkCollision = true;
                adaptJScript.enabled = true;
                if (nivelPoint[1].activeSelf == false)
                {
                    foreach (GameObject niv in nivelPoint)
                    {
                        if (niv == nivelPoint[1])
                        {
                            niv.SetActive(true);
                        }
                        else
                        {
                            niv.SetActive(false);
                        }
                    }
                }
                circles[0].SetActive(true);
            }
           

            checkCurrTask = false;
        }

    }


    public void resetTScript()
    {
        checkNivel.GetComponent<BoxCollider>().enabled = false;
        nivelPoint[0].SetActive(true);
        foreach (GameObject niv in nivelPoint)
        {
            if (niv != nivelPoint[0])
            {
                niv.SetActive(false);
            }
        }
        index = 0;

        adaptJScript.anim[0].Play("1Axis", -1, 0f);
        adaptJScript.anim[1].Play("2Axis", -1, 0f);
        changeAxisScript.jointAnim[0].Play("RotArmR", -1, 0f);
        changeAxisScript.jointAnim[1].Play("RotArmL", -1, 0f);
        adaptJScript.anim[0].enabled = false;
        adaptJScript.anim[1].enabled = false;
        adaptJScript.checkCollision = false;
        adaptJScript.enabled = false;
        circles[0].SetActive(false);
        circles[0].transform.GetChild(0).gameObject.tag = "Untagged";
        circles[0].transform.GetChild(1).gameObject.tag = "Untagged";
        circles[1].transform.GetChild(0).gameObject.tag = "Untagged";
        circles[1].transform.GetChild(1).gameObject.tag = "Untagged";
    }
}
