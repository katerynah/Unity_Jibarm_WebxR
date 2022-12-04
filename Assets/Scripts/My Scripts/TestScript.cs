using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public ChangeColor checkObject;

    //// Start is called before the first frame update
    //void OnMouseDown()
    //{
    //    testFunction();
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "raycast")
        {
            //checkObject.setEvent();
            Debug.Log($"Entered {other.gameObject.name}");

        }
    }

    //public void testFunction()
    //{
    //    Debug.Log($"Test: {gameObject.name} presses");
    //}
}
