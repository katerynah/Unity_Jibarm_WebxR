using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EinschaltLect : MonoBehaviour
{
    public List<GameObject> taskObjects = new List<GameObject>();
    public List<GameObject> checkObjects = new List<GameObject>();

    public GameObject controlNav;

    public void addContent(GameObject currAR, GameObject currCtrl)
    {
        // TO DO: desc on control panel
        currAR.SetActive(true);
        currCtrl.SetActive(true);
        controlNav.SetActive(true);
       // ControlNav.cs OnMouseDown for Arrows and task change
    }

    public void removeContent(GameObject currAR, GameObject currCtrl)
    {
        //startRaycasting(false);
        currAR.SetActive(false);
        currCtrl.SetActive(false);
        controlNav.SetActive(false);

    }
}
