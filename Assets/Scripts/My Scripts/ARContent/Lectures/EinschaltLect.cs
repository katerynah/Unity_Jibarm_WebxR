using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinschaltLect : MonoBehaviour
{
    public List<GameObject> tasksObjects = new List<GameObject>();
    public List<GameObject> checkObjects = new List<GameObject>();
    public ControlNav arrowScript;

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
        arrowScript.gameObject.SetActive(true);
        arrowScript.setObjectList();
        // DESC: ControlNav.cs OnMouseDown for Arrows and task change
        // DESC: OntriggerEnter from EinschaltTasks
        // DESC: Raycast with Collider from StahlseilenWeg
    }

    void removeContent(GameObject currAR, GameObject currCtrl)
    {
        //startRaycasting(false);
        currAR.SetActive(false);
        currCtrl.SetActive(false);
        arrowScript.gameObject.SetActive(false);
    }

}
