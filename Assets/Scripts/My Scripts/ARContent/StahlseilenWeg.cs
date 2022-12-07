using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StahlseilenWeg : MonoBehaviour
{
    public Material aura_green;
    //public Material aura_red;

    public RaycastingAR raycastScript;
    public CheckBoxed checkBoxScript;
    public FollowCurve curveScript;
    public SelectionManager selectScript;
    public EinschaltLect einschaltScript;
    public ControlNav arrowScript;
    public Material redMat;
    public GameObject switchBtn, switchLight;
    Material selectionMaterial;
    bool start = true;
    int circleIndex;
    List<GameObject> tasks;

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

    public List<Wires> wireList = new List<Wires>();

    [System.Serializable]
    public class Circles
    {
        public GameObject Circle1;
        public GameObject Circle2;
        public GameObject CircleFX;

        public Circles(GameObject circle1, GameObject circle2, GameObject circleFX)
        {
            Circle1 = circle1;
            Circle2 = circle2;
            CircleFX = circleFX;
        }
    }

    public List<Circles> circleList = new List<Circles>();

    void OnTriggerEnter(Collider other)
    {
        tasks = einschaltScript.taskObjects;

        if (other.gameObject.tag == "raycast" && start)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].activeSelf == true)
                {
                    circleIndex = i;
                }
            }

            if (circleIndex == 0)
            {
                wireList[0].WireFront.tag = "raycast";
                wireList[1].WireFront.tag = "raycast";
            }
            else if (circleIndex == 1)
            {
                curveScript.enabled = true;
            }
            else if (circleIndex == 2)
            {
                switchBtn.tag = "raycast";
            }

            var selectionRenderer1 = circleList[circleIndex].Circle1.GetComponent<MeshRenderer>();
            var selectionRenderer2 = circleList[circleIndex].Circle2.GetComponent<MeshRenderer>();
            selectionMaterial = aura_green;
            selectionRenderer1.material = selectionMaterial;
            selectionRenderer2.material = selectionMaterial;
            raycastScript.raycasting = true;
        }
    }

    void Update()
    {
        if (curveScript.objEuler.z == -70f)
        {
            curveScript.enabled = false;
            checkBoxScript.checkTheBox("camera-pos");
        }
    }

    public void doTouch(GameObject selected)
    {
        Debug.Log($"Object {selected} selected");
        if (selected == wireList[0].WireFront || selected == wireList[0].WireFront)
        {
            wireList[0].WireBack.SetActive(false);
            wireList[0].WireFront.SetActive(false);
            wireList[0].WireFront.tag = "Untagged";
            checkBoxScript.checkTheBox("left");
        } else if (selected == wireList[1].WireFront || selected == wireList[1].WireFront)
        {
            wireList[1].WireBack.SetActive(false);
            wireList[1].WireFront.SetActive(false);
            wireList[1].WireFront.tag = "Untagged";
            checkBoxScript.checkTheBox("right");
        } else if (selected == switchBtn)
        {
            Transform objectTransform = switchBtn.GetComponent<Transform>();
            objectTransform.Rotate(0f, -20f, 0f);
            switchLight.GetComponent<MeshRenderer>().material = redMat;
            switchBtn.tag = "Untagged";
            checkBoxScript.checkTheBox("switch-on");
        }

    }

}
