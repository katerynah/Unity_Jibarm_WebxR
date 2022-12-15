using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManageMarks : MonoBehaviour
{
    Image tempRedBgd, tempGreenBgd;
    TextMeshProUGUI tempRedText, tempGreenText;
    Color32 grabLColor = new Color32(96, 96, 96, 255);  // grey landmark
    public GameObject markTemp, grabWindow, qualityWindow, descMarks;
    [HideInInspector]
    public GameObject currMark, currLandmark;
    public VermessenTasks vermessenTScript;
    public LaserCaught laserScript;
    public List<GameObject> checkMarks = new List<GameObject>();
    public List<GameObject> lastCheckMarks = new List<GameObject>();
    List<GameObject> usedCheckMarks = new List<GameObject>();
    List<GameObject> usedMarks = new List<GameObject>();
    List<GameObject> usedLMarks = new List<GameObject>();

    public enum MarkButtons
    {
        Grab, Remove, Cancel, Save, Locate, Abort
    }
    public MarkButtons UseAs;

    void Start()
    {
        GameObject greenTemp = markTemp.transform.GetChild(0).gameObject;
        GameObject redTemp = markTemp.transform.GetChild(1).gameObject;
        tempRedBgd = redTemp.GetComponent<Image>();
        tempRedText = redTemp.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        tempGreenBgd = greenTemp.GetComponent<Image>();
        tempGreenText = greenTemp.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        useButton();
    }

    // Update is called once per frame
    public void useButton()
    {
        if (currMark != null && currLandmark != null)
        {
            Debug.Log($"curr Mark {currMark} and curr Landmark {currLandmark}");
            Image markBgd = currMark.GetComponent<Image>();
            SpriteRenderer landmarkBgd = currLandmark.GetComponent<SpriteRenderer>();
            TextMeshProUGUI markText = currMark.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

            switch (UseAs)
            {
                case MarkButtons.Grab:
                    // make green
                    Color32 bgdG = tempGreenBgd.color;
                    markBgd.color = bgdG;
                    Color32 _textG = tempGreenText.color;
                    markText.color = _textG;

                    landmarkBgd.color = grabLColor;
                    currLandmark.GetComponent<SphereCollider>().enabled = false;
                    //currLandmark.GetComponent<SphereCollider>().enabled = false;
                    usedMarks.Add(currMark);
                    usedLMarks.Add(currLandmark);

                    TextMeshProUGUI markDescCheck = checkMarks[usedMarks.Count - 1].GetComponent<TextMeshProUGUI>();
                    markDescCheck.SetText(markText.text);
                    checkMarks[usedMarks.Count - 1].transform.GetChild(1).gameObject.SetActive(true);
                    usedCheckMarks.Add(checkMarks[usedMarks.Count - 1].transform.GetChild(1).gameObject);

                    laserScript.resetColor = true;
                    grabWindow.SetActive(false);
                    break;
                case MarkButtons.Remove:
                    // make red
                    Color32 bgdR = tempRedBgd.color;
                    markBgd.color = bgdR;
                    Color32 _textR = tempRedText.color;
                    markText.color = _textR;

                    int i = 0;

                    if (usedMarks.Count != 0)
                    {
                        foreach (GameObject rMark in usedMarks)
                        {
                            if (rMark == currMark)
                            {
                                usedMarks.Remove(rMark);
                                usedCheckMarks.Remove(usedCheckMarks[i]);
                                usedLMarks.Remove(usedLMarks[i]);
                                usedLMarks[i].GetComponent<Image>().color = Color.white;
                                usedMarks[i].GetComponent<SphereCollider>().enabled = true;
                            }
                            i++;
                        }
                    }

                    grabWindow.SetActive(false);
                    break;
                case MarkButtons.Cancel:
                    grabWindow.SetActive(false);
                    break;
                case MarkButtons.Locate:
                    qualityWindow.SetActive(true);
                    lastCheckMarks[0].SetActive(true);
                    break;
                case MarkButtons.Save:
                    lastCheckMarks[1].SetActive(true);
                    break;
                case MarkButtons.Abort:
                    foreach (Transform point in vermessenTScript.mGroup.GetComponent<Transform>())
                    {
                        Color32 bgdAbort = tempRedBgd.color;
                        point.gameObject.GetComponent<Image>().color = bgdAbort;
                        Color32 _textAbort = tempRedText.color;
                        point.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().color = _textAbort;
                    }
                    break;
            }
            currMark = null;
            currLandmark = null;
        }
        
    }

}
