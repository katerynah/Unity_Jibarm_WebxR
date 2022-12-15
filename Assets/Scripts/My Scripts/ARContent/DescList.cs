using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescList : MonoBehaviour
{
    public GameObject deskObject;
    public LectManager lectManagerAllgemein;

    void OnMouseDown()
    {
        chooseDesc();
    }

    public void chooseDesc()
    {
        // disable all description objects
        lectManagerAllgemein.disableDesc("one");

        gameObject.GetComponent<ChangeColor>().setColor(true);
        deskObject.SetActive(true);
    }


}
