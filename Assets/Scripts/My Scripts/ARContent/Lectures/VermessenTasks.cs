using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VermessenTasks : MonoBehaviour
{
    public bool checkCurrTask = true;
    VermessenLect vermessenScript;
    public CameraToMeasure cameraRotScript;
    public RaycastingAR raycastScript;
    public Material redMat, greenMat;
    public GameObject switchBtn, switchLight;
    public GameObject screenView;
    List<GameObject> descs = new List<GameObject>();
    int index;
    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        vermessenScript = gameObject.GetComponent<VermessenLect>();
        descs = vermessenScript.descObjects;
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
                if (start == true)
                {
                    Transform objectTransform = switchBtn.GetComponent<Transform>();
                    Quaternion onRot = new Quaternion();
                    onRot.Set(objectTransform.rotation.x, 10f, objectTransform.rotation.z, 1);
                    switchLight.GetComponent<MeshRenderer>().material = greenMat;
                    screenView.SetActive(true);
                    start = false;
                }
                cameraRotScript.enabled = false;
            }
            else if (index == 1)
            {
                cameraRotScript.enabled = true;
                cameraRotScript.isActive = true;
            }
            else if (index == 2)
            {
                cameraRotScript.enabled = false;
            }

            checkCurrTask = false;
        }

    }


    public void doTouch(GameObject selected)
    {
        if (selected == switchBtn)
        {
            
        }

    }
}
