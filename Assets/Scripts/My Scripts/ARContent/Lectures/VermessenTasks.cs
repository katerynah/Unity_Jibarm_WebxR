using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VermessenTasks : MonoBehaviour
{
    public bool checkCurrTask = true;
    LectManager manageLScript;
    public CameraToMeasure cameraRotScript;
    //public JibarmToMeasure jibRotScript; // id using drag - not convinient
    public VermessenJoystick vermessenJoys;
    public RaycastingAR raycastScript;
    public Material redMat, greenMat;
    public GameObject switchBtn, switchLight, screenView, mGroup, joystick, controlView;
    List<GameObject> descs = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> mPoints = new List<GameObject>();
    int index;
    bool start = true;
    bool joystickOn = true;

    // Start is called before the first frame update
    void Start()
    {
        manageLScript = gameObject.GetComponent<LectManager>();
        descs = manageLScript.descObjects;

        foreach (Transform point in mGroup.GetComponent<Transform>())
        {
            var pointImage = point.gameObject.GetComponent<Image>();
            pointImage.color = new Color32(212, 135, 123, 255);
            var pointText = point.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            pointText.color = new Color32(113, 71, 67, 255);
            mPoints.Add(point.gameObject);
        }
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
                // check on Einschalt- and Diagnose checkmarks - if enabled
                //if (start == true)
                //{
                    Transform objectTransform = switchBtn.GetComponent<Transform>();
                    //Quaternion onRot = new Quaternion();
                    //onRot.Set(objectTransform.rotation.x, 10f, objectTransform.rotation.z, 1);
                    objectTransform.Rotate(0f, 20f, 0f);
                    switchLight.GetComponent<MeshRenderer>().material = greenMat;
                    screenView.SetActive(true);
                    start = false;
                //}
                cameraRotScript.enabled = false;
            }
            //else if (index == 1)
            //{
            //    cameraRotScript.enabled = true;
            //    cameraRotScript.isActive = true;
            //}
            else if (index == 1)
            {
                //vermessenJoys.enabled = false;
                //cameraRotScript.enabled = false;
            }
            else if (index == 2)
            {
                //vermessenJoys.enabled = true;
                
            }
            checkCurrTask = false;
        }

        if (index != 0)
        {
            joystick.SetActive(true);
            joystick.GetComponent<VermessenJoystick>().enabled = true;
        }
        else
        {
            joystick.SetActive(false);
            joystick.GetComponent<VermessenJoystick>().enabled = false;

        }
    }

    public void resetTScript()
    {
        if (start == false)
        {
            Transform objectTransform = switchBtn.GetComponent<Transform>();
            //Quaternion onRot = new Quaternion();
            //onRot.Set(objectTransform.rotation.x, -10f, objectTransform.rotation.z, 1);
            objectTransform.Rotate(0f, -20f, 0f);
            switchLight.GetComponent<MeshRenderer>().material = redMat;
            screenView.SetActive(false);
            joystick.GetComponent<VermessenJoystick>().enabled = false;

            cameraRotScript.enabled = false;
            cameraRotScript.isActive = false;
            joystick.SetActive(false);
            index = 0;

        }
        joystick.SetActive(false);
    }


}
