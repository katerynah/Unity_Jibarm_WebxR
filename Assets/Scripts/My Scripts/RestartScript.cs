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
    [SerializeField]
    public JibarmControl jibStartScript;
    bool doFirst = true;
    RectTransform eLRect;

    void Start()
    {
        eLRect = adaptObj[0].transform.GetChild(0).GetComponent<RectTransform>();
        //eLPanel = eLRect.anchoredPosition.x;
        eLPanel = -17.7f;
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
                        adaptObj[0].transform.position = new Vector2(dragScript.StartX, adaptObj[0].transform.position.y);
                    }
                }
                else
                {
                    Debug.LogError($"Set DragPanel in Methods (RestartScript.cs)");
                }
                break;
            case "Resume-btn":
                jibStartScript.setJibPos();
                break;
            case "Menu-btn":
                break;


        }
    }
}