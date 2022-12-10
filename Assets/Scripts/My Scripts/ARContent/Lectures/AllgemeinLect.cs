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
        currAR.GetComponent<DrawLineBetweenTwoObjects>().setLines();
        currCtrl.SetActive(true);
    }

    void removeContent(GameObject currAR, GameObject currCtrl)
    {
        currAR.GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
        disableDesc();
        foreach (var note in noteObjects.ToArray())
        {
            note.GetComponent<ChangeColor>().setColor(false);
        }
        currAR.SetActive(false);
        currCtrl.SetActive(false);
    }


    public void disableDesc()
    {
        foreach (GameObject desc in descObjects.ToArray())
        {
            desc.SetActive(false);
        }

        foreach (GameObject note in noteObjects.ToArray())
        {
            note.GetComponent<ChangeColor>().setColor(false);
        }
    }

}
