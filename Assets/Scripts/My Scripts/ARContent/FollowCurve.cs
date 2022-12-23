using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowCurve : MonoBehaviour
{
    public bool isActive = true;
    public GameObject objToRotate;
    [SerializeField] float speed = 2f;
    float minZ = -145f; // -> -45 -115
    float maxZ = -100f;  // -> 0 -70
    public Vector3 objEuler;
    Transform localTrans;

    void Start()
    {
        localTrans = objToRotate.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is being pressed
        if (Input.GetMouseButton(0) && isActive == true)
        {

            // Check if the mouse has moved since the last frame
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                // Rotation limit set so it moves between -0.35 and 0.1
                objToRotate.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") / -speed);
                limitRot();
            }

            // Check if the left mouse button was released this frame
            if (Input.GetMouseButtonUp(0))
            {
                isActive = false;
            }
            
        }

    }

    void limitRot()
    {
        objEuler = localTrans.rotation.eulerAngles;
        objEuler.z = (objEuler.z > 180) ? objEuler.z - 360 : objEuler.z;
        objEuler.z = Mathf.Clamp(objEuler.z, minZ, maxZ);

        localTrans.rotation = Quaternion.Euler(objEuler);
    }
}



