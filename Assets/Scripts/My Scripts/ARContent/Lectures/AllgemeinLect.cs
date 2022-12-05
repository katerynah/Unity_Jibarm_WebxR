using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllgemeinLect : MonoBehaviour
{
    public SelectionManager selectScript;
    public RaycastingAR raycastScript;
    public List<GameObject> descObjects = new List<GameObject>();
    public List<GameObject> noteObjects = new List<GameObject>();

    public bool raycasting = false;

    public void addContent(GameObject currAR, GameObject currCtrl)
    {
        // TO DO: desc on control panel
        currAR.SetActive(true);
        currAR.GetComponent<DrawLineBetweenTwoObjects>().setLines();
        currCtrl.SetActive(true);
    }

    public void removeContent(GameObject currAR, GameObject currCtrl)
    {
        //startRaycasting(false);
        currAR.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
        foreach (GameObject note in noteObjects.ToArray())
        {
            note.GetComponent<ChangeColor>().setColor(false);
        }
        currAR.SetActive(false);
        currCtrl.SetActive(false);
    }


}
