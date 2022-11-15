using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    // eLPanel
    public List<GameObject> adaptObj = new List<GameObject>();
    float eLPanel;
    DragPanel script;
    bool doFirst = true;
    RectTransform eLRect;

    void Start()
    {
        eLRect = adaptObj[0].transform.GetChild(0).GetComponent<RectTransform>();
        eLPanel = eLRect.anchoredPosition.x;
        script = adaptObj[0].GetComponent<DragPanel>();
    }

    public void adaptScripts(GameObject clickedBtn)
    {
        switch (clickedBtn.name)
        {
            case "Start-btn":
                if (adaptObj[0].name == "DragPanel")
                {
                    if (doFirst)
                    {
                        eLRect.anchoredPosition = new Vector2(eLPanel, eLRect.anchoredPosition.y);
                        doFirst = false;
                    }
                    else if(!doFirst)
                    {
                        adaptObj[0].transform.position = new Vector2(script.StartX, adaptObj[0].transform.position.y);
                        Debug.Log($"Curr pos of Drag panel {script.StartX}");
                    }
                }
                else
                {
                    Debug.LogError($"Set DragPanel in Methods (RestartScript.cs)");
                }
                break;
            case "Resume-btn":
                adaptObj[0].SetActive(true);
                break;
            case "Menu-btn":
                break;


        }
    }
}