using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOnStart : MonoBehaviour
{
    public List<GameObject> objectsToEnable = new List<GameObject>();
    public List<GameObject> objectsToDisable = new List<GameObject>();
    public float DragPanel_startX;

    // Start is called before the first frame update
    void Start()
    {
        OnOffObjects();
        adjustELPanelWidth();
        DragPanel_startX = objectsToDisable[4].transform.position.x;

    }

    void adjustELPanelWidth()
    {
        Vector2 newWidth;
        Canvas canvas;
        canvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        if (objectsToDisable[4].name == "DragPanel")
        {
            float cHeight = canvas.GetComponent<RectTransform>().rect.height;
            newWidth = new Vector2(canvas.GetComponent<RectTransform>().rect.width, cHeight);
            //eLPanel
            RectTransform panelRect = objectsToDisable[4].transform.GetChild(0).GetComponent<RectTransform>();
            panelRect.sizeDelta = newWidth;
            // RightPanel
            RectTransform rPanel = objectsToDisable[4].transform.GetChild(2).GetComponent<RectTransform>();
            rPanel.sizeDelta = new Vector2(newWidth.x * 0.8f, cHeight);
            //eLPanel
            Debug.Log($"Panel width: {newWidth}");
        }
        else
        {
            Debug.LogError("Set DragPanel in Methods (SceneOnStart.cs)");
        }

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