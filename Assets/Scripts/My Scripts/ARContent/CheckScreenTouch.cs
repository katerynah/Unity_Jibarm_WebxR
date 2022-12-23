using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScreenTouch : MonoBehaviour
{
    public DiagnoseTasks diagnoseTScript;
    public SelectionManager selectScript;
    public GameObject[] checkmarks;
    public GameObject screenView;


    // Start is called before the first frame update
    void OnMouseDown()
    {
        checkMenuCLicks();
    }

    // Update is called once per frame
    public void checkMenuCLicks()
    {
        if (selectScript.currLectName == "Diagnose")
        {

            switch (diagnoseTScript.index)
            {
                case 1:
                    checkmarks[0].SetActive(true);
                    break;
                case 2:
                    checkmarks[1].SetActive(true);
                    break;
                case 3:
                    checkmarks[2].SetActive(true);
                    break;
                case 4:
                    checkmarks[3].SetActive(true);
                    break;
                case 5:
                    checkmarks[4].SetActive(true);
                    break;
            }

        }
    }

}
