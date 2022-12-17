using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToMeasure : MonoBehaviour
{
    public bool isActive = false;
    public GameObject horRotation, vertRotation;
    public CheckBoxed checkBoxScript;
    [SerializeField]
    float speedH = 2f;
    [SerializeField]
    float speedV = 2f;

    float horMinZ = -179f;
    float horMaxZ = -100f; 
    public Vector3 objEulerH, objEulerV;
    Quaternion startRotH, startRotV; // to reset rotation
    Transform localTransH, localTransV;
    bool first,second = true;

    void Start()
    {
        localTransH = horRotation.GetComponent<Transform>();
        startRotH = horRotation.transform.rotation;

        localTransV = vertRotation.GetComponent<Transform>();
        startRotV = vertRotation.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is being pressed
        if (Input.GetMouseButton(0) && isActive == true)
        {
            // Check if the mouse has moved since the last frame
            if (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") == 0)
            {
                limitRotH();
            }

            if (Input.GetAxis("Mouse X") == 0 && Input.GetAxis("Mouse Y") != 0)
            {
                limitRotV();
            }

            // Check if the left mouse button was released this frame
            if (Input.GetMouseButtonUp(0))
            {
                isActive = false;
            }
        }

        if (horRotation.transform.localEulerAngles.z < 300f && horRotation.transform.localEulerAngles.z > 270f)
        {
            first = false;
            Debug.Log($"first rot");
        }

        if (vertRotation.transform.localEulerAngles.y < 90f && vertRotation.transform.localEulerAngles.y > 70f)
        {
            second = false;
            Debug.Log($"second rot");
        }

        if (!first && !second)
        {
            checkBoxScript.checkTheBox("cam-rot");
        }
    }

    void limitRotH()
    {
        if (first || second)
        {
            horRotation.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") / -speedH);
        }
    }
        
    void limitRotV()
    {
        if (first || second)
        {
            vertRotation.transform.Rotate(0f, Input.GetAxis("Mouse Y") / speedV, 0f);
        }
    }


    public void resetRotation()
    {
        horRotation.transform.rotation = startRotH;
        vertRotation.transform.rotation = startRotV;
    }
}
