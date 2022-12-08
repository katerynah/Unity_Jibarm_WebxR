using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SicherheitLect : MonoBehaviour
{
    public SelectionManager selectScript;
    public RaycastingAR raycastScript;
    public ControlNav arrowScript;
    public List<GameObject> descObjects = new List<GameObject>();
    public List<GameObject> taskObjects = new List<GameObject>();

    public bool raycasting = false;

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
        currAR.SetActive(true);
        currCtrl.SetActive(true);
        arrowScript.gameObject.SetActive(true);
        arrowScript.setObjectList();
    }

    void removeContent(GameObject currAR, GameObject currCtrl)
    {
        //startRaycasting(false);
        currAR.SetActive(false);
        currCtrl.SetActive(false);
        arrowScript.gameObject.SetActive(false);
    }

}
