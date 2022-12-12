using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicherheitTasks : MonoBehaviour
{
    int index;
    List<GameObject> descs;
    public GameObject modelsGroup;
    [HideInInspector]
    public bool checkCurrTask = true;
    public GameObject bereichCount, checkBereich;
    SicherheitLect sicherheitScript;
    public CollectObjects collectScript;
    public ChangeColor colorScript;
    public Camera ARCamera;
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
        sicherheitScript = gameObject.GetComponent<SicherheitLect>();
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
                vJointScript.resetRotation();
                vJointScript.enabled = false;
            }
            else if (index == 1)
            {
                vJointScript.enabled = true;
                vJointScript.direction = "y";
                vJointScript.isActive = true;
                bereichCount.SetActive(false);
                colorScript.setColor(false);
                foreach (Transform child in modelsGroup.GetComponent<Transform>())
                {
                    child.gameObject.tag = "Untagged";
                    collectScript.raycasting = false;
                }
            }
            else if (index == 2)
            {
                vJointScript.resetRotation();
                vJointScript.enabled = false;
                bereichCount.SetActive(true);
                foreach (Transform child in modelsGroup.GetComponent<Transform>())
                {
                    child.gameObject.tag = "raycast";
                    
                    collectScript.raycasting = true;
                }
                if (checkBereich.activeSelf == true)
                {
                    collectScript.raycasting = false;
                    bereichCount.SetActive(false);
                }
            }
            checkCurrTask = false;
        }

    }

    
}
