using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingAR : MonoBehaviour
{
    private Transform _selection;
    public Camera ARCamera;
    public SelectionManager selectScript;
    public bool raycasting = false;

    // Lactures
    AllgemeinLect allgemeinScript;

    // Update is called once per frame
    void Update()
    {
        if (raycasting)
        {
            // TEST
            Debug.Log($"Raycast true");

            // When ray leaves the object
            if (_selection != null && _selection.gameObject.tag == "raycast")
            {
                //var selectionRenderer = _selection.GetComponent<Renderer>();
                //selectionRenderer.material = defaultMaterial;
                //var pointerRenderer = pointer.GetComponent<Renderer>();
            }

            // With cam center point
            //cam.transform.position, cam.transform.forward

            // With mouse
            var ray = ARCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // TEST
                Debug.Log($"Raycast started");
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();

                // When colliding with object
                if (selectionRenderer != null && selection.gameObject.tag == "raycast")
                {
                    Debug.Log($"Current Lecture name {selectScript.currLectName}");
                    switch (selectScript.currLectName)
                    {
                        case "Allgemein":
                            // No
                            break;
                        //case "Einschalt":
                        //    break;
                        //case "Sicherheit":
                        //    break;
                        //case "Bremsen":
                        //    break;
                        //case "Verzerrung":
                        //    break;
                        //case "Tracking":
                        //    break;
                        //case "Homing":
                        //    break;
                        //case "Diagnose":
                        //    break;
                        //case "Resposition":
                        //    break;
                        //case "Koordsys":
                        //    break;
                        //case "Landmarks":
                        //    break;
                        //case "Laser":
                        //    break;
                        //case "Vermessen":
                        //    break;
                        //case "Verschieben":
                        //    break;
                        //case "Nivellieren":
                        //    break;
                    }

                }
                _selection = selection;
            }
        }
    }

   
}
