using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject toNoColor;

    void OnEnable()
    {
        Image image = toNoColor.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;
    }

    void OnDisable()
    {
        Image image = toNoColor.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }

}
