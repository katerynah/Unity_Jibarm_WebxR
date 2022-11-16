using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenu : MonoBehaviour
{
    public List<GameObject> toggleObj = new List<GameObject>();

    void OnMouseDown()
    {
        toggleMenu();
    }

    public void toggleMenu()
    {
        for (int i = 0; i < toggleObj.Count; i++)
        {
            if (!toggleObj[i].activeSelf)
            {
                toggleObj[i].SetActive(true);
            }
            else if (toggleObj[i].activeSelf)
            {
                toggleObj[i].SetActive(false);

            }
        }

    }
}