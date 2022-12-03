using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScripts : MonoBehaviour
{ 
    public enum Scripts { movingJib, selectingNotation }
    [SerializeField]
    public Scripts currScript;
    JoystickController moveJib;
    bool setScript = true;

    void Start()
    {

        moveJib = GetComponent<JoystickController>();
        Debug.Log($"THe script for Joystick Controller set as {moveJib.name}");
    }

    void Update()
    {
        if (setScript)
        {
            switch (currScript)
            {
                case Scripts.movingJib:
                    moveJib.enabled = true;
                    Debug.Log($"The script is {moveJib.name}");
                    setScript = false;
                    
                    break;
            }
        }
        
    }

    
}
