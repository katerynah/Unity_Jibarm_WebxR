using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerschiebenTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
    public GameObject sphere, playView, handIcons, joystick;
    public JointForRepos jointRotScript;
    bool start = true;
    public GameObject group1, group2;
    public GameObject circleStart, circleEnd;
    [HideInInspector]
    public bool checkCurrTask = true;
    public SelectionManager selectScript;
    public JibMoveArea jibAreaScript;
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
                jointRotScript.enabled = false;
                jointRotScript.isActive = false;
                group1.SetActive(true);
                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().setLines("all");
                start = false;
                //setZeroScript.option = "verschieben";
                //setZeroScript.enabled = true;
                //sphere.SetActive(true);
            }
            else if (index == 1)
            {
                jointRotScript.enabled = true;
                jointRotScript.isActive = true;
                //sphere.SetActive(false);
                playView.SetActive(false);
                tasks[0].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                playView.GetComponent<ManagePlaylist>().animator[0].Play("Step1", -1, 0f);
            }
            else if (index == 2)
            {
                // anim 1
                jointRotScript.enabled = false;
                jointRotScript.isActive = false;
                playView.SetActive(true);
                playView.GetComponent<ManagePlaylist>().select = 0;
                playView.GetComponent<ManagePlaylist>().animator[1].enabled = false;
                playView.GetComponent<ManagePlaylist>().animator[1].Play("4JacksAnimation", -1, 0f);
                playView.transform.GetChild(0).gameObject.SetActive(true);
                playView.transform.GetChild(1).gameObject.SetActive(false);

            }
            else if (index == 3)
            {
                // anim 2
                playView.SetActive(true);
                //sphere.SetActive(false);
                playView.GetComponent<ManagePlaylist>().select = 1;
                playView.GetComponent<ManagePlaylist>().animator[0].enabled = false;
                playView.GetComponent<ManagePlaylist>().animator[0].Play("Step1", -1, 0f);
                playView.transform.GetChild(0).gameObject.SetActive(true);
                playView.transform.GetChild(1).gameObject.SetActive(false);
                group1.SetActive(true);
                group2.SetActive(false);
                joystick.SetActive(false);
                joystick.GetComponent<JibarmMovement>().enabled = false;
                circleStart.SetActive(false);
                jibAreaScript.enabled = false;
                jibAreaScript.checkCollision = false;
                circleStart.transform.GetChild(2).gameObject.tag = "Untagged";
            }
            else if (index == 4)
            {
                playView.GetComponent<ManagePlaylist>().animator[1].Play("4JacksAnimation", -1, 0f);
                playView.SetActive(false);
                group2.SetActive(true);
                group1.SetActive(false);
                joystick.SetActive(true);
                joystick.GetComponent<JibarmMovement>().enabled = true;
                circleStart.SetActive(true);
                circleStart.transform.GetChild(2).gameObject.tag = "raycast";
                jibAreaScript.enabled = true;
                jibAreaScript.checkCollision = true;
                //collectScript.raycasting = true;

                //handIcons.transform.GetChild(0).gameObject.SetActive(true);
                //handIcons.transform.GetChild(1).gameObject.SetActive(false);
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
        if (start == false)
        {
            //sphere.SetActive(false);
            playView.SetActive(false);
            playView.GetComponent<ManagePlaylist>().select = 0;
            tasks[0].GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
            playView.GetComponent<ManagePlaylist>().animator[0].Play("Step1", -1, 0f);
            playView.GetComponent<ManagePlaylist>().animator[1].Play("4JacksAnimation", -1, 0f);
            playView.GetComponent<ManagePlaylist>().animator[0].enabled = false;
            playView.GetComponent<ManagePlaylist>().animator[1].enabled = false;
            group1.SetActive(false);
            group2.SetActive(false);
            circleStart.SetActive(false);
            circleEnd.SetActive(false);
            circleStart.transform.GetChild(2).gameObject.tag = "Untagged";
            jibAreaScript.checkCollision = false;
            joystick.SetActive(false);
            index = 0;

            start = true;
        }       

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