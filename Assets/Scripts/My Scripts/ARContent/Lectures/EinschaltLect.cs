using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinschaltLect : MonoBehaviour
{
    public List<GameObject> taskObjects = new List<GameObject>();
    public List<GameObject> checkObjects = new List<GameObject>();
    public ControlNav arrowScript;

    public void setLecureValues(int add, GameObject currAR, GameObject currCtrl)
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
        // TO DO: desc on control panel
        currAR.SetActive(true);
        currCtrl.SetActive(true);
        arrowScript.gameObject.SetActive(true);
        arrowScript.setObjectList();
        // ControlNav.cs OnMouseDown for Arrows and task change
        // OntriggerEnter from StahlseilenWeg
        // Raycast with Collider from StahlseilenWeg
    }

    void removeContent(GameObject currAR, GameObject currCtrl)
    {
        //startRaycasting(false);
        currAR.SetActive(false);
        currCtrl.SetActive(false);
        arrowScript.gameObject.SetActive(false);
    }

}
