using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    // dragPanel, Jib, 
    public List<GameObject> adaptObj = new List<GameObject>();
    
    float eLPanel;
    [SerializeField]
    public DragPanel dragScript;
    bool doFirst = true;
    RectTransform eLRect;

    void Start()
    {
        eLRect = adaptObj[0].transform.GetChild(0).GetComponent<RectTransform>();
        eLPanel = -14f;
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
                        // TEST: change EndX to startX after testing
                        adaptObj[0].transform.position = new Vector2(dragScript.EndX, adaptObj[0].transform.position.y);
                        // TEST: remove after testing
                        dragScript.adaptTextObjs();

                    }
                }
                else
                {
                    Debug.LogError($"Set DragPanel in Methods (RestartScript.cs)");
                }
                break;
            case "Resume-btn":
                break;
            case "Menu-btn":
                break;


        }
    }
}