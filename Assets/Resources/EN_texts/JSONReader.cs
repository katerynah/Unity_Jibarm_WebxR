using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public List<GameObject> moreObjects = new List<GameObject>();
    public List<TextAsset> moreTextAssets = new List<TextAsset>();
    public List<string> de_Text = new List<string>();

    public List<GameObject> newList = new List<GameObject>();
    

    // Create a field for the save file.
    TextMeshProUGUI textContent;
    DataContainer myJson;
    bool once = true;
    //public string lang = "en";

    //public List<GameObject> changeText = new List<GameObject>();
    //public List<string> fileName = new List<string>();
    string de_TextH;

    [System.Serializable]
    public class EN_Group
    {
        public GameObject TextToEN;
        public TextAsset FileName;

        public EN_Group(GameObject textToEN, TextAsset fileName)
        {
            TextToEN = textToEN;
            FileName = fileName;
        }
    }

    public List<EN_Group> ENList = new List<EN_Group>();

    public enum Groups
    {
        About, Buttons, Info, Lectures, Nav, Desc, Notations, Images
    }
    public Groups UseAs;




    public void textLoader(string lang)
    {

        switch (UseAs)
        {
            case Groups.About:
                TextMeshProUGUI textContentH = ENList[1].TextToEN.GetComponent<TextMeshProUGUI>();
                if (lang == "en")
                {
                    textContent = ENList[0].TextToEN.GetComponent<TextMeshProUGUI>(); 
                    if (once == true)
                    {
                        de_Text.Add(textContent.text);
                        de_TextH = textContentH.text;
                        once = false;
                    }
                    myJson = JsonUtility.FromJson<DataContainer>(ENList[0].FileName.text);
                    textContent.SetText(myJson.aboutJibarm[0].copytext);
                    textContentH.SetText(myJson.aboutJibarm[0].headline);
                }
                else if (lang == "de")
                {
                    textContent.SetText(de_Text[0]);
                    textContentH.SetText(de_TextH);
                }
                break;
            case Groups.Lectures:
                if (lang == "en")
                {
                    if (moreObjects.Count < 5)
                    {
                        setLectureContent();
                    }
                    int j = 0;
                    foreach (GameObject textObjs in moreObjects)
                    {
                        textContent = textObjs.GetComponent<TextMeshProUGUI>();
                        if (j < 12 && once == true)
                        {
                            de_Text.Add(textContent.text);
                        }
                        else
                        {
                            once = false;
                        }

                        myJson = JsonUtility.FromJson<DataContainer>(moreTextAssets[j].text);
                        textContent.SetText(myJson.aboutJibarm[0].copytext);
                        j++;
                    }

                }
                else if (lang == "de")
                {
                    int k = 0;
                    foreach (GameObject textObjs in moreObjects)
                    {
                        TextMeshProUGUI replaced = textObjs.GetComponent<TextMeshProUGUI>();
                        replaced.SetText(de_Text[k]);
                        k++;
                    }
                }
                break;
        }
        
    }

    void setLectureContent()
    {

        int i = 0;
        foreach (GameObject obj in moreObjects)
        {
            if (i == 0)
            {
                var objChild = obj.transform.GetChild(0).gameObject;
                newList.Add(objChild);
                Debug.Log($"First {obj.transform.GetChild(0).gameObject.name}");
            }
            else
            {
                foreach (Transform child in obj.GetComponent<Transform>())
                {
                    var objChild = child.transform.GetChild(0).gameObject;
                    newList.Add(objChild);
                    Debug.Log($"Other {child.transform.GetChild(0).gameObject.name}");
                }
            }
            i++;
        }
        moreObjects = newList;
    }

    [System.Serializable]

    public class JSONData
    {
        public string copytext;
        public string headline;
    }

    [System.Serializable]
    public class DataContainer
    {
        //name same as in the json object
        public JSONData[] aboutJibarm;
    }

    void addNewText()
    {
       
        //Application.persistentDataPath + "path"
        // Update the path once the persistent path exists.
        //saveFile = Application.dataPath + $"/Resources/EN_texts/{ENList[0].FileName}.txt";
        //addNewText();

        //DataContainer myJson = JsonUtility.FromJson<DataContainer>(textJSON.text);

        //foreach (JSONData info in myJson.jibarmInfo)
        //{
        //    Debug.Log("Found info: " + info.headline + " " + info.copytext);
        //}

        //textObj = gameObject.transform.GetChild(0).gameObject;
        //textContent.SetText(myJson.aboutJibarm[0].copytext);
    }

    

    //public void readFile()
    //{

    //    // Does the file exist?
    //    if (File.Exists(saveFile))
    //    {
    //        // Read the entire file and save its contents.
    //        //fileContents = File.ReadAllText(saveFile);
    //        // Work with JSON
    //        //Debug.Log($"Exists {fileContents}");
    //        addNewText($"{saveFile}");
    //    }
    //    else { 
    //        Debug.LogError($"No file {saveFile}");
    //    }
    //}



    //public void writeFile()
    //{
    //    // Work with JSON
    //    // Write JSON to file.
    //    File.WriteAllText(saveFile, jsonString);
    //}

}
