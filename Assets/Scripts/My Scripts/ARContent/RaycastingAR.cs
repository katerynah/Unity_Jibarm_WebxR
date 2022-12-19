using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingAR : MonoBehaviour
{
    // DESC: Raycasting using Mouse Input Postition and Selection when Mouse Clocked on the Object.tag = "raycast"

    private Transform _selection;
    public Camera ARCamera;
    public SelectionManager selectScript;
    public bool raycasting = false;

    // Lactures
    public EinschaltTasks seilenScript;
    public DiagnoseTasks diagnoseTScript;
    public KoordsysTasks koordsysTScript;
    public VermessenTasks vermessenTScript;

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
                        //case "Bremsen":
                        //    break;
                        //case "Verzerrung":
                        //    break;
                        //case "Tracking":
                        //    break;
                        //case "Homing":
                        //    break;
                        case "Diagnose":
                            diagnoseTScript.doTouch(selection.gameObject);
                            break;
                        //case "Resposition":
                        //    break;
                        case "Koordsys":
                            koordsysTScript.doTouch(selection.gameObject);
                            break;
                        //case "Landmarks":
                        //    break;
                        //case "Laser":
                        //    break;
                        case "Vermessen":
                            //vermessenTScript.doTouch(selection.gameObject);
                            break;
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
