using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowCurve : MonoBehaviour
{
    public bool isActive = false;
    public GameObject objToRotate;
    [SerializeField] float speed = 2f;
    float minZ = -115f; // -> -45
    float maxZ = -70f;  // -> 0
    public Vector3 objEuler;
    Transform localTrans;

    public enum Rotations
    {
        RotateX, RotateY, RotateZ
    }
    public Rotations UseAs;

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
                switch (UseAs)
                {
                    case Rotations.RotateX:
                        objToRotate.transform.Rotate(Input.GetAxis("Mouse X") / speed, 0f, 0f);
                        break;
                    case Rotations.RotateY:
                        // Rotation limit set so it moves between -0.35 and 0.1
                        objToRotate.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") / -speed);
                        limitRot();
                        //tr.localEulerAngles = new Vector3(tr.localEulerAngles.x, tr.localEulerAngles.y, Mathf.Clamp(tr.localEulerAngles.z, -30, tr.localEulerAngles.z));
                        break;
                    case Rotations.RotateZ:
                        objToRotate.transform.Rotate(0f, Input.GetAxis("Mouse X") / speed, 0f);
                        break;
                }
                Debug.Log($"Script on {gameObject.name}");
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



