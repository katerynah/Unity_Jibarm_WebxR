using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHelper : MonoBehaviour
{
    public bool insideDragArea = false;
    public DragPanel dragScript;
    public bool startDragging;
    [HideInInspector]
    public float x1, x2, adjustWidth, StartX, EndX, adaptXWidth;
    public RectTransform elPanel;
    float offsetStart = 0;
    float offsetEnd = -103;

    private void Start()
    {
        //// Picking the starting position of panel for dragging limit on the right
        //StartX = StartX == 0f ? gameObject.transform.position.x : StartX;
        //x1 = gameObject.GetComponent<RectTransform>().anchoredPosition.x;

        //adaptXWidth = (Screen.width * 12f / elPanel.rect.width);  // 7.5f (here 5.5f bc it fits better) Border panel
        //EndX = (Screen.width - StartX) + adaptXWidth; // adjust width 18
        ////StartX += offsetStart;
        //EndX += offsetEnd;
    }

    private void Update()
    {
        if (startDragging == true)
        {
            transform.position = new Vector2(Input.mousePosition.x, transform.position.y);
            dragScript.gameObject.transform.position = new Vector2(transform.position.x, dragScript.gameObject.transform.position.y);
        }

        if (transform.position.x >= dragScript.EndX) // < -103.5
        {
            // Adapt RPanel and Text objects
            dragScript.adaptTextObjs();
        }


        // check if dragging is on then change the position of ui element according ti mouse input position

        // limit dragging on the left
        if (transform.position.x <= dragScript.EndX)
        {
            transform.position = new Vector2(dragScript.EndX, transform.position.y);
            dragScript.gameObject.transform.position = new Vector2(dragScript.EndX, dragScript.gameObject.transform.position.y);
        }

        //// limit dragging on the right
        else if (transform.position.x >= dragScript.StartX)
        {
            transform.position = new Vector2(dragScript.StartX, transform.position.y);
            dragScript.gameObject.transform.position = new Vector2(dragScript.StartX, dragScript.gameObject.transform.position.y);
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

