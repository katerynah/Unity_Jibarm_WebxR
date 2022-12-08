using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescList : MonoBehaviour
{
    public GameObject deskObject;
    public AllgemeinLect allgemeinScript;

    void OnMouseDown()
    {
        chooseDesc();
    }

    public void chooseDesc()
    {
        // disable all description objects
        allgemeinScript.disableDesc();

        gameObject.GetComponent<ChangeColor>().setColor(true);
        deskObject.SetActive(true);
    }


}
