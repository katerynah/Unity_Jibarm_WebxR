using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    // dragPanel, Jib, 
    public List<GameObject> adaptObj = new List<GameObject>();
    
    Vector2 dragPose, imgPose;
    public GameObject dragImage;
    [SerializeField]
    public DragPanel dragScript;
    bool doFirst = true;
    float startPose = -14f;

    void Start()
    {
        dragPose = dragScript.gameObject.GetComponent<RectTransform>().anchoredPosition;
        imgPose = dragImage.GetComponent<RectTransform>().anchoredPosition;
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
                        adaptObj[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(startPose, adaptObj[0].transform.position.y);
                        doFirst = false;
                    }
                    else if(!doFirst)
                    {
                        adaptObj[0].GetComponent<RectTransform>().anchoredPosition = dragPose;
                        dragImage.GetComponent<RectTransform>().anchoredPosition = imgPose;
                    }
                }
                else
                {
                    Debug.LogError($"Set DragPanel in Methods (RestartScript.cs)");
                }
                break;
            case "Resume-btn":
                if (!doFirst)
                {
                    // TEST: change EndX to startX after testing
                    adaptObj[0].transform.position = dragScript.currentPose.position;
                    // TEST: remove after testing
                    dragScript.adaptTextObjs();
                }
                break;
            case "Menu-btn":
                //gameObject.GetComponent<SceneOnStart>().checkScreenSize();
                break;


        }
    }
}