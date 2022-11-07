using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEL : MonoBehaviour
{
    private bool show = true;
    public GameObject SBLeft;
    public GameObject SBRight;
    public GameObject eLPanel;

    void OnMouseDown()
    {
        toggleEL();
    }

    public void toggleEL()
    {
        if (show)
        {
            SBLeft.SetActive(true);
            SBRight.SetActive(true);
            Image image = eLPanel.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            show = false;
        }
        else if (!show)
        {
            SBLeft.SetActive(false);
            SBRight.SetActive(false);
            Image image = eLPanel.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
            show = true;
        }
    }

}
