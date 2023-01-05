using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoordsysTasks : MonoBehaviour
{
    public bool checkCurrTask = true;
    int countDown = 0;
    public GameObject[] checkScSwitch;
    LectManager manageLScript;
    public RaycastingAR raycastScript;
    float timeRemaining = 5;
    public Material redMat, greenMat;
    public GameObject switchBtn, switchLight;
    public GameObject screenView, camParam;
    List<GameObject> descs = new List<GameObject>();
    List<GameObject> tasks = new List<GameObject>();
    int index;
    bool start = true;

    // Start is called before the first frame update
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
                gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().setLines("one");
                gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().currIndex = 0;
                gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(true);
                gameObject.transform.GetChild(1).GetComponent<ChangeColor>().setColor(false);
            }
            else if (index == 1)
            {
                gameObject.transform.GetChild(1).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                gameObject.transform.GetChild(1).GetComponent<DrawLineBetweenTwoObjects>().setLines("one");
                gameObject.transform.GetChild(1).GetComponent<DrawLineBetweenTwoObjects>().currIndex = 0;
                gameObject.transform.GetChild(1).GetComponent<ChangeColor>().setColor(true);
                gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(false);

                // check on Einschalt- and Diagnose checkmarks - if enabled
                if (start == true)
                {
                    Transform objectTransform = switchBtn.GetComponent<Transform>();
                    objectTransform.Rotate(0f, -20f, 0f);
                    switchLight.GetComponent<MeshRenderer>().material = redMat;
                    Debug.Log($"Switch changed");
                    start = false;
                }
                switchBtn.tag = "raycast";
                raycastScript.raycasting = true;
            } else if (index == 2)
            {
                gameObject.transform.GetChild(1).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(false);
                gameObject.transform.GetChild(1).GetComponent<ChangeColor>().setColor(false);
            }

            checkCurrTask = false;
        }

        if (countDown == 1)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if (timeRemaining <= 0)
            {
                switchLight.GetComponent<MeshRenderer>().material = greenMat;
                screenView.SetActive(true);
                countDown = 2;
            }
        }
    }


    public void doTouch(GameObject selected)
    {
        if (selected == switchBtn)
        {
            Transform objectTransform = switchBtn.GetComponent<Transform>();
            objectTransform.Rotate(0f, 20f, 0f);
            raycastScript.raycasting = false;
            countDown = 1;
        }

    }

    public void resetTScript()
    {
        if (start == false)
        {
            int i = 0;
            foreach (GameObject obj in tasks)
            {
                if (i != 2)
                {
                    obj.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                    obj.GetComponent<ChangeColor>().setColor(false);
                    start = true;
                    countDown = 0;
                    i++;
                }
            }
            switchBtn.tag = "Untagged";
            raycastScript.raycasting = false;
            index = 0;

            Transform objectTransform = switchBtn.GetComponent<Transform>();
            objectTransform.Rotate(0f, -20f, 0f);
            switchLight.GetComponent<MeshRenderer>().material = redMat;
        }
        
    }
}
