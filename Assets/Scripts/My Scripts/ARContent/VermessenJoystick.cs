using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VermessenJoystick : MonoBehaviour
{
    private Joystick joystick;
    private JoystickButton joybutton;
    public GameObject horRotation, vertRotation;
    //Vector3 rotH;
    //Vector3 rotV;

    float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoystickButton>();
    }

    void Update()
    {
        var rigidbodyH = horRotation.GetComponent<Rigidbody>();
        var rigidbodyV = vertRotation.GetComponent<Rigidbody>();
        Quaternion qHor = Quaternion.Euler(rigidbodyH.velocity.x, joystick.Horizontal * speed, rigidbodyH.velocity.z);
        Quaternion qVert = Quaternion.Euler(rigidbodyV.velocity.x, joystick.Horizontal * speed, joystick.Vertical * speed);
        rigidbodyH.MoveRotation(rigidbodyH.rotation * qHor);
        rigidbodyV.MoveRotation(rigidbodyV.rotation * qVert);
        
    }
}
