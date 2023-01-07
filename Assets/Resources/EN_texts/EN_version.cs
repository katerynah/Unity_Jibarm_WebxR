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
    public RectTransform[] arrows;
    List<float> startPos = new List<float>();
    string setLang = "";


    // Start is called before the first frame update
    void OnMouseDown()
    {
        setEnVersion();
    }

    void Start()
    {
        foreach (RectTransform obj in arrows)
        {
            startPos.Add(obj.localPosition.x);
        }
    }

    // Update is called once per frame
    public void setEnVersion()
    {
        if (btnName.text == "EN")
        {
            btnName.SetText("DE");
            arrows[0].localPosition = new Vector2(10.8f, arrows[0].localPosition.y);
            arrows[1].localPosition = new Vector2(18.5f, arrows[1].localPosition.y);
            setLang = "en";
        }
        else if(btnName.text == "DE")
        {
            btnName.SetText("EN");
            arrows[0].localPosition = new Vector2(startPos[0], arrows[0].localPosition.y);
            arrows[1].localPosition = new Vector2(startPos[1], arrows[1].localPosition.y);
            setLang = "de";
        }

        foreach (JSONReader jsonScript in toEnTexts)
        {
            jsonScript.textLoader(setLang);
        }
    }
}
