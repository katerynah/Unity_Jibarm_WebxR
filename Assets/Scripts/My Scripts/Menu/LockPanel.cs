using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    public DragPanel dragScript;
    //public GameObject eLFullBtn;
    public List<GameObject> changeObj = new List<GameObject>();
    public bool inAR = false;
    bool withArrows = false;
    // Lectures without Arrows
    public enum Modes
    {
        Lock, AR, ControlView
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
                    this.changeObj[1].SetActive(false);
                    this.changeObj[0].SetActive(true);
                    break;
                case Modes.AR:
                    this.changeObj[1].SetActive(false);
                    this.changeObj[0].SetActive(true);
                    this.changeObj[2].SetActive(true);
                    this.changeObj[3].SetActive(true);
                    this.changeObj[4].SetActive(true);
                    inAR = true;
                    break;
                case Modes.ControlView:
                    //this.changeObj[1].SetActive(false);
                    //this.changeObj[0].SetActive(true);
                    this.changeObj[2].SetActive(false);
                    if (this.changeObj[3].activeSelf == true)
                    {
                        this.changeObj[3].SetActive(false);
                        withArrows = true;
                    }
                    break;
            }

        } // Lock the Panel
        else if (gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            switch (UseAs)
            {
                case Modes.Lock:
                    dragScript.enabled = false;
                    this.changeObj[0].SetActive(false);
                    this.changeObj[1].SetActive(true);
                    //eLFullBtn.SetActive(true);
                    break;
                case Modes.AR:
                    this.changeObj[0].SetActive(false);
                    this.changeObj[1].SetActive(true);
                    this.changeObj[2].SetActive(false);
                    this.changeObj[3].SetActive(false);
                    this.changeObj[4].SetActive(false);
                    inAR = false;
                    break;
                case Modes.ControlView:
                    //this.changeObj[0].SetActive(false);
                    //this.changeObj[1].SetActive(true);
                    this.changeObj[2].SetActive(true);
                    if (withArrows == true)
                    {
                        this.changeObj[3].SetActive(true);
                        withArrows = false;
                    }
                    break;
            }

        }
    }

}
