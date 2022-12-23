using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountExitObject : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject groupM;
    public Material greenAura;
    public bool start = true;
    public int count = 0;

    public CheckBoxed checkBoxScript;

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("raycast"))
    //    {
    //        count++;
    //    }
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("raycast"))
    //    {
    //        count--;
    //    }
    //}


    void Update()
    {
        if (start)
        {
            int i = 0;
            foreach (Transform child in groupM.GetComponent<Transform>())
            {
                if (child.gameObject.activeSelf == true)
                {
                    {
                        i++;
                    }
                }
                count = 6 - i;
                countText.SetText($"{count}/6");
                start = false;
            }



            if (countText.text == "6/6")
            {
                checkBoxScript.checkTheBox("area-free");
                gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = greenAura;
            }
        }
    }
}
