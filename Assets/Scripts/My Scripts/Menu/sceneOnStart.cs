using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOnStart : MonoBehaviour
{
    public List<GameObject> objectsToEnable = new List<GameObject>();
    public List<GameObject> objectsToDisable = new List<GameObject>();
    [HideInInspector]
    public float DragPanel_startX;
    public Canvas startCanvas;
    public GameObject dragPanel;

    [HideInInspector]
    public float adjustRWidth;
    private Vector2 newWidth;


    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        OnOffObjects();
        adjustELPanelWidth();
        DragPanel_startX = dragPanel.transform.position.x;

    }

    void adjustELPanelWidth()
    {
        float cHeight = startCanvas.GetComponent<RectTransform>().rect.height;
        newWidth = new Vector2(startCanvas.GetComponent<RectTransform>().rect.width, cHeight); // width + 5f a bit bigger just in case
        //eLPanel
        RectTransform panelRect = dragPanel.transform.GetChild(0).GetComponent<RectTransform>();
        panelRect.sizeDelta = newWidth;
        // RightPanel
        RectTransform rPanel = dragPanel.transform.GetChild(2).GetComponent<RectTransform>();
        rPanel.sizeDelta = new Vector2(0f, cHeight);
    }

    void OnOffObjects()
    {
        for (int i = 0; i < objectsToEnable.Count; i++)
        {
            if (!objectsToEnable[i].activeSelf)
            {
                objectsToEnable[i].SetActive(true);

            }
        }

        for (int i = 0; i < objectsToDisable.Count; i++)
        {
            if (objectsToDisable[i].activeSelf)
            {
                objectsToDisable[i].SetActive(false);

            }
        }
    }
}