using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhoneOrientation : MonoBehaviour
{
    [SerializeField]
    public GameObject rotateCanvas;
    public GameObject canvasGroup; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width < Screen.height)
        {
            canvasGroup.SetActive(false);
            rotateCanvas.SetActive(true);
        }
        else
        {
            rotateCanvas.SetActive(false);
            canvasGroup.SetActive(true);
        }
    }
}
