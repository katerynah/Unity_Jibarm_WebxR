using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CollectObjects : MonoBehaviour
{
    // DESC: Raycasting using Camera Screen Center-Postition and Selection when Mouse Over the Object.tag = "raycast"

    private Collider _selection;
    public Camera ARCamera;
    public CountExitObject countScript;
    public SelectionManager selectScript;
    [HideInInspector]
    public GameObject currObject;
    public CheckTheArea areaScript;
    public bool raycasting = false;

    // Lactures
    public SicherheitTasks sicherheitTasksScript;

    // Update is called once per frame
    void Update()
    {
        if (raycasting)
        {
            // When ray leaves the object
            if (_selection != null && _selection.gameObject.tag == "raycast")
            {
                deselectObj();
            }

            // With cam center point
            Ray ray = ARCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // TEST
                var selection = hit.collider;
                // When colliding with object
                if (selection != null && selection.gameObject.tag == "raycast")
                {
                    switch (selectScript.currLectName)
                    {
                        case "Sicherheit":
                            foreach (Transform child in sicherheitTasksScript.modelsGroup.GetComponent<Transform>())
                            {
                                if (selection.gameObject == child.gameObject && areaScript.isInside == true)
                                {
                                    child.gameObject.GetComponent<QuickOutline>().enabled = true;
                                    currObject = child.gameObject;
                                    currObject.GetComponent<PickObjectOnTouch>().enabled = true;
                                    countScript.enabled = true;
                                }
                            }
                            break;

                        case "Verschieben":
                                if (selection.gameObject == GameObject.Find("EichselMoveObj"))
                                {
                                    currObject = selection.gameObject;
                                    currObject.GetComponent<JibarmMovement>().enabled = true;
                                    countScript.enabled = true;
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
        if (currObject != null)
        {
            currObject.gameObject.GetComponent<QuickOutline>().enabled = false;
        }
        currObject = null;
    }
}