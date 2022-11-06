using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public GameObject viewAR;

    // Update is called once per frame
    void OnEnable()
    {
        viewAR.SetActive(false);
    }
}
