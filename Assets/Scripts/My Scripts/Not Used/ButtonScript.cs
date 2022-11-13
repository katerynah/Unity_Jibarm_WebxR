using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool menu;
    public GUIStyle buttonStyle;
    public Rect buttonParameters = new Rect(0, 0, 0, 0);

    public Texture myTexture;
    public Rect textureParameters = new Rect(0, 0, 0, 0);
    public GUIStyle labelStyle;
    public Rect labelParameters = new Rect(0, 0, 0, 0);

    void OnGUI()
    {
        if (menu)
        {
            if (GUI.Button(new Rect(buttonParameters), "I'm a button", buttonStyle)) // interactive button, texture plus text
            {
                // do whatever
            }
            GUI.DrawTexture(new Rect(textureParameters), myTexture); // just texture with no interaction
            GUI.Label(new Rect(labelParameters), "I'm a label", labelStyle); // just text with no interaction
        }
    }
}
