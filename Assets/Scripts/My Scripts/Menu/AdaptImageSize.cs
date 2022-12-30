using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptImageSize : MonoBehaviour
{
    public Canvas canvas;
    float canW, canH;
    RectTransform screenshot;
    bool canSize = true;

    // Start is called before the first frame update
    void Start()
    {
        canW = canvas.GetComponent<RectTransform>().rect.width;
        canH = canvas.GetComponent<RectTransform>().rect.height;
        screenshot = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSize == true)
        {
            if (canW / canH >= 1.76f)
            {
                var h = canH - (2 * 26.75f / 100);
                screenshot.sizeDelta = new Vector2(h * 1.76f, h);
            }
            else if (canW / canH < 1.76f)
            {
                var w = canW - (2 * 28.1f / 100);
                screenshot.sizeDelta = new Vector2(w, w / 1.76f);
            }
            canSize = false;
        }
    }
}
