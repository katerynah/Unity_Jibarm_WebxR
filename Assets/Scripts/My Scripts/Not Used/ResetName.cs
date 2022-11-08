using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResetName : MonoBehaviour
{
    [SerializeField]
    public int index = 0;
    private TextMeshProUGUI currTextObj;
    public GameObject resetTextObj;
    private string[] names = new string[] { "WebAR" };

    private void OnEnable()
    {
        currTextObj = resetTextObj.GetComponent<TextMeshProUGUI>();
        // making clickable
        GameObject parentObj = resetTextObj.transform.parent.gameObject;
        Image image = parentObj.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
        parentObj.GetComponent<Collider>().enabled = true;
        currTextObj.SetText(names[index]);
    }
}
