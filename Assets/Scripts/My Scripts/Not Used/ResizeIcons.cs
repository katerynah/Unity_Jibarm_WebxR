using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeIcons : MonoBehaviour
{
    //public List<GameObject> objToResize = new List<GameObject>();
    private RectTransform objRect;
    [SerializeField]
    private float factor = 1.5f;
    [SerializeField]
    private float summand = 15f;


    // Start is called before the first frame update
    void Start()
    {
        if((Screen.width/Screen.height) <= (16/8))
        {
            foreach (Transform child in gameObject.GetComponent<Transform>())
            {
                objRect = child.GetComponent<RectTransform>();
                objRect.localScale = new Vector2(objRect.localScale.x * factor, objRect.localScale.y * factor);
                child.transform.position = new Vector2(child.transform.position.x + summand *2.5f, child.transform.position.y - summand/2);
                Debug.Log($"Current screen size width {Screen.width} and height {Screen.height}");
            }
        }
    }

}
