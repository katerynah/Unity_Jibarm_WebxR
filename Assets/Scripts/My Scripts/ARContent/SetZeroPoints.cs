using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZeroPoints : MonoBehaviour
{
    public bool isActive = true;
    public GameObject horRotation, vertRotation;
    [SerializeField]
    float speedH = 2f;
    [SerializeField]
    float speedV = 2f;

    public Vector3 objEulerH, objEulerV;
    Quaternion startRotH, startRotV; // to reset rotation
    Transform localTransH, localTransV;
    Rigidbody rigidbodyH, rigidbodyV;
    Quaternion qHor, qVert;
    public GameObject[] checkmarks;
    bool stopVert, stopHor = false;
    public string option = "homing";

    public enum JibRotationArea
    {
        Boom, Head
    }
    public JibRotationArea UseAs;

    void Start()
    {
        localTransH = horRotation.GetComponent<Transform>();
        //startRotH = horRotation.transform.rotation;
        localTransV = vertRotation.GetComponent<Transform>();
        //startRotV = vertRotation.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button is being pressed
        if (Input.GetMouseButton(0) && isActive == true)
        {
            if (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0)
            {
                controlRot();
                setLimits(option);
            }

            // Check if the left mouse button was released this frame
            if (Input.GetMouseButtonUp(0))
            {
                isActive = false;
            }
        }
    }

    void controlRot()
    {
        switch (UseAs)
        {
            case JibRotationArea.Boom:
                if (stopHor == false)
                {
                    horRotation.transform.Rotate(0f, Input.GetAxis("Mouse X") * speedH, 0f);
                }

                if (option == "homing")
                {
                    if (stopVert == false)
                    {
                        vertRotation.transform.Rotate(0f, 0f, Input.GetAxis("Mouse Y") / speedV);
                    }
                }
                    
                break;

            case JibRotationArea.Head:
                if (stopHor == false)
                {
                    horRotation.transform.Rotate(0f, 0f, Input.GetAxis("Mouse X") * -speedH);
                }

                if (stopVert == false)
                {
                    vertRotation.transform.Rotate(0f, Input.GetAxis("Mouse Y") * speedV, 0f);
                }
                break;
        }

        //horRotation.transform.Rotate(0f, Input.GetAxis("Mouse X") / speedH, 0f);
    }

    void setLimits(string lect)
    {
        switch (UseAs)
        {
            case JibRotationArea.Boom:
                if (lect == "homing")
                {
                    var adaptH = horRotation.transform.localEulerAngles;
                    adaptH.y = (adaptH.y > 180) ? adaptH.y - 360 : adaptH.y;
                    if (adaptH.y > 0 && adaptH.y < 1)
                    {
                        stopHor = true;
                        checkmarks[1].SetActive(true);
                    }
                    else
                    {
                        checkmarks[1].SetActive(false);
                    } 

                    var adaptV = vertRotation.transform.localEulerAngles;
                    adaptV.z = (adaptV.z > 180) ? adaptV.z - 360 : adaptV.z;
                    if (adaptV.z > 0 && adaptV.z < 1)
                    {
                        stopVert = true;
                        checkmarks[0].SetActive(true);
                    }
                    else
                    {
                        checkmarks[0].SetActive(false);
                    }

                    
                    //Debug.Log($"Hoz y is {adaptH.y}");
                }
                else if (lect == "verschieben")
                {
                    var adaptV = vertRotation.transform.localEulerAngles;
                    adaptV.z = (adaptV.z > 180) ? adaptV.z - 360 : adaptV.z;
                    if (adaptV.z > 0 && adaptV.z < 1)
                    {
                        stopVert = true;
                        checkmarks[0].SetActive(true);
                    }
                    else
                    {
                        checkmarks[0].SetActive(false);
                    }
                }
               

                //Debug.Log($"Vert Z is {adaptV.z}");
                break;

            case JibRotationArea.Head:
                var adaptH1 = horRotation.transform.localEulerAngles;
                adaptH1.z = (adaptH1.z > 180) ? adaptH1.z - 360 : adaptH1.z;
                Debug.Log($"z {adaptH1.z}");

                if (adaptH1.z > 0 && adaptH1.z < 1)
                {
                    stopHor = true;
                    checkmarks[0].SetActive(true);
                }
                else
                {
                    checkmarks[0].SetActive(false);
                }


                //Debug.Log($"Hoz y is {adaptH.y}");

                var adaptV1 = vertRotation.transform.localEulerAngles;
                adaptV1.y = (adaptV1.y > 180) ? adaptV1.y - 360 : adaptV1.y;
                Debug.Log($"y {adaptH1.y}");

                if (adaptV1.y < 0 && adaptV1.y > -1)
                {
                    stopVert = true;
                    checkmarks[1].SetActive(true);
                }
                else {
                    checkmarks[1].SetActive(false);
                }

                break;
        }
    }


    public void resetRotation()
    {
        horRotation.transform.rotation = startRotH;
        if (option == "homing")
        {
            vertRotation.transform.rotation = startRotV;
        }
    }
}
