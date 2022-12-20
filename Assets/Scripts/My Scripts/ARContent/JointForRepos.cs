using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointForRepos : MonoBehaviour
{
    public bool isActive = false;
    public GameObject objToRotate;
    float speed = 1.5f;
    float minZ = -30f; // -> -45
    float maxZ = 30f;  // -> 0
    public Vector3 objEuler;
    Quaternion startRot;
    public bool start = true;
    Transform localTrans;
    public CheckBoxed checkBoScript;

    public enum Rotations
    {
        RotateX, RotateY, RotateZ
    }
    public Rotations UseAs;

    void Start()
    {
        localTrans = objToRotate.GetComponent<Transform>();
        startRot = objToRotate.transform.rotation;
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
                switch (UseAs)
                {
                    case Rotations.RotateX:
                        objToRotate.transform.Rotate(Input.GetAxis("Mouse X") / speed, 0f, 0f);
                        break;
                    case Rotations.RotateY:
                        if (start == true)
                        {
                            objToRotate.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") / -speed);
                            objToRotate.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") / speed);
                        }
                        limitRot();
                        break;
                    case Rotations.RotateZ:
                        objToRotate.transform.Rotate(0f, Input.GetAxis("Mouse X") / speed, 0f);
                        break;
                }
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
        Debug.Log($"Current euler angles {objEuler.z}");

        if (objEuler.z < -15f)
        {
            checkBoScript.checkmarks[0].SetActive(true);
            start = false;
        }


    }

    public void resetRotation()
    {
        objToRotate.transform.rotation = startRot;
    }
}
