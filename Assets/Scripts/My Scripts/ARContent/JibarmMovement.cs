using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JibarmMovement : MonoBehaviour
{
    public GameObject wheelsFront, wheelsBack;

    //public CollectObjects collectScript;
    private Joystick joystick;
    private JoystickButton joybutton;
    public JibMoveArea areaScript;
    public GameObject handIcons, jibRotPoint, jib, directJib;
    Rigidbody rb_jib, rb_dir;
    float speed = 0.1f;
    public bool start = false;

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoystickButton>();
        rb_dir = directJib.GetComponent<Rigidbody>();
        rb_jib = jib.GetComponent<Rigidbody>();
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
        if (start && (joystick.Vertical != 0 || joystick.Horizontal != 0) && areaScript.inArea == true)
        {
            rb_dir.velocity = new Vector3(joystick.Vertical * -speed, rb_dir.velocity.y, joystick.Horizontal * -speed);
            Vector3 dir = rb_dir.position - rb_jib.position;
            rb_jib.MovePosition(jib.transform.position + (dir * Time.deltaTime * speed));
            //var targetRotation = Quaternion.LookRotation(new Vector3(rb_dir.position.x - rb_jib.position.x, 0f, rb_dir.position.z - rb_jib.position.z));
            //rb_jib.transform.rotation = Quaternion.Slerp(rb_jib.transform.rotation, targetRotation, speed * Time.deltaTime);
        }
       
    }




    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name != "RedArea-collider" || other == null)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}

   
}
