using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class enHelper : MonoBehaviour
{
    public List<GameObject> descObjects = new List<GameObject>();
    public List<TextAsset> textAssets = new List<TextAsset>();
    //public List<GameObject> checkObjects = new List<GameObject>();
    public List<string> de_Text = new List<string>();
    public List<string> en_Text = new List<string>();
    bool once = true;

    TextMeshProUGUI textContent;



    // Update is called once per frame
    public void enForDesc()
    {
        if (once == true)
        {
            foreach (Transform child in gameObject.transform)
            {
                descObjects.Add(child.gameObject);
            }

            foreach (GameObject obj in descObjects)
            {
                textContent = obj.GetComponent<TextMeshProUGUI>();
                de_Text.Add(textContent.text);
            }
            once = false;
        }

        foreach (TextAsset tAsset in textAssets)
        {
            //DataContainer myJson = JsonUtility.FromJson<DataContainer>(tAsset.text);
            //for(int i = 0; i < myJson.aboutJibarm.Count; i++)
            //{
            //    Debug.Log(myJson.aboutJibarm[i].copytext);
            //}

            DataContainer myJson = JsonUtility.FromJson<DataContainer>(tAsset.text);
            for (int i = 0; i < myJson.aboutJibarm.Count; i++)
            {
                string desc = myJson.aboutJibarm[i].copytext;
                Debug.Log($"En added {desc}");
                en_Text.Add(desc);
            }
        }
    }

    //[System.Serializable]
    //public class Person
    //{
    //    public string name;
    //    public Person(string _name, int _age)
    //    {
    //        name = _name;
    //    }
    //}

    //[System.Serializable]
    //public class PersonData
    //{
    //    public List<Person> client;
    //}


    [System.Serializable]
    public class DataContainer
    {
        public List<JSONData> aboutJibarm;
    }

    [System.Serializable]
    public class JSONData
    {
        public string copytext;
    }
}
