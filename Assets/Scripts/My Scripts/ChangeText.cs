using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    private int changeText = 1; // I want to name it ar
    private string[] btnNames = new string[2];
    public List<GameObject> btnTextObjects = new List<GameObject>();

    private void Start()
    {
        btnNames[0] = "Menu"; // default at start
        btnNames[1] = "AR";
    }

    // Update is called once per frame
    void Update()
    {
        changeBtn();
    }

    public void changeBtn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TextMeshPro currObj = btnTextObjects[0].GetComponent<TextMeshPro>(); // text object of btn

            if (changeText == 0)
            {
                currObj.SetText(btnNames[changeText]);
                changeText = 1;
                Debug.Log("Btn text: " + currObj.text);

            } else if (changeText == 1)
            {
                currObj.SetText(btnNames[changeText]);
                changeText = 0;
                Debug.Log("Btn text: " + currObj.text);
            } 

        } 
    }
}
