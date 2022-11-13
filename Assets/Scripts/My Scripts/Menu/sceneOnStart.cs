using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOnStart : MonoBehaviour
{
    public List<GameObject> objectsToEnable = new List<GameObject>();
    public List<GameObject> objectsToDisable = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        OnOffObjects();
        adjustELPanelWidth();
    }

    void adjustELPanelWidth()
    {
        Vector2 newWidth;
        Canvas canvas;
        canvas = GameObject.Find("WebARCanvas").GetComponent<Canvas>();
        if (objectsToDisable[4].name == "eLPanel")
        {
            newWidth = new Vector2(canvas.GetComponent<RectTransform>().rect.width, canvas.GetComponent<RectTransform>().rect.height);
            RectTransform panelRect = objectsToDisable[4].GetComponent<RectTransform>();
            panelRect.sizeDelta = newWidth;
        } else
        {
            Debug.LogError("Set eLPanel in Methods (sceneOnStart.cs)");
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
