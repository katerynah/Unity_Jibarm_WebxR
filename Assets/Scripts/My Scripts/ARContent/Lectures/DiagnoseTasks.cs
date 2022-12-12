using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnoseTasks : MonoBehaviour
{
    public bool checkCurrTask = true;
    DiagnoseLect diagnoseScript;
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
    int index;
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
        diagnoseScript = gameObject.GetComponent<DiagnoseLect>();
        descs = diagnoseScript.descObjects;

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
                if (start == true && checkScSwitch.activeSelf == false)
                {
                    Transform objectTransform = switchBtn.GetComponent<Transform>();
                    objectTransform.Rotate(0f, -20f, 0f);
                    switchLight.GetComponent<MeshRenderer>().material = redMat;
                    Debug.Log($"Switch changed");
                    start = false;
                }
                switchBtn.tag = "raycast";
                raycastScript.raycasting = true;
            }
            else if (index == 1)
            {

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

}
