using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTheArea : MonoBehaviour
{
    public bool isInside = false;


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RedArea-collider")
        {
            Debug.Log($"Raycast with {isInside}");
            isInside = true;
        } 
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RedArea-collider")
        {
            Debug.Log($"Raycast with {isInside}");
            isInside = false;
        }
    }
}
