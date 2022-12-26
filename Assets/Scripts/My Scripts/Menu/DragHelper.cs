using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHelper : MonoBehaviour
{
    public bool insideDragArea = false;

    // Start is called before the first frame update
    public void OnPointerEnter()
    {
        insideDragArea = true;
    }

    //// Update is called once per frame
    //public void checkClickArea()
    //{
        
    //}

    public void OnPointerExit()
    {
        insideDragArea = false;
    }
}
