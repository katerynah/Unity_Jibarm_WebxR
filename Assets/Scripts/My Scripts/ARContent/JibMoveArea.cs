using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JibMoveArea : MonoBehaviour
{

    public bool checkCollision = true;
    public bool inArea = false;
    public Material aura_Green, aura_Red, aura_White;
    public JibarmMovement joystick1Script;
    public Trigger2ndCircle trigger2ndScript;
    public GameObject[] circles;
    GameObject currCircle;
    MeshRenderer selectionRenderer1, selectionRenderer2;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
        circles[0].transform.GetChild(0).gameObject.SetActive(false);
        selectionRenderer1 = circles[0].transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
        selectionRenderer2 = circles[0].transform.GetChild(2).gameObject.GetComponent<MeshRenderer>();
        selectionRenderer1.material = aura_Green;
        selectionRenderer2.material = aura_Green;
        circles[1].SetActive(true);
        joystick1Script.start = true;
        inArea = true;
    }

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "raycast" && checkCollision)
    //    {
    //        currCircle = other.gameObject;
    //        circles[1].SetActive(false);
    //        selectionRenderer1.material = aura_White;
    //        selectionRenderer2.material = aura_White;
    //        inArea = false;
    //    }
    //}

    private void Update()
    {
        if (inArea)
        {
            circles[1].SetActive(true);
            trigger2ndScript.gameObject.SetActive(true);
            trigger2ndScript.startCollision = true;
        } else
        {
            trigger2ndScript.startCollision = false;
            trigger2ndScript.gameObject.SetActive(false);
        }
    }
}
