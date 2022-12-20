using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacksColors : MonoBehaviour
{
    public GameObject[] jacks;
    public Material greenMat;

    // Update is called once per frame
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        foreach (GameObject obj in jacks)
        {
            if (other.gameObject == obj)
            {
                var o1 = obj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
                o1.material = greenMat;
                var o2 = obj.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
                o2.material = greenMat;
            }
        }
        
    }
}
