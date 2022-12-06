using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxed : MonoBehaviour
{
    public GameObject check1, check2;
    public EinschaltLect einschaltScript;

    public void checkTheBox(string whichWire)
    {
        if (whichWire == "left")
        {
            check1.SetActive(true);
        } else if (whichWire == "right")
        {
            check2.SetActive(true);
        }
    }
}
