using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EN_version : MonoBehaviour
{
    public List<JSONReader> toEnTexts = new List<JSONReader>();
    //string[] btnNames = { "EN", "DE" };
    bool toggle = true;
    public TextMeshProUGUI btnName;
    string setLang = "";


    // Start is called before the first frame update
    void OnMouseDown()
    {
        setEnVersion();
    }

    // Update is called once per frame
    public void setEnVersion()
    {
        if (btnName.text == "EN")
        {
            btnName.SetText("DE");
            setLang = "en";
        }
        else if(btnName.text == "DE")
        {
            btnName.SetText("EN");
            setLang = "de";
        }

        foreach (JSONReader jsonScript in toEnTexts)
        {
            jsonScript.textLoader(setLang);
        }
    }
}
