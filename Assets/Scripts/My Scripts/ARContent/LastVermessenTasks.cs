using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastVermessenTasks : MonoBehaviour
{
    public GameObject[] checkmarks;
    public SelectionManager selectScript;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        locateAndSave();
    }

    // Update is called once per frame
    public void locateAndSave()
    {
        if (selectScript.currLectName == "Vermessen")
        {
            switch (gameObject.name)
            {
                case "Locate-btn":
                    checkmarks[0].SetActive(true);
                    break;
                case "Save-btn":
                    checkmarks[1].SetActive(true);
                    break;

            }

        }
            
    }
}
