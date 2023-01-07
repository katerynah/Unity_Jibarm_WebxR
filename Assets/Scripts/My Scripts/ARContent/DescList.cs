using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescList : MonoBehaviour
{
    public GameObject deskObject;
    public LectManager lectScript;

    void OnMouseDown()
    {
        chooseDesc();
    }


    public void chooseDesc()
    {
        lectScript.introD.SetActive(false);
        lectScript.introN.SetActive(false);
        Debug.Log($"Intro {lectScript.introD.activeSelf}");
        // disable all description objects
        foreach (GameObject note in lectScript.taskObjects)
        {
            note.GetComponent<ChangeColor>().setColor(false);
        }
        foreach (GameObject child in lectScript.descObjects)
        {
            child.SetActive(false);
        }
        gameObject.GetComponent<ChangeColor>().setColor(true);
        deskObject.SetActive(true);
    }


}
