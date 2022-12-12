using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenUIRaycast : MonoBehaviour
{
    // DESC: Raycasting using Mouse Input Postition and Selection when Mouse Over the Object.tag = "raycast"

    public Camera ARCamera;
    public bool raycasting = false;
    private GameObject _selection;
    Color32 greyOpt = new Color32(255, 221, 216, 255);
    public SelectionManager selectScript;
    public DiagnoseTasks diagnoseScript;
    GameObject currOption;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (raycasting)
        {
            Debug.Log($"Raycast started");
            // When ray leaves the object
            if (_selection != null && _selection.gameObject.tag == "raycast")
            {
                //deselectObj();
            }

            // With cam center point
            var ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log($"Raycast hit");

                // TEST
                var selection = hit.collider.gameObject;
                Debug.Log($"Hit {selection.name}");

                // When colliding with object
                if (selection != null && selection.tag == "raycast")
                {
                    Debug.Log($"Got hit");

                    switch (selectScript.currLectName)
                    {
                        case "Diagnose":
                            foreach (GameObject child in diagnoseScript.allOptions)
                            {
                                if (selection == child.gameObject)
                                {
                                    currOption = child.gameObject;
                                    //child.gameObject.GetComponent<SelectOption>().selectOptions(currOption);
                                    Debug.Log($"{selection.name} selected");
                                }
                            }
                            break;
                    }

                }
                _selection = selection;
            }
        }
    }

    public void deselectObj()
    {
        if (currOption != null)
        {
            currOption.gameObject.GetComponent<Image>().color = greyOpt;
        }
        currOption = null;
    }
}
