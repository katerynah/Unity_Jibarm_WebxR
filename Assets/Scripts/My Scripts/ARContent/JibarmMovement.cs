using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JibarmMovement : MonoBehaviour
{
    [System.Serializable]
    public class Wheels
    {
        public GameObject WheelsFront;
        public GameObject WheelsBack;

        public Wheels(GameObject wheelsF, GameObject wheelseB)
        {
            WheelsFront = wheelsF;
            WheelsBack = wheelseB;
        }
    }

    public List<Wheels> wheels = new List<Wheels>();

    //public CollectObjects collectScript;
    private Joystick joystick;
    private JoystickButton joybutton;
    public GameObject handIcons, jibRotPoint, jib;
    Rigidbody rb;
    float speed = 1f;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoystickButton>();
        rb = jib.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        startMovePos();
    }

    void startMovePos()
    {
        jibRotPoint.transform.Rotate(jibRotPoint.transform.rotation.eulerAngles.x, jibRotPoint.transform.rotation.eulerAngles.y, -5f);
    }

    void Update()
    {
        rb.velocity = new Vector3(joystick.Vertical * speed, rb.velocity.y,  joystick.Horizontal * speed);
    
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name != "RedArea-collider" || other == null)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
