using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NavControl : MonoBehaviour
{
    public List<RectTransform> moveObjects = new List<RectTransform>();
    private float moveY;

    public void toggleNav()
    {
        var clickedObj = gameObject.transform;

        switch (clickedObj.gameObject.name)
        {
            case "InbetriebDrop":
                moveY = 30f; // distance y
                break;
            case "TrackingDrop":
                moveY = 30f;
                break;
        }

        if (!clickedObj.GetChild(0).gameObject.activeSelf)
        {
            foreach (Transform child in clickedObj)
            {
                if (child.gameObject.name != "Arrow-icon")
                {
                    child.gameObject.SetActive(true);
                }
            }
            // move up
            for (int i = 0; i < moveObjects.Count; i++)
            {
                var pos1 = moveObjects[i].anchoredPosition;
                moveObjects[i].anchoredPosition = new Vector2(pos1.x, pos1.y - moveY);
            }
        }
        else if (clickedObj.GetChild(0).gameObject.activeSelf)
        {
            foreach (Transform child in clickedObj)
            {
                if (child.gameObject.name != "Arrow-icon")
                {
                    child.gameObject.SetActive(false);
                }
            }
            // move down
            for (int i = 0; i < moveObjects.Count; i++)
            {
                var pos1 = moveObjects[i].anchoredPosition;
                moveObjects[i].anchoredPosition = new Vector2(pos1.x, pos1.y + moveY);
            }
        }
    }
}