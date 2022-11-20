using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenPanel : MonoBehaviour
{
    private float fullXPos;
    private float startPos;
    [HideInInspector]
    public bool fullMode = true;
    private DragPanel script;
    public GameObject dragPanel;

    // Start is called before the first frame update
    void Start()
    {
        script = dragPanel.GetComponent<DragPanel>();
        fullXPos = script.EndX;
        startPos = script.StartX;
    }

    public void OnPointerClick()
    {
        if (fullMode)
        {
            dragPanel.transform.position = new Vector2(fullXPos, dragPanel.transform.position.y);
            // adapt Text
            script.adaptTextObjs();
            fullMode = false;
        }
        else if(!fullMode)
        {
            dragPanel.transform.position = new Vector2(startPos, dragPanel.transform.position.y);
            fullMode = true;
        }
    }
}
