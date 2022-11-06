using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCanvas : MonoBehaviour
{

    private bool tateMode;
    public GameObject myCamera;
    public GridLayoutGroup myGrid;
    public RectTransform layoutRotator;

    // Use this for initialization
    void Start()
    {
        tateMode = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            tateMode = !tateMode;
            if (tateMode)
            {
                myCamera.transform.eulerAngles = new Vector3(0f, 0f, -90f);
                layoutRotator.eulerAngles = new Vector3(0f, 0f, 90f);
                myGrid.cellSize = new Vector2(Screen.currentResolution.height, Screen.currentResolution.width);
            }
            else
            {
                myCamera.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                layoutRotator.eulerAngles = new Vector3(0f, 0f, 0f);
                myGrid.cellSize = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
            }
        }
    }
}