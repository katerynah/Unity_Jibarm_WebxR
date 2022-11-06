using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHierarchy : MonoBehaviour
{
    public RectTransform viewARBtn;
    private bool once = true;

    // Update is called once per frame
    void OnEnable()
    {
        if (once)
        {
            viewARBtn.SetAsFirstSibling();
            once = false;
        }
    }
}
