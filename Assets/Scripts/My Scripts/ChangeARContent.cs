using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeARContent : MonoBehaviour
{
    DrawLineBetweenTwoObjects lineScript;
    public LockPanel lockScript;
    GameObject currText;
    public GameObject player;

    GameObject currAR;


    void Start()
    {
        currText = GameObject.FindGameObjectWithTag("off");

        var btnName = currText.name;
        // Main Name - adaptable 
        var adaptString = btnName.Replace("tbox", "");
        var name = adaptString.Insert(adaptString.Length, "ar");
        var objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject obj in objects)
        {
            if (obj.name == name)
            {
                currAR = obj;
            }
        }
    }

    void Update()
    {
        if (lockScript.inAR == true)
        {
            currAR.SetActive(true);
            player.SetActive(true);
        } else if (lockScript.inAR == false)
        {
            lineScript = currAR.GetComponent<DrawLineBetweenTwoObjects>();
            lineScript.removeNotes();
        }
    }

}
