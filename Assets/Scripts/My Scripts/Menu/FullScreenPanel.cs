using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenPanel : MonoBehaviour
{
    private float fullXPos;
    private float currPosX;
    [HideInInspector]
    public bool fullMode = true;
    private DragPanel script;
    public LockPanel lockScript;
    public GameObject dragPanel;

    // Start is called before the first frame update
    void Start()
    {
        script = dragPanel.GetComponent<DragPanel>();
        fullXPos = script.EndX;
        currPosX = dragPanel.transform.position.x;
    }

    public void OnPointerClick()
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
