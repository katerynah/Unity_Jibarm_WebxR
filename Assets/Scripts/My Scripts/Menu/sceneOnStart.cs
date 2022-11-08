using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneOnStart : MonoBehaviour
{
    public List<GameObject> objectsToEnable = new List<GameObject>();
    public List<GameObject> objectsToDisable = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectsToEnable.Count; i++)
        {
            if (!objectsToEnable[i].activeSelf)
            {
                objectsToEnable[i].SetActive(true);

            }
        }

        for (int i = 0; i < objectsToDisable.Count; i++)
        {
            if (objectsToDisable[i].activeSelf)
            {
                objectsToDisable[i].SetActive(false);

            }
        }

    }
}
