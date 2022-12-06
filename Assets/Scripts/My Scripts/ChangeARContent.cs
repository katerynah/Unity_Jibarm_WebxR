using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeARContent : MonoBehaviour
{
    public SelectionManager selectLectScript;
    public LockPanel enableARScript;

    void Update()
    {   
        if (enableARScript.inAR == true)
        {
            selectLectScript.selectLecture(0);

        } else if (enableARScript.inAR == false)
        {
            selectLectScript.selectLecture(1);
        }
    }

}
