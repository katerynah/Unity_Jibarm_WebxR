using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObjects : MonoBehaviour
{
    public List<GameObject> objectsToHide = new List<GameObject>();
    public List<GameObject> objectsToShow = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        hideShowObjects();
    }

    public void hideShowObjects()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (objectsToHide.Count > 0)
            {
                for (int i = 0; i < objectsToHide.Count; i++)
                {
                    objectsToHide[i].SetActive(false);
                }
            }

            if (objectsToShow.Count > 0)
            {
                for (int i = 0; i < objectsToShow.Count; i++)
                {
                    objectsToShow[i].SetActive(true);
                }
            }
        }
    }

}
