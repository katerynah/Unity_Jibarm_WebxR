using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxed : MonoBehaviour
{
    public GameObject[] checkmarks;

    public void checkTheBox(string checkString)
    {
        if (checkString == "left")
        {
            checkmarks[0].SetActive(true);
        }else if (checkString == "right")
        {
            checkmarks[1].SetActive(true);
        }else if (checkString == "camera-pos")
        {
            checkmarks[2].SetActive(true);
        } else if (checkString == "switch-on")
        {
            checkmarks[3].SetActive(true);
        }
        else if (checkString == "area-free")
        {
            checkmarks[0].SetActive(true);
        }
        else if (checkString == "switch-diag")
        {
            checkmarks[0].SetActive(true);
        }
        else if (checkString == "cam-rot")
        {
            checkmarks[0].SetActive(true);
        }
    }
}
