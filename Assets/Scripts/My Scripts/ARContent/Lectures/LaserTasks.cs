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
   
}
