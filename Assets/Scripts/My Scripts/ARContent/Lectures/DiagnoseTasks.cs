using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnoseTasks : MonoBehaviour
{
    public bool checkCurrTask = true;
    LectManager manageLScript;
    public GameObject checkScSwitch;
    public RaycastingAR raycastScript;
    public CheckBoxed checkBoxScript;
    public float timeRemaining = 5;
    public Material redMat, greenMat;
    public GameObject switchBtn, switchLight;
    public GameObject screenView;
    [HideInInspector]
    public List<GameObject> allOptions = new List<GameObject>();
    List<GameObject> descs = new List<GameObject>();
    public int index;
    int countDown = 0;
    bool start = true;

    [System.Serializable]
    public class ScreenButtons
    {
        public GameObject ScreenBtn;
        public GameObject OptWindow;
        public List<GameObject> Options;

        public ScreenButtons(GameObject screenBtn, GameObject optWindow, List<GameObject> currOptions)
        {
            ScreenBtn = screenBtn;
            OptWindow = optWindow;
            Options = currOptions;
        }
    }
    [HideInInspector]
    public List<ScreenButtons> screenButtons = new List<ScreenButtons>(); // DESC: currently not used

    // Start is called before the first frame update
    void Start()
    {
        manageLScript = gameObject.GetComponent<LectManager>();
        descs = manageLScript.descObjects;

        for (int i = 0; i < screenButtons.Count; i++)
        {
            var optionsW = screenButtons[i].OptWindow;
            foreach (Transform child in optionsW.GetComponent<Transform>())
            {
                allOptions.Add(child.gameObject);
            }
        }
        Debug.Log($"All options {descs.Count}");
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
                //if (start == true)
                //{
                //    Transform objectTransform = switchBtn.GetComponent<Transform>();
                //    objectTransform.Rotate(0f, -20f, 0f);
                //    switchLight.GetComponent<MeshRenderer>().material = redMat;
                //    Debug.Log($"Switch changed");
                //    start = false;
                //}
                switchBtn.tag = "raycast";
                raycastScript.raycasting = true;
            }
            else if (index == 1)
            {
                screenView.SetActive(true);
            }
            checkCurrTask = false;
        }

        if (countDown == 1)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if(timeRemaining <= 0){
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
            checkBoxScript.checkTheBox("switch-diag");
            raycastScript.raycasting = false;
            countDown = 1;
         }

    }

    public void resetTScript()
    {
        if (start == false)
        {
            countDown = 0;
            screenView.SetActive(false);
            switchBtn.tag = "Untagged";
            raycastScript.raycasting = false;
            index = 0;

            Transform objectTransform = switchBtn.GetComponent<Transform>();
            objectTransform.Rotate(0f, -20f, 0f);
            switchLight.GetComponent<MeshRenderer>().material = redMat;
        }

    }

}
