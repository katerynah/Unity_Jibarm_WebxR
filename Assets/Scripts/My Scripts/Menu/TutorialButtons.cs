using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    public List<GameObject> toggleObj = new List<GameObject>();
    public GameObject jib, groupTutorial, loading;
    int status = 0;
    public bool start = true;

    public void OnPointerClick()
    {
        if (gameObject.name == "Allgemein-btn")
        {
            toggleObj[1].SetActive(true);
            toggleObj[0].SetActive(false);
            status = 1;
        } else if (gameObject.name == "AR-icon")
        {
            toggleObj[2].SetActive(true);
            toggleObj[1].SetActive(false);
            status = 2;
        } else if (gameObject.name == "TeskText")
        {
            toggleObj[3].SetActive(true);
            toggleObj[2].SetActive(false);
            status = 3;
        } else if (status == 3)
        {
            resetTutorials();
        }

    }

    void Update()
    {
        if (start == true && jib.activeSelf == true && loading.activeSelf == false)
        {
            groupTutorial.SetActive(true);
            toggleObj[0].SetActive(true);
            start = false;
        }
    }

    void resetTutorials()
    {
        toggleObj[0].SetActive(false);
        toggleObj[1].SetActive(false);
        toggleObj[2].SetActive(false);
        status = 0;
        groupTutorial.SetActive(false);
    }
}
