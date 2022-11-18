using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    [HideInInspector]
    public bool locked = false;
    public DragPanel dragScript;
    public GameObject eLFullBtn;
    public GameObject unlockIcon;
    public GameObject lockIcon;

    // Update is called once per frame
    public void OnPointerClick()
    {
        if (!locked)
        {
            dragScript.enabled = false;
            eLFullBtn.SetActive(false);
            unlockIcon.SetActive(false);
            lockIcon.SetActive(true);
            locked = true;
        } else if (locked)
        {
            dragScript.enabled = true;
            eLFullBtn.SetActive(true);
            unlockIcon.SetActive(true);
            lockIcon.SetActive(false);
            locked = false;
        }
    }
}
