using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRotation : MonoBehaviour
{
    Color32 blueColor = new Color32(222, 122, 12, 255);
    Color32 greyColor = new Color32(82, 88, 89, 255);
    public GameObject otherBtn;
    SetZeroPoints zeroPScript, otherScript;
    Image btnImage, otherImage;

    void Start()
    {
        zeroPScript = gameObject.GetComponent<SetZeroPoints>();
        otherScript = otherBtn.GetComponent<SetZeroPoints>();
        btnImage = gameObject.GetComponent<Image>();
        otherImage = otherBtn.GetComponent<Image>();
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        selectRotation();
    }

    // Update is called once per frame
    public void selectRotation()
    {
        otherScript.isActive = false;
        otherScript.enabled = false;
        zeroPScript.isActive = true;
        zeroPScript.enabled = true;
        btnImage.color = blueColor;
        otherImage.color = greyColor;
        Debug.Log($"Now button {gameObject.name}");
    }
}
