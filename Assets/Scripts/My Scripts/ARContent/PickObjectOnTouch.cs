using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickObjectOnTouch : MonoBehaviour
{
    [HideInInspector]
    public CollectObjects collectScript;
    bool dragObject = false;
    float yValue = 0f;

    void Start()
    {
        collectScript = GameObject.Find("RaycastManager").GetComponent<CollectObjects>();
        yValue = transform.position.y;
    }

    void OnMouseOver()
    {
        // Check if the mouse button is down
        if (Input.GetMouseButton(0))
        {
            // Start moving the object with the camera
            dragObject = true;
        }
        // Check if the mouse button is up
        else if (Input.GetMouseButtonUp(0))
        {
            // Stop moving the object and reset its position
            dragObject = false;
            //transform.position = originalPosition;
            transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
            collectScript.raycasting = true;
            Debug.Log($"Object {gameObject.name} dropping");
            gameObject.GetComponent<PickObjectOnTouch>().enabled = false;
        }
    }

    void Update()
    {
        // If the object is moving with the camera, update its position
        if (dragObject)
        {
            collectScript.raycasting = false;
            Debug.Log($"Object {gameObject.name} dragging");
            transform.position = collectScript.ARCamera.transform.position + new Vector3(0.5f, -0.25f, 1f);
        }
    }

}