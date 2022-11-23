using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPointer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }
}