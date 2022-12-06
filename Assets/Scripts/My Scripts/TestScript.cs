using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    // Start is called before the first frame update
    //void OnMouseDown()
    //{
    //    testFunction();
    //}

    //void Update()
    //{

    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "raycast")
        {
            Debug.Log($"Entered {other.gameObject.name}");
        }
    }

    //public void testFunction()
    //{
    //    Debug.Log($"Test: {gameObject.name} presses");
    //}
}
