using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEL : MonoBehaviour
{
    private bool show = true;
    public GameObject eLPanel;

    void OnMouseDown()
    {
        toggleEL();
    }

    public void toggleEL()
    {
        Image image = eLPanel.GetComponent<Image>();
        var tempColor = image.color;

        if (show)
        {
            eLPanel.SetActive(true);
            tempColor.a = 1f;
            image.color = tempColor;
            show = false;
        }
        else if (!show)
        {
            eLPanel.SetActive(false);
            tempColor.a = 0f;
            image.color = tempColor;
            show = true;
        }
    }

}
