using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {

        //Right, Left, Down, Up

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * 2 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * 2 * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        //Forward, Backward, Rotation: right, left

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(-Vector3.up * speed * Time.deltaTime);

        //Rotation: up, down
        if (Input.GetKey(KeyCode.R))
            transform.Rotate(Vector3.left * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.F))
            transform.Rotate(-Vector3.left * speed * Time.deltaTime);


    }
}