using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoordsysTasks : MonoBehaviour
{
    public bool checkCurrTask = true;
    int countDown = 0;
    public GameObject[] checkScSwitch;
    KoordsysLect koordsysScript;
    public RaycastingAR raycastScript;
    float timeRemaining = 5;
    public Material redMat, greenMat;
    public GameObject switchBtn, switchLight;
    public GameObject screenView;
    List<GameObject> descs = new List<GameObject>();
    int index;
    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        koordsysScript = gameObject.GetComponent<KoordsysLect>();
        descs = koordsysScript.descObjects;
    }

    void Update()
    {
        if (checkCurrTask == true)
        {
            for (int i = 0; i < descs.Count; i++)
            {
                if (descs[i].activeSelf == true)
                {
                    index = i;
                }
            }

            if (index == 0)
            {
                gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().setLines();
                gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(true);
                gameObject.transform.GetChild(1).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                gameObject.transform.GetChild(1).GetComponent<ChangeColor>().setColor(false);
            }
            else if (index == 1)
            {
                gameObject.transform.GetChild(1).GetComponent<DrawLineBetweenTwoObjects>().setLines();
                gameObject.transform.GetChild(1).GetComponent<ChangeColor>().setColor(true);
                gameObject.transform.GetChild(0).GetComponent<DrawLineBetweenTwoObjects>().removeNotes();
                gameObject.transform.GetChild(0).GetComponent<ChangeColor>().setColor(false);

                // check on Einschalt- and Diagnose checkmarks - if enabled
                if (start == true && checkScSwitch[0].activeSelf == false && checkScSwitch[1].activeSelf == false)
                {
                    Transform objectTransform = switchBtn.GetComponent<Transform>();
                    objectTransform.Rotate(0f, -20f, 0f);
                    switchLight.GetComponent<MeshRenderer>().material = redMat;
                    Debug.Log($"Switch changed");
                    start = false;
                }
                switchBtn.tag = "raycast";
                raycastScript.raycasting = true;
            }

            checkCurrTask = false;
        }

        if (countDown == 1)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if (timeRemaining <= 0)
            {
                switchLight.GetComponent<MeshRenderer>().material = greenMat;
                screenView.SetActive(true);
                countDown = 2;
            }
        }
    }


    public void doTouch(GameObject selected)
    {
        if (selected == switchBtn)
        {
            Transform objectTransform = switchBtn.GetComponent<Transform>();
            objectTransform.Rotate(0f, 20f, 0f);
            raycastScript.raycasting = false;
            countDown = 1;
        }

    }

}
