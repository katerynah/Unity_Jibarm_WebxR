using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }
}