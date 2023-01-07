using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptJacks : MonoBehaviour
{
    public Material aura_green, aura_red, aura_white;
    public bool checkCollision = false;
    public GameObject[] checkmarks;
    public GameObject circleFront, circleBack;
    public GameObject[] nilPoint;
    public GameObject[] checks;

    //float count = 7;
    float timeRemaining = 7;
    float speed = 1;
    // 14 g, 23 r, 12 34
    public List<GameObject> jacks = new List<GameObject>();
    MeshRenderer meshR1, meshR2, meshL1, meshL2;
    public Animator[] anim;

    public int countDown = 0;
    [HideInInspector]
    public bool played = true;


    void Start()
    {
        var child1 = circleBack.transform.GetChild(0); // jack group
        var child2 = circleBack.transform.GetChild(1); // jack group

        setMeshRenderer(child1, child2);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "nivelpoint" && checkCollision)
        {
            if (countDown == 0 && anim[0].enabled == true)
            {
                checkmarks[0].SetActive(true);
            }
            else if (countDown == 1 && anim[1].enabled == true)
            {
                checkmarks[1].SetActive(true);
            }
            else if (countDown == 2)
            {
                checkmarks[2].SetActive(true);
            }
        }

        if (other.gameObject.tag == "raycast" && checkCollision)
        {
            if (countDown == 0 && other.gameObject.name == "BR-Jack")
            {
                meshR1.material = aura_green;
                meshR2.material = aura_green;

                var rotObj1 = jacks[0].transform.GetChild(1).gameObject;
                var rotObj2 = jacks[3].transform.GetChild(1).gameObject;
                var movetObj1 = jacks[0].transform.GetChild(0).gameObject;
                var moveObj2 = jacks[3].transform.GetChild(0).gameObject;

                // jacks[0], jacks[3], rotObj1, rotObj2, movetObj1, moveObj2
                newJacksRot();
            }
            else if (countDown == 0 && other.gameObject.name == "BL-Jack" && anim[0].enabled == false)
            {
                meshL1.material = aura_red;
                meshL2.material = aura_red;
                if (nilPoint[1].activeSelf == false)
                {
                    nilPoint[1].SetActive(false);
                    nilPoint[0].SetActive(true);
                }

            }


            if (countDown == 1 && other.gameObject.name == "FL-Jack")
            {
                var child1 = circleFront.transform.GetChild(1); // jack group
                var child2 = circleFront.transform.GetChild(0); // jack group

                setMeshRenderer(child1, child2);

                meshR1.material = aura_green;
                meshR2.material = aura_green;

                var rotObj1 = jacks[0].transform.GetChild(1).gameObject;
                var rotObj2 = jacks[1].transform.GetChild(1).gameObject;
                var movetObj1 = jacks[0].transform.GetChild(0).gameObject;
                var moveObj2 = jacks[1].transform.GetChild(0).gameObject;

                // jacks[0], jacks[3], rotObj1, rotObj2, movetObj1, moveObj2
                newJacksRot();
            }
            else if (countDown == 1 && other.gameObject.name == "FR-Jack")
            {
                meshL1.material = aura_red;
                meshL2.material = aura_red;

            }

        }
    }

    public void toWhite()
    {
        meshR1.material = aura_white;
        meshR2.material = aura_white;
        meshL1.material = aura_white;
        meshL2.material = aura_white;
    }

    void setMeshRenderer(Transform child1, Transform child2)
    {
        meshR1 = child1.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        meshR2 = child1.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
        meshL1 = child2.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
        meshL2 = child2.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>();
    }

    // GameObject obj1, GameObject obj2, GameObject rot1, GameObject rot2, GameObject move1, GameObject move2
    void newJacksRot()
    {

        if (countDown == 0)
        {
            anim[0].enabled = true;
            nilPoint[1].SetActive(false);
            nilPoint[0].SetActive(true);

        }
        else if (countDown == 1)
        {
            anim[1].enabled = true;
            nilPoint[2].SetActive(false);
            nilPoint[0].SetActive(true);
            nilPoint[1].SetActive(false);
        }
        //rot1.transform.Rotate(new Vector3(0, 45, 0), speed * Time.deltaTime);
        //rot2.transform.Rotate(new Vector3(0, 45, 0), speed * Time.deltaTime);

        //move1.transform.Translate(obj1.transform.position + new Vector3(0, speed * Time.deltaTime * 10, 0));
        //move2.transform.Translate(obj1.transform.position + new Vector3(0, speed * Time.deltaTime * 10, 0));

    }

}
