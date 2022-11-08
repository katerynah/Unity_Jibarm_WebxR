using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHierarchy : MonoBehaviour
{
    public RectTransform setFirstChild;
    private bool once = true;

    // Update is called once per frame
    void OnEnable()
    {
        if (once)
        {
            setFirstChild.SetAsFirstSibling();
            once = false;
        }
    }


}
