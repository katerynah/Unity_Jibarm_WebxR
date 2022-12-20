using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlaylist : MonoBehaviour
{
    int list = 0;
    public bool toggle = true;
    public List<GameObject> toggleObjects = new List<GameObject>();
    public GameObject lastgObj;
    public Material greenMat;
    public Animator[] animator;
    public GameObject[] jacksCircles;
    public int select = 0;
    public bool setGreen = false;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        playSteps();
    }

    public void playSteps()
    {
        if (select == 0)
        {
            if (transform.GetChild(0).gameObject.activeSelf == true)
            {
                animator[0].enabled = true;
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (transform.GetChild(1).gameObject.activeSelf == true)
            {
                animator[0].enabled = false;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
        } else if (select == 1)
        {
            if (transform.GetChild(0).gameObject.activeSelf == true)
            {
                animator[1].enabled = true;
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (transform.GetChild(1).gameObject.activeSelf == true)
            {
                animator[1].enabled = false;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
           

        }



        //if (list == 0)
        //{
        //    animator[0].SetBool("pushpin", true);
        //    animator[0].SetBool("ended", false);
    }

    void Update()
    {
        //Debug.Log($"Pos {lastgObj.transform.position.x }");

        if (lastgObj.transform.position.x == 0)
        {
            foreach (GameObject obj in jacksCircles)
            {
                var o1 = obj.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
                o1.material = greenMat;
                var o2 = obj.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
                o2.material = greenMat;
            }

        }
    }


}
