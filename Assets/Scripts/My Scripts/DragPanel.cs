using UnityEngine;
using UnityEngine.EventSystems;
 
 public class DragPanel : MonoBehaviour // EventTrigger: event trigger of UI events 
{
    public bool startDragging;
    public Canvas canvas;
    public float StartX;
    private float EndX;

    void Start()
    {
        // Adapting panel width to canvas width
        Vector2 newWidth;
        newWidth = new Vector2(canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height);
        RectTransform panelRect = gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        panelRect.sizeDelta = newWidth;

        // Picking the starting position of panel for dragging limit on the right
        StartX = StartX == 0f ?  gameObject.transform.position.x : StartX;

        // adapt left limit on the screen size
        EndX = newWidth.x < 140.6f ? 0f : -10f;

    }

    void Update()
    {
        // check if dragging is on then change the position of ui element according ti mouse input position
        if (startDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, gameObject.transform.position.y);
        }

        // limit dragging on the left
        if (gameObject.transform.position.x <= EndX)
        {
            transform.position = new Vector2(EndX, gameObject.transform.position.y);
        }

        // limit dragging on the right
        else if (gameObject.transform.position.x >= StartX)
        {
            transform.position = new Vector2(StartX, gameObject.transform.position.y);
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


