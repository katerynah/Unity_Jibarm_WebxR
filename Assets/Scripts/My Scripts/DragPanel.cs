using UnityEngine;
using UnityEngine.EventSystems;
 
 public class DragPanel : EventTrigger // event trigger of UI events
{
    public bool startDragging;
    private float StartX;
    private float EndX = 85f;

    void Start()
    {
        StartX = gameObject.transform.position.x;
        Debug.Log($"Starting position: {StartX}");

    }

    void Update()
    {
        // check if dragging is on then change the position of ui element according ti mouse input position
        if (startDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.x <= EndX)
        {
            transform.position = new Vector2(EndX, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x >= StartX)
        {
            transform.position = new Vector2(StartX, gameObject.transform.position.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        // Use this event to fet mouse down on the UI
        startDragging = true;
        
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        // Use this to get user has leave the mouse
        startDragging = false;
    }
}


