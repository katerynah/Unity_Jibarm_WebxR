using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour // EventTrigger: event trigger of UI events 
{
    [HideInInspector]
    public bool startDragging;
    // rPanel, bPanel, tBorder
    public RectTransform[] panelsForWidth;
    [HideInInspector]
    public float x1, x2, adjustWidth, StartX, EndX, adaptXWidth;
    public RectTransform elPanel;
    [HideInInspector]
    public Transform currentPose;
    public GameObject[] textObjects;

    void Start()
    {
        // Picking the starting position of panel for dragging limit on the right
        StartX = StartX == 0f ? gameObject.transform.position.x : StartX;
        x1 = gameObject.GetComponent<RectTransform>().anchoredPosition.x;

        adaptXWidth = (Screen.width * 12f / elPanel.rect.width);  // 7.5f (here 5.5f bc it fits better) Border panel
        EndX = (Screen.width - StartX) + adaptXWidth; // adjust width 18

        // adapt text width
        var objects = GameObject.FindGameObjectsWithTag("text");
        textObjects = objects;

    }

    void Update()
    {
        currentPose = gameObject.transform;

        // check if dragging is on then change the position of ui element according ti mouse input position
        if (startDragging)
        {

            transform.position = new Vector2(Input.mousePosition.x, gameObject.transform.position.y);

            if (gameObject.GetComponent<RectTransform>().anchoredPosition.x < -100f) // < -103.5
            {
                // Adapt RPanel and Text objects
                adaptTextObjs();
            }
            
        }

        // limit dragging on the left
        if (gameObject.transform.position.x <= EndX)
        {
            transform.position = new Vector2(EndX, gameObject.transform.position.y);
        }

        //// limit dragging on the right
        else if (gameObject.transform.position.x >= StartX)
        {
            transform.position = new Vector2(StartX, gameObject.transform.position.y);
        }
    }

    public void adaptTextObjs()
    {
        //RightPanel
        adjustWidth = (-1 * (gameObject.GetComponent<RectTransform>().anchoredPosition.x + 100f));

        foreach (var panel in panelsForWidth)
        {
            panel.sizeDelta = new Vector2(adjustWidth+1, panel.rect.height);
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

    public void OnPointerDown()
    {
        // Use this event to fet mouse down on the UI
        startDragging = true;
    }


    public void OnPointerUp()
    {
        // Use this to get user has leave the mouse
        startDragging = false;
    }



}