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
    public StahlseilenWeg seilenScript;

    // Update is called once per frame
    void Update()
    {
        if (raycasting)
        {
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
                var selection = hit.collider;

                // When colliding with object
                if (selection != null && selection.gameObject.tag == "raycast")
                {
                    switch (selectScript.currLectName)
                    {
                        //case "Allgemein":
                        //    break;
                        case "Einschalt":
                            seilenScript.doTouch(selection.gameObject);
                            break;
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
                //_selection = selection;
            }
        }
    }

   
}
