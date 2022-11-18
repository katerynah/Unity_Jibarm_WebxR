using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustELText : MonoBehaviour
{
    public RectTransform rightPanel;
    private RectTransform childRect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightPanel.rect.width < 95f)
        {
            foreach (Transform child in gameObject.transform)
            {
                childRect = child.GetComponent<RectTransform>();
                childRect.sizeDelta = new Vector3(0f, 0f);
                Debug.Log($"The child {childRect.gameObject.name} to 0");
            }
        } else if (rightPanel.rect.width >= 95f)
        {
            foreach (Transform child in gameObject.transform)
            {
                childRect = child.GetComponent<RectTransform>();
                childRect.sizeDelta = new Vector3(rightPanel.rect.width - 60f, childRect.rect.height);
                Debug.Log($"The child {childRect.gameObject.name} to {childRect.rect.width}");

            }
        }
    }
}
