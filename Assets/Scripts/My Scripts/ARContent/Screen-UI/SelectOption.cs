using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectOption : MonoBehaviour
{
    public DiagnoseTasks diagnoseTScript;
    Color32 orangeOpt = new Color32(238, 162, 91, 255);
    Color32 greyOpt = new Color32(255, 221, 216, 255);
    Image optBgd;
    Image currOptBgd;
    int i = 0;
    GameObject currObj;
    Transform parentObj;
    //List<GameObject> options = new List<GameObject>();

    public enum Options
    {
        // SYSTEM
        Numeric, Keyboard, Reboot, Shutdown,       
        // CONFIG
        RayLocation, 
        // DIAG
        TestEncoders, ResetEncoders, RestartTracking, StopAll,
        // Other
        Other
    }
    public Options UseAs;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        setOption();
    }

    //void OnMouseOver()
    //{
    //    optBgd = gameObject.GetComponent<Image>();
    //    optBgd.color = orangeOpt;
    //}

    //void OnMouseExit()
    //{
    //    if (currObj != gameObject)
    //    {
    //        optBgd = gameObject.GetComponent<Image>();
    //        optBgd.color = greyOpt;
    //    }
    //    Debug.Log($"Curr {gameObject.name} and go {gameObject.name}");

    //}

    public void setOption()
    {
        switch (UseAs)
        {
            case Options.Shutdown:
                Debug.Log($"Shutdown selected");
                break;
            case Options.Numeric:
                Debug.Log($"Numeric selected");
                break;
            case Options.Reboot:
                Debug.Log($"Reboot selected");
                break;
            case Options.RayLocation:
                Debug.Log($"ShuRaylocationtdown selected");
                break;
        }

        parentObj = gameObject.transform.parent;
        foreach (Transform obj in parentObj)
        {
            currOptBgd = obj.gameObject.GetComponent<Image>();
            currOptBgd.color = greyOpt;
        }
        optBgd = gameObject.GetComponent<Image>();
        optBgd.color = orangeOpt;
    }
}
