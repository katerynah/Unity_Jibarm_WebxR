using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JibarmControl : MonoBehaviour
{
    [HideInInspector]
    public Vector3 jibStartPos;
    public GameObject indicator;

    // Start is called before the first frame update
    void OnEnable()
    {
        jibStartPos = gameObject.transform.position;
    }

    public void setJibPos()
    {
        gameObject.transform.position = jibStartPos;
        indicator.SetActive(false);
    }
}
