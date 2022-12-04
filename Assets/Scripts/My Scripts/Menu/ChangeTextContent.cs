using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextContent : MonoBehaviour
{
    [SerializeField]
    GameObject textToDisplay;
    private DragPanel dragScript;
    private ScrollRect scrollObj;
    string textName;

    void Start()
    {
        var scriptObj = GameObject.Find("DragPanel");
        dragScript = scriptObj.GetComponent<DragPanel>();
        var lPanel = GameObject.Find("Lectures-scroll");
        scrollObj = lPanel.GetComponent<ScrollRect>();
    }

    void OnEnable()
    {
        var btnName = gameObject.name;
        var adaptString = btnName.Replace("btn", "");
        var name = adaptString.Insert(adaptString.Length, "tbox");
        var objects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject obj in objects)
        {
            if (obj.name == name) {
                textToDisplay = obj;
            }
        }
    }

    public void changeText()
    {
        var offObj = GameObject.FindGameObjectWithTag("off");
        offObj.SetActive(false);
        textToDisplay.SetActive(true);
        textToDisplay.tag = "text-on";
        var reactObj = textToDisplay.GetComponent<RectTransform>();
        var text = textToDisplay.transform.GetChild(0).GetComponent<RectTransform>();
        scrollObj.content = text;
        reactObj.anchoredPosition = new Vector2(dragScript.x2, reactObj.anchoredPosition.y);
        reactObj.sizeDelta = new Vector2(dragScript.panelsForWidth[0].rect.width, reactObj.rect.height);
        textToDisplay.tag = "off";
    }

}


