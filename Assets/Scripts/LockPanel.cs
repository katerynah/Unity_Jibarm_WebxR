using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    bool locked = false;
    public DragPanel dragScript;
    public GameObject unlockIcon;
    public GameObject lockIcon;

    // Update is called once per frame
    public void OnPointerClick()
    {
        if (!locked)
        {
            dragScript.enabled = false;
            unlockIcon.SetActive(false);
            lockIcon.SetActive(true);
            locked = true;

        } else if (locked)
        {
            dragScript.enabled = true;
            unlockIcon.SetActive(true);
            lockIcon.SetActive(false);
            locked = false;
        }
    }
}
