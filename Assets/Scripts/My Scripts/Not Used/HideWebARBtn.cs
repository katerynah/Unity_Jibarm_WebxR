using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWebARBtn : MonoBehaviour
{
    private GameObject webarBtn;
    private GameObject allgemeinPanel;

    // Start is called before the first frame update
    void Start()
    {
        webarBtn = GameObject.Find("ViewAR");
        allgemeinPanel  = GameObject.Find("Allgemein-Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (allgemeinPanel.activeSelf == false)
        {
            webarBtn.SetActive(false);
            Debug.Log("Btn set to " + webarBtn.activeSelf);
        }
    }
}
