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
    public GameObject[] checkAnim;
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
    }

    void Update()
    {
        if (checkAnim[0].activeSelf == true && select == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            animator[0].Play("Step1", -1, 0f);
            animator[0].enabled = false;
            checkAnim[0].SetActive(false);
        }
        else if (checkAnim[1].activeSelf == true && select == 1)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
            animator[1].Play("4JacksAnimation", -1, 0f);
            animator[1].enabled = false;
            checkAnim[1].SetActive(false);
        }
    }


}
