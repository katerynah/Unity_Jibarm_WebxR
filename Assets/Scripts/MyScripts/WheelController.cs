using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;

    public float acceleration = 500f;
    public float breakingForce = 300f;

    private float currAcceleration = 0f;
    private float currBreakForce = 0f;

    private void FixedUpdate()
    {

        // Get forward/reverse acceleration from the vertical axis (W and S keys)
        // returns values 0-1 -> smooth movement from arrows (both forward and reverse)
        currAcceleration = acceleration * Input.GetAxis("Vertical");

        // If we're pressing space, give currBreakForce a value.

        if (Input.GetKey(KeyCode.Space))
            currBreakForce = breakingForce;
        else
            currBreakForce = 0f; 

        // Apply acceleration to front wheels
        frontRight.motorTorque = currAcceleration;
        frontLeft.motorTorque = currAcceleration;

        frontRight.brakeTorque = currBreakForce;
        frontLeft.brakeTorque = currBreakForce;
        rearRight.brakeTorque = currBreakForce;
        rearLeft.brakeTorque = currBreakForce;

    }

}
