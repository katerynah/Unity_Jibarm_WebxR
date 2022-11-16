using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour // EventTrigger: event trigger of UI events 
{
    public bool startDragging;
    [SerializeField]
    public float adaptWidth;
    public float StartX;
    public float EndX; // mob 105f, hd 61.8f (old 65f)


    void Start()
    {
        // Picking the starting position of panel for dragging limit on the right
        StartX = StartX == 0f ? gameObject.transform.position.x : StartX;

        EndX = (Screen.width - StartX) - adaptWidth;
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

        //// limit dragging on the right
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