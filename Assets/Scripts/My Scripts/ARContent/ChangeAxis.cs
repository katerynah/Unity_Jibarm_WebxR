using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAxis : MonoBehaviour
{
    bool toggle = true;
    public AdaptJacks adaptJScript;
    public GameObject jibPan;
    float timeRemaining = 2;
    public GameObject frontAxis, backAxis;
    public Animator[] jointAnim;
    public GameObject[] nilPoint;
    float speed = 20f;
    Rigidbody rb;

    void Start()
    {
        rb = jibPan.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        selectRotation();
    }

    // Update is called once per frame
    public void selectRotation()
    {
        if (toggle == true)
        {
            jointAnim[1].enabled = false;
            adaptJScript.anim[0].Play("RotArmR", -1, 0f);
            jointAnim[0].enabled = true;
            frontAxis.SetActive(true);
            backAxis.SetActive(false);
            adaptJScript.toWhite();

            toggle = false;
        }
        else if (toggle == false)
        {
            jointAnim[0].enabled = false;
            adaptJScript.anim[0].Play("RotArmL", -1, 0f);
            jointAnim[1].enabled = true;
            rb.transform.Rotate(0, -90, 0);
            frontAxis.SetActive(false);
            backAxis.SetActive(true);
            toggle = true;
        }

        if (nilPoint[0].activeSelf == true && adaptJScript.countDown == 0)
        {
            adaptJScript.countDown = 1;
            nilPoint[0].SetActive(false);
            nilPoint[2].SetActive(true); 
        }
        else if (nilPoint[0].activeSelf == true && adaptJScript.countDown == 1)
        {
            adaptJScript.countDown = 2;
        }
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}

