using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickObjectOnTouch : MonoBehaviour
{
    public CollectObjects collectScript;
    public CountExitObject countScript;
    bool dragObject = false;
    float yValue = 0f;
    GameObject fxPrefab;
    GameObject fxCopy;
    Vector3 vec;
    Quaternion quat;

    void Start()
    {
        yValue = transform.position.y;
        vec = Vector3.zero;
        quat = Quaternion.identity;
    }


    void Update()
    {
        // Check if the mouse button is down
        if (Input.GetMouseButtonDown(0))
        {
            // Start moving the object with the camera
            dragObject = true;

            fxPrefab = Resources.Load<GameObject>("Templates/FX_Smoke");

            fxCopy = Instantiate(fxPrefab, vec, quat);

            fxCopy.transform.position = gameObject.transform.position;

            countScript.start = true;

            gameObject.SetActive(false);
            //collectScript.raycasting = true;
            //gameObject.GetComponent<PickObjectOnTouch>().enabled = false;
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    // Set the isDragging flag to false
        //    dragObject = false;
        //    transform.position = new Vector3(transform.position.x, yValue, transform.position.z);
        //    //collectScript.raycasting = false;
        //    //gameObject.GetComponent<PickObjectOnTouch>().enabled = false;
        //}

        //// Check if the object is being dragged
        //if (dragObject)
        //{
        //    transform.position = collectScript.ARCamera.transform.position + new Vector3(0f, -0.25f, 0.5f);
        //}
    }
}