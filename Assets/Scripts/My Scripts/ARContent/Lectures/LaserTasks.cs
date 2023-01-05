using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
    public Material redMat, greenMat;
    [HideInInspector]
    public bool checkCurrTask = true;
    public GameObject switchBtn, switchLight, screenView, controlView;
    public SelectionManager selectScript;
    LectManager manageLScript;
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
                gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(true);
                gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().setLines("one");
            }

            if (index == 1)
            {
                gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(false);
                gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();

                if (start == true)
                {
                    Transform objectTransform = switchBtn.GetComponent<Transform>();
                    Quaternion onRot = new Quaternion();
                    onRot.Set(objectTransform.rotation.x, 10f, objectTransform.rotation.z, 1);
                    switchLight.GetComponent<MeshRenderer>().material = greenMat;
                    screenView.SetActive(true);
                    start = false;
                }
            }

            //eachOfThem(index);

            checkCurrTask = false;
        }

    }

    public void resetTScript()
    {
        if (start == false)
        {
            gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(false);
            //gameObject.transform.GetChild(1).GetComponent<ChangeColor>().setColor(false);
            gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
            //gameObject.transform.GetChild(1).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
            if (start == false)
            {
                Transform objectTransform = switchBtn.GetComponent<Transform>();
                Quaternion onRot = new Quaternion();
                onRot.Set(objectTransform.rotation.x, -10f, objectTransform.rotation.z, 1);
                switchLight.GetComponent<MeshRenderer>().material = redMat;
                screenView.SetActive(false);
                start = false;
            }
            index = 0;

            start = true;
        }
        
    }

}
