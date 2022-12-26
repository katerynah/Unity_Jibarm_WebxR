using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBremsen : MonoBehaviour
{
    public bool armTilt, armPan, camTilt, camPan = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Boom-Tilt-rotCheck")
        {
            armTilt = true;
        }

        if (other.gameObject.name == "Boom-Pan-rotCheck")
        {
            armPan = true;
        }

        if (other.gameObject.name == "Head-Tilt-rotCheck")
        {
            camTilt = true;
        }

        if (other.gameObject.name == "Head-Pan-rotCheck")
        {
            camPan = true;
        }
    }
}
