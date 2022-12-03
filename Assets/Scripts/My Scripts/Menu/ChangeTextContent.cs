using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class changeTextContent : MonoBehaviour
{
    public GameObject textToDisplay;
    private DragPanel dragScript;
    private ScrollRect scrollObj;

    void Start()
    {
        var scriptObj = GameObject.Find("DragPanel");
        dragScript = scriptObj.GetComponent<DragPanel>();
        var rPanel = GameObject.Find("RightPanel");
        scrollObj = rPanel.GetComponent<ScrollRect>();
    }

    public void changeText()
    {
        var offObj = GameObject.FindGameObjectWithTag("off");
        offObj.SetActive(false);
        textToDisplay.SetActive(true);
        var reactObj = textToDisplay.GetComponent<RectTransform>();
        var text = textToDisplay.transform.GetChild(0).GetComponent<RectTransform>();
        scrollObj.content = text;
        reactObj.anchoredPosition = new Vector2(dragScript.x2, reactObj.anchoredPosition.y);
        reactObj.sizeDelta = new Vector2(dragScript.rPanel.rect.width, reactObj.rect.height);
        textToDisplay.tag = "off";
    }

}


