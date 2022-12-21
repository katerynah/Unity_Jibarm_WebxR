using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private Joystick joystick;
    private JoystickButton joybutton;
    public GameObject jib;
    float speed = 1f;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoystickButton>();
        rb = jib.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, GetComponent<Rigidbody>().velocity.y, joystick.Vertical * speed);
    }
}