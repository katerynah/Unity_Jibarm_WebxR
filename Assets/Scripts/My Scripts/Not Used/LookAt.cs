using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public List<GameObject> objectsTurned = new List<GameObject>();
    public GameObject toFace;

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < objectsTurned.Count; i++)
        {
            objectsTurned[i].transform.LookAt(toFace.transform, Vector3.one);
        }
    }
}
