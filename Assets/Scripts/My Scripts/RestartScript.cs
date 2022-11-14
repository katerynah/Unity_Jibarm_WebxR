using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    // eLPanel
    public List<GameObject> adaptObj = new List<GameObject>();
    float eLPanel;
    RectTransform eLRect;

    void Start()
    {
        eLRect = adaptObj[0].GetComponent<RectTransform>();
        eLPanel = eLRect.anchoredPosition.x;
    }

    public void adaptScripts(GameObject clickedBtn)
    {
        switch (clickedBtn.name)
        {
            case "Start-btn":
                if (adaptObj[0].name == "eLPanel")
                {
                    eLRect.anchoredPosition = new Vector2(eLPanel, eLRect.anchoredPosition.y);
                }
                else
                {
                    Debug.LogError($"Set DragPanel in Methods (RestartScript.cs)");
                }
                break;
            case "Resume-btn":

                break;
            case "StartMenu-btn":
                break;


        }
    }
}