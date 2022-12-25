using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButtons : MonoBehaviour
{
    public List<GameObject> toggleObj = new List<GameObject>();
    public SelectionManager selectScript;
    public DiagnoseTasks diagnoseTScript;
    [HideInInspector]
    public GameObject parentObj; // for Diagnose

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

        //DESC: Deactivate other option windows when another button pressed
        for (int i = 0; i < diagnoseTScript.screenButtons.Count; i++)
        {
            var screensB = diagnoseTScript.screenButtons[i].ScreenBtn;
            if (screensB != gameObject)
            {
                var optW = diagnoseTScript.screenButtons[i].OptWindow;
                optW.SetActive(false);
            }
        }

        Debug.Log($"{gameObject.name} clicked");

    }

}
