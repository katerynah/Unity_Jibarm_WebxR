using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public GameObject jib;
    public Camera ARCamera;

    //void Start()
    //{

    //}

    // Start is called before the first frame update
    //void OnMouseDown()
    //{
    //    testFunction();
    //}

    //void Update()
    //{

    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "raycast")
    //    {
    //        Debug.Log($"Entered {other.gameObject.name}");
    //    }
    //}

    public void testFunction()
    {
        jib.SetActive(true);
        ARCamera.GetComponent<Camera>().enabled = true;
        //Debug.Log($"Test: {gameObject.name} presses");
    }
}
