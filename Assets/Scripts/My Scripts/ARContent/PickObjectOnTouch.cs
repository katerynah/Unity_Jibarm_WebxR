using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickObjectOnTouch : MonoBehaviour
{
    public CollectObjects collectScript;
    bool dragObject = false;
    //public GameObject handIcons;
    float yValue = 0f;

    void Start()
    {
        yValue = transform.position.y;
    }


    void Update()
    {
        // Check if the mouse button is down
        if (Input.GetMouseButton(0))
        {
                // Start moving the object with the camera
                dragObject = true;
                //handIcons.transform.GetChild(0).gameObject.SetActive(false);
                //handIcons.transform.GetChild(1).gameObject.SetActive(true);
                //collectScript.raycasting = true;
                //gameObject.GetComponent<PickObjectOnTouch>().enabled = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
                // Set the isDragging flag to false
                dragObject = false;
                //handIcons.transform.GetChild(0).gameObject.SetActive(true);
                //handIcons.transform.GetChild(1).gameObject.SetActive(false);
                transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
                //collectScript.raycasting = false;
                //gameObject.GetComponent<PickObjectOnTouch>().enabled = false;
        }

        // Check if the object is being dragged
        if (dragObject)
        {
            transform.position = collectScript.ARCamera.transform.position + new Vector3(0f, -0.25f, 0.5f);
        } 
    }

    //private void OnDisable()
    //{
    //    handIcons.transform.GetChild(0).gameObject.SetActive(false);
    //    handIcons.transform.GetChild(1).gameObject.SetActive(true);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "RedArea-collider" || other == null)
        {
            Destroy(gameObject);
        }
    }

}

