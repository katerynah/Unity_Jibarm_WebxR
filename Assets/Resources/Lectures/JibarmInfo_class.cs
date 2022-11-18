using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JibarmInfo_class : MonoBehaviour
{
    public TextAsset textJSON;
    [HideInInspector]
    public TextMeshProUGUI textContent;
    GameObject textObj;

    void Start()
    {
        DataContainer myJson = JsonUtility.FromJson<DataContainer>(textJSON.text);

        //foreach (JSONData info in myJson.jibarmInfo)
        //{
        //    Debug.Log("Found info: " + info.headline + " " + info.copytext);
        //}

        textObj = gameObject.transform.GetChild(0).gameObject;
        textContent = textObj.GetComponent<TextMeshProUGUI>();
        textContent.SetText(myJson.jibarmInfo[0].headline);

        textObj = gameObject.transform.GetChild(1).gameObject;
        textContent = textObj.GetComponent<TextMeshProUGUI>();
        textContent.SetText(myJson.jibarmInfo[0].copytext);

    }

    //public string adaptString()
    //{
    //    string textType;
    //    string objName;
    //    int charCount;
    //    objName = textObj.name;
    //    charCount = objName.Length; // also containing the "-"
    //    textType = objName.Remove(charCount);
    //    Debug.Log($"The string is {textType}");
    //    return textType;
    //}

}

[System.Serializable]

public class JSONData
{
    public string headline;
    public string copytext;
}

[System.Serializable]
public class DataContainer
{
    //name same as in the json object
    public JSONData[] jibarmInfo;
}







