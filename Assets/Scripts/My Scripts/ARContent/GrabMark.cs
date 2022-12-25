using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabMark : MonoBehaviour
{ 
    public GameObject markWindow;
    public GameObject[] grabBtnsText;
    public VermessenTasks vermessenTScript;
    string markNr;
    bool setColliders = false;
    public TextMeshProUGUI winHeadline;
    TextMeshProUGUI grabText, removeText;
    public ManageMarks marksScript;

    void Start()
    {
        markNr = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text;
        grabText = grabBtnsText[0].GetComponent<TextMeshProUGUI>();
        removeText = grabBtnsText[1].GetComponent<TextMeshProUGUI>();
    }

    void OnMouseDown()
    {
        toggleMenu();
    }

    public void toggleMenu()
    {

        if (!markWindow.activeSelf)
        {
            markWindow.SetActive(true);

            winHeadline.SetText($"MARK {markNr}");
            grabText.SetText($"GRAB {markNr}");
            removeText.SetText($"REMOVE {markNr}");

            marksScript.currMark = gameObject;
        }
        else if (markWindow.activeSelf)
        {
            markWindow.SetActive(false);
        }
    }

    void Update()
    {
        if (markWindow.activeSelf == true)
        {
            if (setColliders)
            {
                foreach (Transform mObj in vermessenTScript.mGroup.GetComponent<Transform>())
                {
                    mObj.gameObject.GetComponent<BoxCollider>().enabled = false;
                    mObj.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = false;
                }

                //foreach (GameObject obj in grabBtnsText)
                //{
                //    obj.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                //}
                setColliders = false;
            }
            
        } else if (markWindow.activeSelf == false)
        {
            if (setColliders)
            {
                foreach (Transform mObj in vermessenTScript.mGroup.GetComponent<Transform>())
                {
                    mObj.gameObject.GetComponent<BoxCollider>().enabled = true;
                    mObj.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = true;
                }
                //foreach (GameObject obj in grabBtnsText)
                //{
                //    obj.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                //}
                setColliders = false;
            }
        }

    }
}
