using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EinschaltTasks : MonoBehaviour
{
    public Material aura_green;
    //public Material aura_red;

    public RaycastingAR raycastScript;
    public CheckBoxed checkBoxScript;
    public FollowCurve curveScript;
    public SelectionManager selectScript;
    LectManager manageLScript;
    public Material redMat;
    public GameObject switchBtn, switchLight;
    Material selectionMaterial;
    bool start = true;
    int circleIndex;

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

    void Start()
    {
        manageLScript = selectScript.currAR.GetComponent<LectManager>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && start)
        {
            for (int i = 0; i < manageLScript.taskObjects.Count; i++)
            {
                if (manageLScript.taskObjects[i].activeSelf == true)
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
                wireList[0].WireFront.tag = "Untagged";
                wireList[1].WireFront.tag = "Untagged";
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
            curveScript.isActive = false;
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
