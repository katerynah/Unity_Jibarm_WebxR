using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JibArmValues : MonoBehaviour
{
    // jibaem, camera, boom tilt, boom pan, cam tilt, cam pan
    public List<GameObject> jibParts = new List<GameObject>();
    public List<Vector3> jibPos = new List<Vector3>();
    public List<Quaternion> jibRot = new List<Quaternion>();
    public bool start = true;


    public void setTheValues()
    {
        if (start == true)
        {
            for (int j = 0; j < jibParts.Count; j++)
            {
                jibPos.Add(jibParts[j].transform.position);
                jibRot.Add(jibParts[j].transform.rotation);
            }
            start = false;
        }

    }

    public void resetTheValues()
    {
        if (start == false)
        {
            for (int j = 0; j < jibParts.Count; j++)
            {
                jibParts[j].transform.position = jibPos[j];
                jibParts[j].transform.rotation = jibRot[j];
            }
            start = true;
        }

    }
}
