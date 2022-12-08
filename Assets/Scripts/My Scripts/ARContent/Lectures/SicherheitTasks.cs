using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicherheitTasks : MonoBehaviour
{
    
    int index;
    List<GameObject> descs;
    public bool checkCurrTask = true;
    public SicherheitLect sicherheitScript;
    public ChangeColor colorScript;
    public VerticalJoint vJointScript;

    [System.Serializable]
    public class Wires
    {
        public GameObject WireFront;
        public GameObject WireBack;

        public Wires(GameObject wireF, GameObject wireB)
        {
            WireFront = wireF;
            WireBack = wireB;
        }
    }

    void Start()
    {
        descs = sicherheitScript.descObjects;
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
                colorScript.setColor(true);
            }
            else if (index == 1)
            {
                vJointScript.enabled = true;
                vJointScript.direction = "y";
                vJointScript.isActive = true;
                colorScript.setColor(false);
            }
            else if (index == 2)
            {
               
            }
            checkCurrTask = false;
        }

    }

    //public void doTouch(GameObject selected)
    //{
    //    Debug.Log($"Object {selected} selected");
    //    if (selected == wireList[0].WireFront || selected == wireList[0].WireFront)
    //    {
    //        wireList[0].WireBack.SetActive(false);
    //        wireList[0].WireFront.SetActive(false);
    //        wireList[0].WireFront.tag = "Untagged";
    //        checkBoxScript.checkTheBox("left");
    //    }
    //    else if (selected == wireList[1].WireFront || selected == wireList[1].WireFront)
    //    {
    //        wireList[1].WireBack.SetActive(false);
    //        wireList[1].WireFront.SetActive(false);
    //        wireList[1].WireFront.tag = "Untagged";
    //        checkBoxScript.checkTheBox("right");
    //    }
    //    else if (selected == switchBtn)
    //    {
    //        Transform objectTransform = switchBtn.GetComponent<Transform>();
    //        objectTransform.Rotate(0f, -20f, 0f);
    //        switchLight.GetComponent<MeshRenderer>().material = redMat;
    //        switchBtn.tag = "Untagged";
    //        checkBoxScript.checkTheBox("switch-on");
    //    }

    //}
}
