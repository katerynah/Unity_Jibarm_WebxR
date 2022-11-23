using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField]
    GameObject sceneHitTest;
    [SerializeField]
    GameObject jibarm;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (jibarm.activeSelf)
        {
            sceneHitTest.SetActive(false);
        }
    }
}
