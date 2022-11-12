using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    public List<GameObject> rerunScriptsOn = new List<GameObject>();
    private SmartButton checkBtn;
    private ToggleMenu checkELMenu;
    private bool wasActiveBefore = false;

    void Update()
    {
        if (checkBtn != null)
        {
            switch (checkBtn.name)
            {
                case "Start-btn":
                    //rerunScriptsOn[0].GetComponent<ToggleMenu>().enabled = false;
                    //rerunScriptsOn[0].GetComponent<ToggleMenu>().enabled = true;
                    break;
                case "StartMenu-btn":
                    if (checkELMenu.toggleObj[0].activeSelf)
                    {
                        checkELMenu.toggleObj[0].SetActive(false);
                        // panel was active before click on menu -> then hidden to show Start menu -> click on Resume active again
                        wasActiveBefore = true;
                    }
                    break;
                case "Resume-btn":
                    if (!checkELMenu.toggleObj[0].activeSelf && wasActiveBefore)
                    {
                        checkELMenu.toggleObj[0].SetActive(true);
                        wasActiveBefore = false;
                    }
                    break;
            }
        }
    }
}
