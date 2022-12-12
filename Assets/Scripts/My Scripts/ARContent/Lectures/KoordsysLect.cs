using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoordsysLect : MonoBehaviour
{
    public List<GameObject> taskObjects = new List<GameObject>();
    public List<GameObject> descObjects = new List<GameObject>();
    public ControlNav arrowScript;
    public GameObject studioEnv;
    bool start = true;
    //public ControlNav arrowScript;

    public void setLectureValues(int add, GameObject currAR, GameObject currCtrl)
    {
        if (add == 0)
        {
            addContent(currAR, currCtrl);
        }
        else if (add == 1)
        {
            removeContent(currAR, currCtrl);
        }
        else
        {
            Debug.LogError("Check SelectionManager.cs SwitchAR addARContent-values (should be 0 or 1)");
        }
    }

    void addContent(GameObject currAR, GameObject currCtrl)
    {
        currAR.SetActive(true);
        currCtrl.SetActive(true);
       
        if (start == true)
        {
            foreach (Transform child in currCtrl.GetComponent<Transform>())
            {
                descObjects.Add(child.gameObject);
            }

            foreach (Transform child in currAR.GetComponent<Transform>())
            {
                taskObjects.Add(child.gameObject);
            }
            start = false;
        }
        arrowScript.gameObject.SetActive(true);
        arrowScript.setObjectList();
        studioEnv.SetActive(true);
    }

    void removeContent(GameObject currAR, GameObject currCtrl)
    {
        currAR.SetActive(false);
        currCtrl.SetActive(false);
        arrowScript.gameObject.SetActive(false);
        studioEnv.SetActive(false);
    }

}
