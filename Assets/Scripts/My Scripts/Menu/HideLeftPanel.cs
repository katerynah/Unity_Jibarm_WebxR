using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLeftPanel : MonoBehaviour
{
    public RectTransform rightPanel, tBorder, bBorder, rBorder, leftPanel;
    public GameObject[] textObjects;
    public DragPanel dragScript;
    bool toggle = true;
    float oldWidth = 0;

    void Start()
    {
        oldWidth = leftPanel.GetComponent<RectTransform>().rect.width;
    }

    void OnMouseDown()
    {
        hidePanel();
    }

    // Update is called once per frame
    public void hidePanel()
    {
        if (toggle == true)
        {
            leftPanel.sizeDelta = new Vector2(0, leftPanel.rect.height);
            leftPanel.transform.GetChild(0).gameObject.SetActive(false);
            //foreach (GameObject textObj in dragScript.textObjects)
            //{
            //    var tRect = textObj.GetComponent<RectTransform>();
            //    tRect.sizeDelta = new Vector2(tRect.rect.width + oldWidth, tRect.rect.height);
            //    tRect.localPosition = new Vector2(tRect.localPosition.x - oldWidth, tRect.localPosition.y);
            //}
            dragScript.adaptTextObjs();
            var startPosX = rightPanel.localPosition.x;
            var moveX = startPosX - oldWidth;
            rightPanel.localPosition = new Vector2(moveX, rightPanel.localPosition.y);
            rightPanel.sizeDelta = new Vector2(rightPanel.rect.width + oldWidth, rightPanel.rect.height);
            tBorder.sizeDelta = new Vector2(tBorder.rect.width + oldWidth, tBorder.rect.height);
            bBorder.sizeDelta = new Vector2(bBorder.rect.width + oldWidth, bBorder.rect.height);
            tBorder.localPosition = new Vector2(tBorder.localPosition.x + oldWidth, tBorder.localPosition.y);
            bBorder.localPosition = new Vector2(bBorder.localPosition.x + oldWidth, bBorder.localPosition.y);
            rBorder.localPosition = new Vector2(rBorder.localPosition.x + oldWidth, rBorder.localPosition.y);
            toggle = false;
        }
        else if (toggle == false)
        {
            leftPanel.sizeDelta = new Vector2(oldWidth, leftPanel.rect.height);
            leftPanel.transform.GetChild(0).gameObject.SetActive(true);
            //foreach (GameObject textObj in dragScript.textObjects)
            //{
            //    var tRect = textObj.GetComponent<RectTransform>();
            //    tRect.sizeDelta = new Vector2(tRect.rect.width - oldWidth, tRect.rect.height);
            //    tRect.localPosition = new Vector2(tRect.localPosition.x + oldWidth, tRect.localPosition.y);
            //}
            dragScript.adaptTextObjs();
            var endPosX = rightPanel.localPosition.x;
            var _moveX = endPosX + oldWidth;
            rightPanel.localPosition = new Vector2(_moveX, rightPanel.localPosition.y);
            rightPanel.sizeDelta = new Vector2(rightPanel.rect.width - oldWidth, rightPanel.rect.height);
            tBorder.sizeDelta = new Vector2(tBorder.rect.width - oldWidth, tBorder.rect.height);
            bBorder.sizeDelta = new Vector2(bBorder.rect.width - oldWidth, bBorder.rect.height);
            tBorder.localPosition = new Vector2(tBorder.localPosition.x - oldWidth, tBorder.localPosition.y);
            bBorder.localPosition = new Vector2(bBorder.localPosition.x - oldWidth, bBorder.localPosition.y);
            rBorder.localPosition = new Vector2(rBorder.localPosition.x - oldWidth, rBorder.localPosition.y);
            toggle = true;
        }

    }
}
