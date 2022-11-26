using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour // EventTrigger: event trigger of UI events 
{
    public bool startDragging;
    private float adaptXWidth;
    public RectTransform rPanel, eLPanel, jibarmInfo;
    private float x1, x2, adjustWidth;
    [HideInInspector]
    public float StartX, EndX;
    [HideInInspector]
    public GameObject[] textObjects;

    void Start()
    {
        // Picking the starting position of panel for dragging limit on the right
        StartX = StartX == 0f ? gameObject.transform.position.x : StartX;
        x1 = gameObject.GetComponent<RectTransform>().anchoredPosition.x;

        adaptXWidth = (Screen.width * 5.5f / eLPanel.rect.width);  // 7.5f (here 5.5f bc it fits better) Border panel
        EndX = (Screen.width - StartX) + adaptXWidth; // adjust width 18

        // adapt text width
        var objects = GameObject.FindGameObjectsWithTag("text");
        textObjects = objects;
    }

    void Update()
    {
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
        rPanel.sizeDelta = new Vector2(adjustWidth, rPanel.rect.height);

        foreach (var obj in textObjects)
        {
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.x > -198)
            {
                obj.gameObject.SetActive(false);
            }
            else
            {
                x2 = gameObject.GetComponent<RectTransform>().anchoredPosition.x;
                var deltaX = x2 + x1;
                // Text Objects
                obj.gameObject.SetActive(true);
                obj.GetComponent<RectTransform>().sizeDelta = new Vector2(rPanel.rect.width, rPanel.rect.height);
                //obj.GetComponent<RectTransform>().anchoredPosition += new Vector2(obj.GetComponent<RectTransform>().anchoredPosition.x , obj.GetComponent<RectTransform>().anchoredPosition.y +  deltaX);
            }
        }
        
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