using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    private Material selectionMaterial;
    private Material defaultMaterial;
    public GameObject pointer;
    [SerializeField]
    private GameObject jibarm;
    //private LayerMask Selectable;

    void Start()
    {
        //Screen.lockCursor = true;
    }

    private Transform _selection;

    void Update()
    {
        if (jibarm.activeSelf)
        {
            //Screen.lockCursor = true;

            if (_selection != null && _selection.gameObject.tag == "raycast")
            {
                //var selectionRenderer = _selection.GetComponent<Renderer>();
                //selectionRenderer.material = defaultMaterial;
                //var pointerRenderer = pointer.GetComponent<Renderer>();
                Image pointerImage = pointer.GetComponent<Image>();
                Color pColor = pointerImage.color;
                pColor = Color.blue;
                pointerImage.color = pColor;
                _selection = null;
            }

            var ray = cam.ScreenPointToRay(Input.mousePosition);
            //cam.transform.position, cam.transform.forward
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var selection = hit.transform;
                var selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null && selection.gameObject.tag == "raycast")
                {
                    defaultMaterial = selectionRenderer.material;
                    Color32 newColor = selectionMaterial.color;
                    newColor = new Color32(43, 0, 250, 210);
                    selectionMaterial.color = newColor;
                    selectionRenderer.material = selectionMaterial;
                    Debug.Log($"Hit {hit.collider.gameObject.name}");


                    Image pointerImage = pointer.GetComponent<Image>();
                    Color pColor = pointerImage.color;
                    pColor = Color.yellow;
                    pointerImage.color = pColor;

                    Debug.Log($"Position clicked: {Input.mousePosition}");
                }
                _selection = selection;
            }
        }
    }
}