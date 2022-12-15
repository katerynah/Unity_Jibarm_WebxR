using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserCaught : MonoBehaviour
{
    public bool caught = false;
    public ManageMarks marksScript;
    Image joyBgdImage, joyHandleImage;
    public GameObject joystickBgd;
    Color32 noGrabColor = new Color32(0, 138, 176, 255);  // blue joystick
    Color32 grabColor = new Color32(57, 171, 0, 255);  // green joystick
    public bool resetColor = false;

    void Start()
    {
        joyBgdImage = joystickBgd.GetComponent<Image>();
        joyHandleImage = joystickBgd.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "landmark")
        {
            caught = true;
            marksScript.currLandmark = other.gameObject;
            joyBgdImage.color = grabColor;
            joyHandleImage.color = grabColor;
            Debug.Log($"VCaught {other.gameObject}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        marksScript.currLandmark = other.gameObject;
        joyBgdImage.color = noGrabColor;
        joyHandleImage.color = noGrabColor;
    }

    void Update()
    {
        if (resetColor == true)
        {
            joyBgdImage.color = noGrabColor;
            joyHandleImage.color = noGrabColor;
            resetColor = false;
        }
    }
}
