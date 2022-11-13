using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScript : MonoBehaviour
{
    // eLPanel
    public List<GameObject> adaptObj = new List<GameObject>();
    private ToggleMenu checkELMenu;
    private bool wasActiveBefore = false;
    float eLPanel_x;

    void Start()
    {
        eLPanel_x = adaptObj[0].transform.position.x;
        //checkELMenu = GameObject.Find("eL-btn").GetComponent<ToggleMenu>();
    }

    public void adaptScripts(GameObject clickedBtn)
    {
        switch (clickedBtn.name)
        {
            case "Start-btn":
                if (adaptObj[0].name == "eLPanel")
                {
                    adaptObj[0].transform.position = new Vector2(eLPanel_x, adaptObj[0].transform.position.y);
                }
                break;
            case "Resume-btn":
                break;
            case "StartMenu-btn":
                break;


        }
    }
}
