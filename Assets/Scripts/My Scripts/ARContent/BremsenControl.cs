using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BremsenControl : MonoBehaviour
{
    public bool isActive = false;
    [SerializeField]
    float speed = 2f;
    //float minZ = -30f; // -> -45
    //float maxZ = 30f;  // -> 0
    Vector3 objEuler;
    public Material redMat;
    public Material greenMat;
    public BremsenTasks bremsenTScript;

    bool startRotation = true;
    Quaternion startRot;

    public enum Brakes
    {
        BoomTilt, BoomPan, HeadTilt, HeadPan
    }
    public Brakes UseAs;

    void Start()
    {
        startRot = gameObject.transform.rotation;
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
                    case Brakes.BoomTilt:
                        objEuler = gameObject.transform.eulerAngles;
                        if (startRotation == true)
                        {
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * speed);
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * -speed);
                            limitRot(170f, objEuler.z, 0, true);
                        }
                        break;
                    case Brakes.BoomPan:
                        objEuler = gameObject.transform.eulerAngles;
                        if (startRotation == true)
                        {
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * speed);
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * -speed);
                            Debug.Log($"Now {gameObject.transform.eulerAngles.z}");
                            limitRot(230f, objEuler.z, 1, true);
                        }
                        break;
                    case Brakes.HeadTilt:
                        objEuler = gameObject.transform.eulerAngles;

                        if (startRotation == true)
                        {
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * speed);
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * speed);
                            limitRot(355f, objEuler.z, 2, false);
                        }
                        break;
                    case Brakes.HeadPan:
                        objEuler = gameObject.transform.eulerAngles;
                        if (startRotation == true)
                        {
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * speed);
                            gameObject.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") * speed);
                            limitRot(355f, objEuler.z, 3, false);
                        }
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

    void limitRot(float limit, float axisValue, int index, bool bigger)
    {
        

            switch (UseAs)
            {
                case Brakes.BoomTilt:
                    if (bremsenTScript.bremsenArmTilt[0].armTilt == true)
                    {
                        startRotation = false;
                        MeshRenderer newColor = bremsenTScript.spheres[index].GetComponent<MeshRenderer>();
                        newColor.material = greenMat;
                        bremsenTScript.checkboxes[index].SetActive(true);
                    }
                    break;
                case Brakes.BoomPan:
                    if (bremsenTScript.bremsenArmTilt[1].armPan == true)
                    {
                        startRotation = false;
                        MeshRenderer newColor = bremsenTScript.spheres[index].GetComponent<MeshRenderer>();
                        newColor.material = greenMat;
                        bremsenTScript.checkboxes[index].SetActive(true);
                    }
                    break;
                case Brakes.HeadTilt:
                    if (bremsenTScript.bremsenArmTilt[2].camTilt == true)
                    {
                        startRotation = false;
                        MeshRenderer newColor = bremsenTScript.spheres[index].GetComponent<MeshRenderer>();
                        newColor.material = greenMat;
                        bremsenTScript.checkboxes[index].SetActive(true);
                    }
                    break;
                case Brakes.HeadPan:
                    if (bremsenTScript.bremsenArmTilt[3].camPan == true)
                    {
                        startRotation = false;
                        MeshRenderer newColor = bremsenTScript.spheres[index].GetComponent<MeshRenderer>();
                        newColor.material = greenMat;
                        bremsenTScript.checkboxes[index].SetActive(true);
                    }
                    break;
                }

    }

    public void resetRotation()
    {
        //objToRotate.transform.rotation = startRot;
    }
}


//case Rotations.RotateX:
//                        objToRotate.transform.Rotate(Input.GetAxis("Mouse X") / speed, 0f, 0f);
//break;
//                    case Rotations.RotateY:
//                        if (direction == "x")
//{
//    objToRotate.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") / -speed);
//}
//else if (direction == "y")
//{
//    objToRotate.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") / speed);
//    moveLevel();
//}
//limitRot();
//break;
//                    case Rotations.RotateZ:
//                        objToRotate.transform.Rotate(0f, Input.GetAxis("Mouse X") / speed, 0f);
//break;