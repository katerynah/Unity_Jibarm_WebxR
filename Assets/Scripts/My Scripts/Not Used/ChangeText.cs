using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField]
    private List<string> btnNames = new List<string>() {
        "Loading..."
    };
    public List<GameObject> btnTextObjects = new List<GameObject>();
    private TextMeshProUGUI currTextObj;

    void Update()
    {
        setStatus();
    }

    public void setStatus()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (btnTextObjects != null)
            {
                for (int i = 0; i < btnTextObjects.Count; i++)
                {
                    
                    currTextObj = btnTextObjects[i].GetComponent<TextMeshProUGUI>();
                    currTextObj.SetText(btnNames[i]);
                    // making unclickable
                    GameObject parentObj = btnTextObjects[i].transform.parent.gameObject;
                    parentObj.GetComponent<Collider>().enabled = false;
                    if (btnTextObjects[0])
                    {
                        Image image = parentObj.GetComponent<Image>();
                        var tempColor = image.color;
                        tempColor.a = 0f;
                        image.color = tempColor;
                    }
                }

            }
        }

    }

}