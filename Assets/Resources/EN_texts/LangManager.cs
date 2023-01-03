using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangManager : MonoBehaviour
{
    //ngerman version
    public string[] de_Text;

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

    public List<GameObject> lectures = new List<GameObject>();

    public List<EN_Group> ENList = new List<EN_Group>();

    // About

    // Buttons: Neupositionierung

    // Info: About, Requirements, Manual

    // Lectures

    // Nav

    // Desc

    // Notations

    // Images
}
