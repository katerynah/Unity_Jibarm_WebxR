using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeARContent : MonoBehaviour
{
    public SelectionManager selectLectScript;
    public LockPanel enableARScript;
    DrawLineBetweenTwoObjects lineScript;
    bool start = true;

    void Update()
    {   
        if (enableARScript.inAR == true && start)
        {
            selectLectScript.selectLecture(0);
            start = false;

        } else if (enableARScript.inAR == false && selectLectScript.removeAR && !start)
        {
            selectLectScript.selectLecture(1);
            start = true;
        }
    }

    public void changeJibColors()
    {

    }

}
