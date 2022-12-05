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
        disableDesc();

        gameObject.GetComponent<ChangeColor>().setColor(true);
        deskObject.SetActive(true);
    }


    public void disableDesc()
    {
        foreach (GameObject desc in allgemeinScript.descObjects.ToArray())
        {
            desc.SetActive(false);
        }

        foreach (GameObject note in allgemeinScript.noteObjects.ToArray())
        {
            note.GetComponent<ChangeColor>().setColor(false);
        }
    }
}
