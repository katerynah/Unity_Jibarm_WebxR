using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    public DragPanel dragScript;
    //public GameObject eLFullBtn;
    public GameObject hideObject;
    public List<GameObject> changeObj = new List<GameObject>();
    public bool inAR = false;
    public enum Modes
    {
        Lock, AR
    }
    public Modes UseAs;

    // Update is called once per frame
    public void OnPointerClick()
    {
        // Unlock the Panel also if not AR mode
        if (gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            switch (UseAs)
            {
                case Modes.Lock:
                    dragScript.enabled = true;
                    //eLFullBtn.SetActive(false);

                    // check if Book is inaactive
                    if (!changeObj[0].activeSelf)
                    {
                        gameObject.transform.GetChild(1).gameObject.SetActive(false);
                        gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    break;
                case Modes.AR:
                    //hideObject.SetActive(true);
                    gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    dragScript.enabled = false;
                    if (changeObj[0].activeSelf == false)
                    {
                        // Lock active
                        changeObj[0].SetActive(true);
                        // Unlock inactive
                        changeObj[1].SetActive(false);
                    }
                    inAR = true;
                    break;
            }

        } // Lock the Panel
        else if (gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            switch (UseAs)
            {
                case Modes.Lock:
                    dragScript.enabled = false;
                    //eLFullBtn.SetActive(true);
                    break;
                case Modes.AR:
                    //hideObject.SetActive(false);
                    inAR = false;
                    break;
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
