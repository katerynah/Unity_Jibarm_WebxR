using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToEN : MonoBehaviour
{
    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {

            start = false;
        }
    }
}
