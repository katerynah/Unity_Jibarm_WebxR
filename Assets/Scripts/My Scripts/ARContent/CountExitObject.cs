using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountExitObject : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public Material greenAura;
    [SerializeField]
    public int count = 6;

    public CheckBoxed checkBoxScript;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("raycast"))
        {
            count++;
            Debug.Log($"{other.gameObject.name} exited");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("raycast"))
        {
            count--;
            Debug.Log($"{other.gameObject.name} entered");
        }
    }


    void Update()
    {
        countText.SetText($"{count}/6");

        if (countText.text == "6/6")
        {
            checkBoxScript.checkTheBox("area-free");
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = greenAura;
        }
    }

}
