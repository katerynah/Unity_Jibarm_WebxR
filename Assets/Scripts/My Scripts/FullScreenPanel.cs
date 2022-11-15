using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenPanel : MonoBehaviour
{
    private float fullXPos;
    private float currPosX;
    private bool fullMode = true;
    private DragPanel script;
    public GameObject dragPanel;

    // Start is called before the first frame update
    void Start()
    {
        script = dragPanel.GetComponent<DragPanel>();
        fullXPos = script.EndX;
    }

    private void OnMouseDown()
    {
        setFull();
    }

    public void setFull()
    {
        if (fullMode)
        {
            currPosX = dragPanel.transform.position.x;
            dragPanel.transform.position = new Vector2(fullXPos, dragPanel.transform.position.y);
            fullMode = false;
        }
        else if(!fullMode)
        {
            dragPanel.transform.position = new Vector2(currPosX, dragPanel.transform.position.y);
            fullMode = true;
        }
    }
}
