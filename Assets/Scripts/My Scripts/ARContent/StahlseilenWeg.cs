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
    public GameObject circle1, circle2;
    Material selectionMaterial;
    bool start = true;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "raycast" && start)
        {
            //checkObject.setEvent();
            var selectionRenderer1 = circle1.GetComponent<MeshRenderer>();
            var selectionRenderer2 = circle2.GetComponent<MeshRenderer>();
            selectionMaterial = aura_green;
            selectionRenderer1.material = selectionMaterial;
            selectionRenderer2.material = selectionMaterial;
            Debug.Log($"Entered {other.gameObject.name}");
            raycastScript.raycasting = true;
        }
    }

    public void seilenTouch(GameObject selected)
    {

        if (selected == wireList[0].WireFront || selected == wireList[0].WireFront)
        {
            wireList[0].WireBack.SetActive(false);
            wireList[0].WireFront.SetActive(false);
            checkBoxScript.checkTheBox("left");
        } else if (selected == wireList[1].WireFront || selected == wireList[1].WireFront)
        {
            wireList[1].WireBack.SetActive(false);
            wireList[1].WireFront.SetActive(false);
            checkBoxScript.checkTheBox("right");
        }

    }

}
