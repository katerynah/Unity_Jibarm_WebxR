using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class JSONReader : MonoBehaviour
{

    // Create a field for the save file.
    string saveFile;
    [HideInInspector]
    public string fileContents;

    void Awake()
    {
        //Application.persistentDataPath + "path"
        // Update the path once the persistent path exists.
        saveFile = Application.dataPath + $"/Resources/Lectures/{gameObject.name}.txt";
    }

    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            fileContents = File.ReadAllText(saveFile);
            // Work with JSON
            Debug.Log($"Exists {fileContents}");
        }
        else { 
            Debug.LogError($"No file {saveFile}");
        }
    }

    //public void writeFile()
    //{
    //    // Work with JSON
    //    // Write JSON to file.
    //    File.WriteAllText(saveFile, jsonString);
    //}

}
