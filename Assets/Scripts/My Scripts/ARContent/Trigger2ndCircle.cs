using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2ndCircle : MonoBehaviour
{
    public bool startCollision = false;
    public GameObject[] circles;
    public GameObject checkMark;
    public Material aura_Green, aura_Red;
    MeshRenderer selectionRenderer1, selectionRenderer2;

    // Start is called before the first frame update

    private void Start()
    {
        selectionRenderer1 = circles[1].transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
        selectionRenderer2 = circles[1].transform.GetChild(2).gameObject.GetComponent<MeshRenderer>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jibarm" && startCollision)
        {
            selectionRenderer1.material = aura_Green;
            selectionRenderer2.material = aura_Green;
            jibMoved();
            startCollision = false;
        }
    }

    void jibMoved()
    {
        circles[0].SetActive(false);
        circles[1].SetActive(false);
        checkMark.SetActive(true);
    }
}
