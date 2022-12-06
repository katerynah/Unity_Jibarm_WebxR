using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject ARCam;
    public GameObject jib;
    public GameObject player;

    void Update()
    {
        if (jib.activeSelf == true)
        {
            player.transform.position = ARCam.transform.position + new Vector3(0, -0.44f, 0);
        }
    }
        

}
