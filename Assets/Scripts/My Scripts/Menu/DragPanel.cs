using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour // EventTrigger: event trigger of UI events 
{
   
    // rPanel, bPanel, tBorder
    public RectTransform[] panelsForWidth;
    public DragHelper dragHScript;
    [HideInInspector]
    public float x1, x2, adjustWidth, StartX, EndX, adaptXWidth;
    public RectTransform elPanel, rPanel;
    [HideInInspector]
    public Transform currentPose;
    public GameObject[] textObjects;
    public GameObject rBorder;

    void Start()
    {
        // Picking the starting position of panel for dragging limit on the right
        StartX = StartX == 0f ? gameObject.transform.position.x : StartX;
        x1 = gameObject.GetComponent<RectTransform>().anchoredPosition.x;

        adaptXWidth = (Screen.width * 12f / elPanel.rect.width);  // 7.5f (here 5.5f bc it fits better) Border panel
        EndX = (Screen.width - StartX) + adaptXWidth + 5; // adjust width 18

        // adapt text width
        var objects = GameObject.FindGameObjectsWithTag("text");
        textObjects = objects;

    }

    void Update()
    {
        currentPose = gameObject.transform;
        if (rPanel.rect.width > 0)
        {
            rBorder.SetActive(true);
        }
        else
        {
            rBorder.SetActive(false);
        }
    }

    public void adaptTextObjs()
    {
        //RightPanel
        adjustWidth = (-1 * (gameObject.GetComponent<RectTransform>().anchoredPosition.x + 100f));

        foreach (var panel in panelsForWidth)
        {
            panel.sizeDelta = new Vector2(adjustWidth + 1, panel.rect.height);
        }



        foreach (var obj in textObjects)
        {
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.x > -198)  // -198
            {
                obj.gameObject.SetActive(false);
            }
            else
            {
                x2 = gameObject.GetComponent<RectTransform>().anchoredPosition.x;
                // Text Objects
                obj.gameObject.SetActive(true);
                obj.GetComponent<RectTransform>().sizeDelta = new Vector2(panelsForWidth[0].rect.width, panelsForWidth[0].rect.height);
            }
        }

        var objOff = GameObject.FindGameObjectWithTag("off");
        // Text Objects
        objOff.GetComponent<RectTransform>().sizeDelta = new Vector2(panelsForWidth[0].rect.width, panelsForWidth[0].rect.height);

    }



}