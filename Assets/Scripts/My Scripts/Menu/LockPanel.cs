using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    public DragPanel dragScript;
    public GameObject eLFullBtn;

    // Update is called once per frame
    public void OnPointerClick()
    {
        if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            dragScript.enabled = false;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            eLFullBtn.SetActive(false);

        } else if (gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            dragScript.enabled = true;
            //eLFullBtn.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            eLFullBtn.SetActive(true);
        }
    }
}
